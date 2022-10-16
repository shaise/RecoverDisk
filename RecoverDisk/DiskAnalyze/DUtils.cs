using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecoverDisk.StorageAccess;

namespace RecoverDisk.DiskAnalyze
{
    public class DUtils
    {
        const string FatAttribs = "ADVSHR";
        static long ticks = DateTime.Now.Ticks;
        static long ticks100ms = TimeSpan.TicksPerMillisecond * 100;

        public static bool SequenceEqual(byte[] pat1, int offs1, byte[] pat2, int offs2, int len)
        {
            for (int i = 0; i < len; i++)
            {
                if (pat1[offs1] != pat2[offs2])
                    return false;
                offs1++;
                offs2++;
            }
            return true;
        }

        public static bool SequenceEqual(byte[] pat1, int offs1, string pat2)
        {
            for (int i = 0; i < pat2.Length; i++)
            {
                if (pat1[offs1] != pat2[i])
                    return false;
                offs1++;
            }
            return true;
        }

        public static int MatchPattern(byte[] sectorBuff, int seclen, byte[] matchBefore, byte[] matchAfter)
        {
            int endsearch = sectorBuff.Length - matchAfter.Length;
            for (int i = seclen; i < endsearch; i += seclen)
            {
                bool afterMatched = true;
                if (matchAfter != null)
                    afterMatched = SequenceEqual(sectorBuff, i, matchAfter, 0, matchAfter.Length);
                bool beforeMatched = true;
                if (matchBefore != null)
                    beforeMatched = SequenceEqual(sectorBuff, i - matchBefore.Length, matchBefore, 0, matchBefore.Length);
                if (beforeMatched && afterMatched)
                    return i / seclen;
            }
            return -1;
        }

        public static byte[] StrToByte(string txt)
        {
            byte[] res = new byte[txt.Length / 2];
            for (int i = 0; i < txt.Length; i += 2)
                res[i / 2] = (byte)int.Parse(txt.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            return res;
        }

        public static string FatAttribStr(int attr)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 6; i ++)
            {
                if ((attr & 0x20) != 0)
                    sb.Append(FatAttribs[i]);
                else
                    sb.Append('-');
                attr <<= 1;
            }
            return sb.ToString();
        }

        public static bool UpdatePeriodPassed()
        {
            long newticks = DateTime.Now.Ticks;
            if ((newticks - ticks) > ticks100ms)
            {
                ticks = newticks + ticks100ms;
                return true;
            }
            return false;
        }
    }
}
