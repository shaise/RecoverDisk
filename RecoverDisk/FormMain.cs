using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Management;
using RecoverDisk.StorageAccess;
using RecoverDisk.DiskAnalyze;

namespace RecoverDisk
{
    public partial class FormMain : Form
    {
        CommonOpenFileDialog openFolderDialog;
        IStorageIO diskio = null;
        FileSystemBase fs;
        BootSectorCommon bs;
        FileManager fmanager;
        DiskInfo[] drives;
        cLogger logger;
        bool isTaskRunning = false;
        bool stopTask = false;
        Thread saveTask = null;
        DiskInfo curDrive = null;
        DataGuess dataGuess;
        long current;
        List<FatEntry> curDirList;
        int curDirCluster = -1;
        int scanDirsParent = 0;
        string selWritePath;
        bool isRecursive;
        long[] scanDirsFound;
        int curScanCluster = 3;

        public FormMain()
        {
            InitializeComponent();
            openFolderDialog = new CommonOpenFileDialog();
            openFolderDialog.IsFolderPicker = true;
            logger = new cLogger(500);
        }

        void DetectDisks()
        {
            drives = DiskInfo.GetAllDrives();
            comboDrives.Items.Clear();
            foreach (DiskInfo hd in drives)
                comboDrives.Items.Add(string.Format("{0} [{1}, {2}]", hd.Model, hd.SizeString, hd.Type));
            comboDrives.Items.Add("Image file...");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DetectDisks();
        }

 
        private void buttOpen_Click(object sender, EventArgs e)
        {
            int idisk = comboDrives.SelectedIndex;
            if (idisk < 0)
                return;
            if (diskio != null)
                diskio.Close();
            if (idisk == comboDrives.Items.Count - 1)
            {
                if (openImgFileDlg.ShowDialog() == DialogResult.OK)
                    diskio = new DiskImageIO(DiskInfo.FromImageFile(openImgFileDlg.FileName));
                else
                    return;
            }
            else
                diskio = new DiskIO(drives[comboDrives.SelectedIndex]);
            fmanager = new FileManager(diskio);
            fmanager.OnEventLog += Fmanager_OnEventLog;
            fmanager.Open();
            
            fs = fmanager.Partitions[0];
            Log("Found " + fs.BootSector.FsType.ToString() + " File system");
            bs = fs.BootSector;
            int seclen = diskio.GetDiskInfo().BytesPerSector;
            Log(string.Format("Sector Size = {0} bytes, Sectors in Cluster = {1}", seclen, bs.SectorPerCluster));
            Log(string.Format("Sectors in Fat = {0}, Fat Start = {1}, Root Dir Start = {2}", bs.FatSizeInBytes / seclen, bs.FatLocation / seclen, bs.RootDirLocation / seclen));
            Log(string.Format("Data Cluster Start = {0} , Sectors in Root Entry = {1}", bs.DataClusterLocation / seclen, bs.RootEntryCount / seclen));

            dataGuess = new DataGuessFat32(diskio);
            dataGuess.OnProgress += DataGuess_OnProgress;

            ListDirectory("/");
        }

        void UpdateGuessProgress(ProgressUpdateEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => { UpdateGuessProgress(e); }));
                return;
            }
            labelScanProgress.Text = string.Format("Progress: {0}%  cluster: {1}", e.Percent, e.Value);
        }

        private void DataGuess_OnProgress(object sender, ProgressUpdateEventArgs e)
        {
            UpdateGuessProgress(e);
        }

        void ListDirectory(string path, int cluster = FileSystemBase.ROOT_DIR_FAT_12_16)
        {
            curDirCluster = cluster;
            numDirCluster.Value = cluster;
            numSector.Value = fs.GetAbsoluteLocation(cluster) / diskio.GetDiskInfo().BytesPerSector;

            IEnumerable<FatEntry> fe = fs.GetDirEntries(cluster);

            labelCurDir.Text = path;
            listDirectory.Items.Clear();
            curDirList = new List<FatEntry>();
            foreach (var entry in fe)
            {
                listDirectory.Items.Add(string.Format("{0} {1}", DUtils.FatAttribStr(entry.Attribute), entry.FullName));
                curDirList.Add(entry);
            }
        }

        void Log(string txt, Color col)
        {
            logger.AddToLog(txt, col);
            textDiskInfo.Rtf = logger.GetLogAsRichText();
        }

        void Log(string txt)
        {
            Log(txt, Color.Yellow);
        }

        void UpdateImageProgress(long sectsleft)
        {
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(() => { UpdateImageProgress(sectsleft); }));
            else
                numSector.Value = sectsleft;
        }
        

        void SaveImage(string path)
        {
            using (diskio = new DiskIO(curDrive))
            {
                ulong maxsects = 1000;
                ulong sectstoread = curDrive.TotalSectors;
                byte[] buff = new byte[(uint)curDrive.BytesPerSector * maxsects];
                current = 0;
                FileStream fs = new FileStream(path, FileMode.Create);
                {
                    diskio.Seek(0);
                    while (sectstoread > 0)
                    {
                        ulong numsects = sectstoread > maxsects ? maxsects : sectstoread;
                        int len = (int)(numsects * (uint)curDrive.BytesPerSector);
                        diskio.ReadBytes(buff, len);
                        fs.Write(buff, 0, len);
                        sectstoread -= numsects;
                        if (DUtils.UpdatePeriodPassed())
                            UpdateImageProgress((long)sectstoread);
                        current++;
                    }
                    fs.Close();
                }
                UpdateImageProgress(0);
                diskio.Close();
            }

            string mapfile = path.Substring(0, path.Length - 4) + "_bad-sectors.map";
            StreamWriter sw = new StreamWriter(mapfile);
            foreach (SectorRegion badRegion in diskio.GetBadSectorMap())
            {
                sw.WriteLine(badRegion.ToString());
            }
            sw.Close();
        }

        void saveImageThread()
        {
            stopTask = false;
            isTaskRunning = true;
            SaveImage(selWritePath);
            isTaskRunning = false;
        }

        private void Fmanager_OnEventLog(object sender, LogEventArgs e)
        {
            //Log(e.Message, Color.LightBlue);

        }

        string ToHexDump(byte[] data, int pos, int nbytes)
        {
            StringBuilder sbh = new StringBuilder();
            StringBuilder sbc = new StringBuilder();
            for (int i = pos; i < pos + nbytes; i++)
            {
                int b = data[i];
                sbh.Append(b.ToString("X2"));
                sbh.Append(" ");
                if (b >= ' ' && b <= 'z')
                    sbc.Append((char)b);
                else
                    sbc.Append('.');
            }
            sbh.Append(sbc.ToString());
            return sbh.ToString();
        }

        private void buttReadSector_Click(object sender, EventArgs e)
        {
            int secsize = diskio.GetDiskInfo().BytesPerSector;
            if (bs.BytesPerSector != 0)
                secsize = bs.BytesPerSector;
            diskio.Seek(secsize * (long)numSector.Value);
            byte[] bts = new byte[secsize];
            diskio.ReadBytes(bts, secsize);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < secsize; i += 16)
                sb.AppendLine(ToHexDump(bts, i, 16));
            textSector.Text = sb.ToString();
            numSector.Value++;
        }

        private void buttImage_Click(object sender, EventArgs e)
        {
            if (isTaskRunning)
                return;
            saveFileDialog1.Filter = "Image files | *.img";
            saveFileDialog1.FileName = "DiskImage";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                curDrive = drives[comboDrives.SelectedIndex];
                selWritePath = saveFileDialog1.FileName;
                saveTask = new Thread(new ThreadStart(saveImageThread));
                saveTask.Start();
            }
        }

        private void buttGuessFatStart_Click(object sender, EventArgs e)
        {
            Dictionary<string, long> ospars = dataGuess.GuessOsParameters();
            numFatStart.Value = ospars["FatStart"];
            numFatSize.Value = ospars["FatSize"];
            numRootDirStart.Value = ospars["RootDirStart"];
            numRootEntrySize.Value = ospars["RootEntrySize"];
            numDataClusterSize.Value = ospars["ClusterSize"];
        }

        void SaveFile(FatEntry fe, string filePath)
        {
            FileStream outFile = new FileStream(filePath, FileMode.Create);
            fs.ReadFile(fe, outFile);
            outFile.Close();
            File.SetCreationTime(filePath, fe.FullCreationTime);
            File.SetLastWriteTime(filePath, fe.FullCreationTime);
            File.SetAttributes(filePath, fe.Attributes);
        }

        void AskSaveFile(FatEntry fe)
        {
            saveFileDialog1.Filter = null;
            saveFileDialog1.FileName = fe.FullName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                SaveFile(fe, saveFileDialog1.FileName);
        }

        string stripLastDir(string inDir)
        {
            if (inDir.Length < 2)
                return inDir;
            int i = 0;
            for (i = inDir.Length - 2; i > 0; i--)
                if (inDir[i] == '/')
                    break;
            return inDir.Substring(0, i + 1);
        }

        private void listDirectory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int item = listDirectory.SelectedIndex;
            FatEntry fe = curDirList[item];
            if ((fe.Attribute & (int)EntryAttributes.Directory) != 0)
            {
                string curdir = labelCurDir.Text;
                if (fe.FullName == "..")
                    curdir = stripLastDir(curdir);
                else if (fe.FullName != ".")
                    curdir = curdir + fe.FullName + "/";
                ListDirectory(curdir, fe.StartCluster);
            }
            else
                AskSaveFile(fe);
        }

        private void SaveDir(long dirCluster, string path)
        {
            IEnumerable<FatEntry> fe = fs.GetDirEntries(dirCluster);

            BeginInvoke(new MethodInvoker(() => { labelCurDir.Text = path; }));
            foreach (var entry in fe)
            {
                if (stopTask)
                    break;
                if (entry.StartCluster == 0)
                    continue;
                string savepath = path + entry.FullName;
                if ((entry.Attribute & (int)EntryAttributes.Directory) != 0)
                {
                    if (entry.FullName == ".." || entry.FullName == ".")
                        continue;
                    Directory.CreateDirectory(selWritePath + savepath );
                    if (isRecursive)
                        SaveDir(entry.StartCluster, savepath + "/");
                }
                else
                    SaveFile(entry, selWritePath + savepath);
            }
        }

        void SaveDirThread()
        {
            stopTask = false;
            isTaskRunning = true;
            SaveDir(curDirCluster, "/");
            isTaskRunning = false;
        }

        private void buttBkpDir_Click(object sender, EventArgs e)
        {
            if (isTaskRunning)
                return;
            if (openFolderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                selWritePath = openFolderDialog.FileName;
                textOutFolder.Text = selWritePath;
                isRecursive = checkRecursive.Checked;
                saveTask = new Thread(new ThreadStart(SaveDirThread));
                saveTask.Start();
            }

        }

        void ScanDirComplete()
        {
            listFoundDirs.Items.Clear();
            foreach (long val in scanDirsFound)
            {
                listFoundDirs.Items.Add(val.ToString());
            }
            labelScanProgress.Text = "Progress: Complete";
            numDirScanStartCluster.Value = curScanCluster;
        }

        void ScanDirsThread()
        {
            isTaskRunning = true;
            scanDirsFound = dataGuess.ScanForDirectoryLists(fs, ref curScanCluster, scanDirsParent);
            BeginInvoke(new MethodInvoker(() => { ScanDirComplete(); }));
            isTaskRunning = false;
        }

        void StartDirScan(int dirParent)
        {
            if (isTaskRunning)
                return;
            scanDirsParent = dirParent;
            curScanCluster = (int)numDirScanStartCluster.Value;
            saveTask = new Thread(new ThreadStart(ScanDirsThread));
            saveTask.Start();
        }

        private void buttScanSubdirs_Click(object sender, EventArgs e)
        {
            StartDirScan(curDirCluster);
        }

        private void buttScanAllDirs_Click(object sender, EventArgs e)
        {
            StartDirScan(-1);
        }

        private void buttStopDirScan_Click(object sender, EventArgs e)
        {
            dataGuess.StopTask = true;
        }

        private void listFoundDirs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int sel = listFoundDirs.SelectedIndex;
            if (sel < 0 || sel >= scanDirsFound.Length)
                return;
            ListDirectory("/", (int)scanDirsFound[sel]);
            tabCommander.SelectedTab = tabFileBrowser;
        }

        private void buttSaveDirList_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Cluster List files | *.txt";
            saveFileDialog1.FileName = "ClusterList";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                foreach (long cluster in scanDirsFound)
                {
                    sw.WriteLine(string.Format("{0}, {1}", cluster, fs.GetAbsoluteLocation(cluster) / diskio.GetDiskInfo().BytesPerSector));
                }
                sw.Close();
            }
        }
    }
}
