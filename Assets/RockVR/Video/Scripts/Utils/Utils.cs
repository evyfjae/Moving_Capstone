using System;
using System.Linq;

namespace RockVR.Video
{
    public class StringUtils
    {
        public static string GetTimeString()
        {
            //return "6-3-1";
            return DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }

        public static string GetRandomString(int length)
        {
            return "test";
/*            System.Random random = new System.Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());*/
        }

        public static string GetMp4FileName(string name)
        {
            return GetTimeString() + ".mp4";
            //return GetTimeString() + (name == null ? "" : "-") + name + "6-3-2.mp4";
        }

        public static string GetH264FileName(string name)
        {
            return GetTimeString() + ".h264";
            //return GetTimeString() + (name == null ? "" : "-") + name + ".h264";
        }

        public static string GetWavFileName(string name)
        {
            return GetTimeString() + ".wav";
            //return GetTimeString() + (name == null ? "" : "-") + name + ".wav";
        }

        public static string GetPngFileName(string name)
        {
            return GetTimeString() + ".png";
            //return GetTimeString() + (name == null ? "" : "-") + name + ".png";
        }

        public static string GetJpgFileName(string name)
        {
            return GetTimeString() + ".jpg";
            //return GetTimeString() + (name == null ? "" : "-") + name + ".jpg";
        }

        public static bool IsRtmpAddress(string str)
        {
            return (str != null && str.StartsWith("rtmp"));
        }
    }

    public class MathUtils
    {
        public static bool CheckPowerOfTwo(int input)
        {
            return (input & (input - 1)) == 0;
        }
    }
}