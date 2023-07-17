using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common
{
    public class FilesINI
    {
        // 声明INI文件的写操作函数 WritePrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // 声明INI文件的读操作函数 GetPrivateProfileString()
        [System.Runtime.InteropServices.DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, System.Text.StringBuilder retVal, int size, string filePath);


        /// <summary>
        /// 写入INI的方法
        /// </summary>
        /// <param name="section">配置节点名称</param>
        /// <param name="key">键名</param>
        /// <param name="value">返回键值</param>
        /// <param name="path">路径</param>
        public static void INIWrite(string section, string key, string value, string path)
        {
            WritePrivateProfileString(section, key, value, path);
        }

        /// <summary>
        /// 读取INI的方法
        /// </summary>
        /// <param name="section">配置节点名称</param>
        /// <param name="key">键名</param>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static string INIRead(string section, string key, string path)
        {
            // 每次从ini中读取多少字节
            System.Text.StringBuilder temp = new System.Text.StringBuilder(255);
            GetPrivateProfileString(section, key, "", temp, 255, path);
            return temp.ToString();

        }


    }
}
