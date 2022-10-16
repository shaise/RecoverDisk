namespace RecoverDisk
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboDrives = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textOutFolder = new System.Windows.Forms.TextBox();
            this.buttOpen = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textDiskInfo = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textSector = new System.Windows.Forms.TextBox();
            this.numSector = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.buttReadSector = new System.Windows.Forms.Button();
            this.buttImage = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openImgFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numDataClusterSize = new System.Windows.Forms.NumericUpDown();
            this.numRootEntrySize = new System.Windows.Forms.NumericUpDown();
            this.numRootDirStart = new System.Windows.Forms.NumericUpDown();
            this.numFatSize = new System.Windows.Forms.NumericUpDown();
            this.buttGuessFatStart = new System.Windows.Forms.Button();
            this.numFatStart = new System.Windows.Forms.NumericUpDown();
            this.tabCommander = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabFileBrowser = new System.Windows.Forms.TabPage();
            this.checkRecursive = new System.Windows.Forms.CheckBox();
            this.buttBkpDir = new System.Windows.Forms.Button();
            this.labelCurDir = new System.Windows.Forms.Label();
            this.listDirectory = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numDirCluster = new System.Windows.Forms.NumericUpDown();
            this.buttReadDir = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttStopDirScan = new System.Windows.Forms.Button();
            this.labelScanProgress = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.listFoundDirs = new System.Windows.Forms.ListBox();
            this.buttScanAllDirs = new System.Windows.Forms.Button();
            this.buttScanSubdirs = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.numDirScanStartCluster = new System.Windows.Forms.NumericUpDown();
            this.buttSaveDirList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSector)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDataClusterSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRootEntrySize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRootDirStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFatSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFatStart)).BeginInit();
            this.tabCommander.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabFileBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDirCluster)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDirScanStartCluster)).BeginInit();
            this.SuspendLayout();
            // 
            // comboDrives
            // 
            this.comboDrives.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDrives.FormattingEnabled = true;
            this.comboDrives.Location = new System.Drawing.Point(84, 12);
            this.comboDrives.Name = "comboDrives";
            this.comboDrives.Size = new System.Drawing.Size(586, 21);
            this.comboDrives.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select drive:";
            // 
            // textOutFolder
            // 
            this.textOutFolder.Location = new System.Drawing.Point(84, 41);
            this.textOutFolder.Name = "textOutFolder";
            this.textOutFolder.ReadOnly = true;
            this.textOutFolder.Size = new System.Drawing.Size(664, 20);
            this.textOutFolder.TabIndex = 3;
            // 
            // buttOpen
            // 
            this.buttOpen.Location = new System.Drawing.Point(12, 68);
            this.buttOpen.Name = "buttOpen";
            this.buttOpen.Size = new System.Drawing.Size(75, 23);
            this.buttOpen.TabIndex = 5;
            this.buttOpen.Text = "Open";
            this.buttOpen.UseVisualStyleBackColor = true;
            this.buttOpen.Click += new System.EventHandler(this.buttOpen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textDiskInfo);
            this.groupBox1.Location = new System.Drawing.Point(12, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 105);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log";
            // 
            // textDiskInfo
            // 
            this.textDiskInfo.BackColor = System.Drawing.Color.Black;
            this.textDiskInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textDiskInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textDiskInfo.Location = new System.Drawing.Point(3, 16);
            this.textDiskInfo.Name = "textDiskInfo";
            this.textDiskInfo.ReadOnly = true;
            this.textDiskInfo.Size = new System.Drawing.Size(733, 86);
            this.textDiskInfo.TabIndex = 0;
            this.textDiskInfo.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSector);
            this.groupBox2.Location = new System.Drawing.Point(6, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(523, 205);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sector data";
            // 
            // textSector
            // 
            this.textSector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textSector.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSector.Location = new System.Drawing.Point(3, 16);
            this.textSector.Multiline = true;
            this.textSector.Name = "textSector";
            this.textSector.ReadOnly = true;
            this.textSector.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textSector.Size = new System.Drawing.Size(517, 186);
            this.textSector.TabIndex = 0;
            // 
            // numSector
            // 
            this.numSector.Location = new System.Drawing.Point(49, 10);
            this.numSector.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numSector.Name = "numSector";
            this.numSector.Size = new System.Drawing.Size(120, 20);
            this.numSector.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Sector:";
            // 
            // buttReadSector
            // 
            this.buttReadSector.Location = new System.Drawing.Point(175, 8);
            this.buttReadSector.Name = "buttReadSector";
            this.buttReadSector.Size = new System.Drawing.Size(53, 23);
            this.buttReadSector.TabIndex = 10;
            this.buttReadSector.Text = "Read++";
            this.buttReadSector.UseVisualStyleBackColor = true;
            this.buttReadSector.Click += new System.EventHandler(this.buttReadSector_Click);
            // 
            // buttImage
            // 
            this.buttImage.Location = new System.Drawing.Point(676, 12);
            this.buttImage.Name = "buttImage";
            this.buttImage.Size = new System.Drawing.Size(75, 23);
            this.buttImage.TabIndex = 11;
            this.buttImage.Text = "Make Image";
            this.buttImage.UseVisualStyleBackColor = true;
            this.buttImage.Click += new System.EventHandler(this.buttImage_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "DiskImage";
            this.saveFileDialog1.Filter = "Image files|*.img";
            // 
            // openImgFileDlg
            // 
            this.openImgFileDlg.Filter = "Disk Image files|*.img";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numDataClusterSize);
            this.groupBox3.Controls.Add(this.numRootEntrySize);
            this.groupBox3.Controls.Add(this.numRootDirStart);
            this.groupBox3.Controls.Add(this.numFatSize);
            this.groupBox3.Controls.Add(this.buttGuessFatStart);
            this.groupBox3.Controls.Add(this.numFatStart);
            this.groupBox3.Location = new System.Drawing.Point(12, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 238);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Manual boot record";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Root entry size:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Data clstr start:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Root dir Start:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Fat Size:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fat Start:";
            // 
            // numDataClusterSize
            // 
            this.numDataClusterSize.Location = new System.Drawing.Point(93, 137);
            this.numDataClusterSize.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numDataClusterSize.Name = "numDataClusterSize";
            this.numDataClusterSize.Size = new System.Drawing.Size(80, 20);
            this.numDataClusterSize.TabIndex = 21;
            // 
            // numRootEntrySize
            // 
            this.numRootEntrySize.Location = new System.Drawing.Point(93, 114);
            this.numRootEntrySize.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numRootEntrySize.Name = "numRootEntrySize";
            this.numRootEntrySize.Size = new System.Drawing.Size(80, 20);
            this.numRootEntrySize.TabIndex = 19;
            // 
            // numRootDirStart
            // 
            this.numRootDirStart.Location = new System.Drawing.Point(93, 91);
            this.numRootDirStart.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numRootDirStart.Name = "numRootDirStart";
            this.numRootDirStart.Size = new System.Drawing.Size(80, 20);
            this.numRootDirStart.TabIndex = 17;
            // 
            // numFatSize
            // 
            this.numFatSize.Location = new System.Drawing.Point(93, 68);
            this.numFatSize.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numFatSize.Name = "numFatSize";
            this.numFatSize.Size = new System.Drawing.Size(80, 20);
            this.numFatSize.TabIndex = 15;
            // 
            // buttGuessFatStart
            // 
            this.buttGuessFatStart.Location = new System.Drawing.Point(9, 164);
            this.buttGuessFatStart.Name = "buttGuessFatStart";
            this.buttGuessFatStart.Size = new System.Drawing.Size(55, 23);
            this.buttGuessFatStart.TabIndex = 14;
            this.buttGuessFatStart.Text = "Guess";
            this.buttGuessFatStart.UseVisualStyleBackColor = true;
            this.buttGuessFatStart.Click += new System.EventHandler(this.buttGuessFatStart_Click);
            // 
            // numFatStart
            // 
            this.numFatStart.Location = new System.Drawing.Point(93, 45);
            this.numFatStart.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numFatStart.Name = "numFatStart";
            this.numFatStart.Size = new System.Drawing.Size(80, 20);
            this.numFatStart.TabIndex = 13;
            // 
            // tabCommander
            // 
            this.tabCommander.Controls.Add(this.tabPage1);
            this.tabCommander.Controls.Add(this.tabFileBrowser);
            this.tabCommander.Controls.Add(this.tabPage3);
            this.tabCommander.Location = new System.Drawing.Point(205, 68);
            this.tabCommander.Name = "tabCommander";
            this.tabCommander.SelectedIndex = 0;
            this.tabCommander.Size = new System.Drawing.Size(543, 267);
            this.tabCommander.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.numSector);
            this.tabPage1.Controls.Add(this.buttReadSector);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(535, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Raw View";
            // 
            // tabFileBrowser
            // 
            this.tabFileBrowser.BackColor = System.Drawing.Color.Gainsboro;
            this.tabFileBrowser.Controls.Add(this.checkRecursive);
            this.tabFileBrowser.Controls.Add(this.buttBkpDir);
            this.tabFileBrowser.Controls.Add(this.labelCurDir);
            this.tabFileBrowser.Controls.Add(this.listDirectory);
            this.tabFileBrowser.Controls.Add(this.label8);
            this.tabFileBrowser.Controls.Add(this.numDirCluster);
            this.tabFileBrowser.Controls.Add(this.buttReadDir);
            this.tabFileBrowser.Location = new System.Drawing.Point(4, 22);
            this.tabFileBrowser.Name = "tabFileBrowser";
            this.tabFileBrowser.Padding = new System.Windows.Forms.Padding(3);
            this.tabFileBrowser.Size = new System.Drawing.Size(535, 241);
            this.tabFileBrowser.TabIndex = 1;
            this.tabFileBrowser.Text = "File Browser";
            // 
            // checkRecursive
            // 
            this.checkRecursive.AutoSize = true;
            this.checkRecursive.Location = new System.Drawing.Point(457, 7);
            this.checkRecursive.Name = "checkRecursive";
            this.checkRecursive.Size = new System.Drawing.Size(74, 17);
            this.checkRecursive.TabIndex = 17;
            this.checkRecursive.Text = "Recursive";
            this.checkRecursive.UseVisualStyleBackColor = true;
            // 
            // buttBkpDir
            // 
            this.buttBkpDir.Location = new System.Drawing.Point(376, 3);
            this.buttBkpDir.Name = "buttBkpDir";
            this.buttBkpDir.Size = new System.Drawing.Size(75, 23);
            this.buttBkpDir.TabIndex = 16;
            this.buttBkpDir.Text = "Backup dir";
            this.buttBkpDir.UseVisualStyleBackColor = true;
            this.buttBkpDir.Click += new System.EventHandler(this.buttBkpDir_Click);
            // 
            // labelCurDir
            // 
            this.labelCurDir.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelCurDir.Location = new System.Drawing.Point(9, 29);
            this.labelCurDir.Name = "labelCurDir";
            this.labelCurDir.Size = new System.Drawing.Size(520, 16);
            this.labelCurDir.TabIndex = 15;
            this.labelCurDir.Text = "Path";
            // 
            // listDirectory
            // 
            this.listDirectory.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDirectory.FormattingEnabled = true;
            this.listDirectory.ItemHeight = 11;
            this.listDirectory.Location = new System.Drawing.Point(9, 53);
            this.listDirectory.Name = "listDirectory";
            this.listDirectory.Size = new System.Drawing.Size(520, 180);
            this.listDirectory.TabIndex = 14;
            this.listDirectory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listDirectory_MouseDoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Directory Cluster:";
            // 
            // numDirCluster
            // 
            this.numDirCluster.Location = new System.Drawing.Point(98, 5);
            this.numDirCluster.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numDirCluster.Name = "numDirCluster";
            this.numDirCluster.Size = new System.Drawing.Size(120, 20);
            this.numDirCluster.TabIndex = 11;
            // 
            // buttReadDir
            // 
            this.buttReadDir.Location = new System.Drawing.Point(224, 3);
            this.buttReadDir.Name = "buttReadDir";
            this.buttReadDir.Size = new System.Drawing.Size(53, 23);
            this.buttReadDir.TabIndex = 13;
            this.buttReadDir.Text = "Read";
            this.buttReadDir.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage3.Controls.Add(this.buttSaveDirList);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.numDirScanStartCluster);
            this.tabPage3.Controls.Add(this.buttStopDirScan);
            this.tabPage3.Controls.Add(this.labelScanProgress);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.buttScanAllDirs);
            this.tabPage3.Controls.Add(this.buttScanSubdirs);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(535, 241);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Directory scan";
            // 
            // buttStopDirScan
            // 
            this.buttStopDirScan.Location = new System.Drawing.Point(6, 184);
            this.buttStopDirScan.Name = "buttStopDirScan";
            this.buttStopDirScan.Size = new System.Drawing.Size(123, 23);
            this.buttStopDirScan.TabIndex = 18;
            this.buttStopDirScan.Text = "Stop Scan";
            this.buttStopDirScan.UseVisualStyleBackColor = true;
            this.buttStopDirScan.Click += new System.EventHandler(this.buttStopDirScan_Click);
            // 
            // labelScanProgress
            // 
            this.labelScanProgress.AutoSize = true;
            this.labelScanProgress.Location = new System.Drawing.Point(6, 219);
            this.labelScanProgress.Name = "labelScanProgress";
            this.labelScanProgress.Size = new System.Drawing.Size(51, 13);
            this.labelScanProgress.TabIndex = 17;
            this.labelScanProgress.Text = "Progress:";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox4.Controls.Add(this.listFoundDirs);
            this.groupBox4.Location = new System.Drawing.Point(329, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 225);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Directories found (start cluster)";
            // 
            // listFoundDirs
            // 
            this.listFoundDirs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listFoundDirs.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFoundDirs.FormattingEnabled = true;
            this.listFoundDirs.ItemHeight = 11;
            this.listFoundDirs.Location = new System.Drawing.Point(3, 16);
            this.listFoundDirs.Name = "listFoundDirs";
            this.listFoundDirs.Size = new System.Drawing.Size(194, 206);
            this.listFoundDirs.TabIndex = 15;
            this.listFoundDirs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listFoundDirs_MouseDoubleClick);
            // 
            // buttScanAllDirs
            // 
            this.buttScanAllDirs.Location = new System.Drawing.Point(6, 66);
            this.buttScanAllDirs.Name = "buttScanAllDirs";
            this.buttScanAllDirs.Size = new System.Drawing.Size(123, 23);
            this.buttScanAllDirs.TabIndex = 1;
            this.buttScanAllDirs.Text = "Scan all directories";
            this.buttScanAllDirs.UseVisualStyleBackColor = true;
            this.buttScanAllDirs.Click += new System.EventHandler(this.buttScanAllDirs_Click);
            // 
            // buttScanSubdirs
            // 
            this.buttScanSubdirs.Location = new System.Drawing.Point(6, 37);
            this.buttScanSubdirs.Name = "buttScanSubdirs";
            this.buttScanSubdirs.Size = new System.Drawing.Size(123, 23);
            this.buttScanSubdirs.TabIndex = 0;
            this.buttScanSubdirs.Text = "Scan sub directories";
            this.toolTip1.SetToolTip(this.buttScanSubdirs, "Scan only directories that are \r\npointing back to the current \r\ndirectory in the " +
        "file browser");
            this.buttScanSubdirs.UseVisualStyleBackColor = true;
            this.buttScanSubdirs.Click += new System.EventHandler(this.buttScanSubdirs_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Backup dir:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Start From Cluster:";
            // 
            // numDirScanStartCluster
            // 
            this.numDirScanStartCluster.Location = new System.Drawing.Point(108, 11);
            this.numDirScanStartCluster.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numDirScanStartCluster.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numDirScanStartCluster.Name = "numDirScanStartCluster";
            this.numDirScanStartCluster.Size = new System.Drawing.Size(120, 20);
            this.numDirScanStartCluster.TabIndex = 19;
            this.numDirScanStartCluster.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttSaveDirList
            // 
            this.buttSaveDirList.Location = new System.Drawing.Point(6, 96);
            this.buttSaveDirList.Name = "buttSaveDirList";
            this.buttSaveDirList.Size = new System.Drawing.Size(123, 23);
            this.buttSaveDirList.TabIndex = 21;
            this.buttSaveDirList.Text = "Save Dir List";
            this.buttSaveDirList.UseVisualStyleBackColor = true;
            this.buttSaveDirList.Click += new System.EventHandler(this.buttSaveDirList_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 453);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tabCommander);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttOpen);
            this.Controls.Add(this.textOutFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboDrives);
            this.Name = "FormMain";
            this.Text = "Disk Recovery";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSector)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDataClusterSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRootEntrySize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRootDirStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFatSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFatStart)).EndInit();
            this.tabCommander.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabFileBrowser.ResumeLayout(false);
            this.tabFileBrowser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDirCluster)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDirScanStartCluster)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDrives;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textOutFolder;
        private System.Windows.Forms.Button buttOpen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox textDiskInfo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textSector;
        private System.Windows.Forms.NumericUpDown numSector;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttReadSector;
        private System.Windows.Forms.Button buttImage;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openImgFileDlg;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numDataClusterSize;
        private System.Windows.Forms.NumericUpDown numRootEntrySize;
        private System.Windows.Forms.NumericUpDown numRootDirStart;
        private System.Windows.Forms.NumericUpDown numFatSize;
        private System.Windows.Forms.Button buttGuessFatStart;
        private System.Windows.Forms.NumericUpDown numFatStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabCommander;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabFileBrowser;
        private System.Windows.Forms.ListBox listDirectory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numDirCluster;
        private System.Windows.Forms.Button buttReadDir;
        private System.Windows.Forms.Label labelCurDir;
        private System.Windows.Forms.CheckBox checkRecursive;
        private System.Windows.Forms.Button buttBkpDir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label labelScanProgress;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox listFoundDirs;
        private System.Windows.Forms.Button buttScanAllDirs;
        private System.Windows.Forms.Button buttScanSubdirs;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttStopDirScan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numDirScanStartCluster;
        private System.Windows.Forms.Button buttSaveDirList;
    }
}

