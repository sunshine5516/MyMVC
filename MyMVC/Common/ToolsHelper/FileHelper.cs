using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public class FileHelper
    {
        // Common.FileHelper
        public static DataTable GetAllFileTable(string Path)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("name", typeof(string));
            dataTable.Columns.Add("ext", typeof(string));
            dataTable.Columns.Add("size", typeof(string));
            dataTable.Columns.Add("icon", typeof(string));
            dataTable.Columns.Add("isfolder", typeof(bool));
            dataTable.Columns.Add("isImage", typeof(bool));
            dataTable.Columns.Add("fullname", typeof(string));
            dataTable.Columns.Add("path", typeof(string));
            dataTable.Columns.Add("time", typeof(DateTime));
            string[] directories = Directory.GetDirectories(Path, "*", SearchOption.AllDirectories);
            List<string> list = new List<string>
    {
        Path
    };
            if (directories != null && directories.Count<string>() > 0)
            {
                string[] array = directories;
                for (int i = 0; i < array.Length; i++)
                {
                    string item = array[i];
                    list.Add(item);
                }
            }
            foreach (string current in list)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(current);
                string value = string.Empty;
                string text = string.Empty;
                string value2 = string.Empty;
                string value3 = string.Empty;
                string value4 = string.Empty;
                string value5 = string.Empty;
                bool flag = false;
                try
                {
                    FileInfo[] files = directoryInfo.GetFiles();
                    for (int j = 0; j < files.Length; j++)
                    {
                        FileSystemInfo fileSystemInfo = files[j];
                        FileInfo fileInfo = (FileInfo)fileSystemInfo;
                        value = fileInfo.Name.Substring(0, fileInfo.Name.LastIndexOf('.'));
                        value4 = fileInfo.Name;
                        text = fileInfo.Extension.ToLower();
                        value2 = FileHelper.GetDiyFileSize(fileInfo);
                        DateTime lastWriteTime = fileInfo.LastWriteTime;
                        value3 = FileHelper.GetFileIcon(text);
                        bool flag2 = FileHelper.IsImageFile(text.Substring(1, text.Length - 1));
                        value5 = FileHelper.urlconvertor(fileInfo.FullName);
                        DataRow dataRow = dataTable.NewRow();
                        dataRow["name"] = value;
                        dataRow["fullname"] = value4;
                        dataRow["ext"] = text;
                        dataRow["size"] = value2;
                        dataRow["time"] = lastWriteTime;
                        dataRow["icon"] = value3;
                        dataRow["isfolder"] = flag;
                        dataRow["isImage"] = flag2;
                        dataRow["path"] = value5;
                        dataTable.Rows.Add(dataRow);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return dataTable;
        }
        // Common.FileHelper
        public static decimal GetDiyFileSize(long Length, out string unit)
        {
            unit = string.Empty;
            decimal result;
            if (Length < 1024L)
            {
                result = Length;
                unit = "byte";
            }
            else
            {
                if (Length > 1024L && Length < 1048576L)
                {
                    result = Math.Round(FileHelper.GetFileSizeByKB(Length), 2);
                    unit = "KB";
                }
                else
                {
                    if (Length > 1048576L && Length < 1073741824L)
                    {
                        result = Math.Round(FileHelper.GetFileSizeByMB(Length), 2);
                        unit = "MB";
                    }
                    else
                    {
                        result = Math.Round(FileHelper.GetFileSizeByGB(Length), 2);
                        unit = "GB";
                    }
                }
            }
            return result;
        }
        // Common.FileHelper
        public static string GetDiyFileSize(FileInfo fi)
        {
            string result = string.Empty;
            if (fi.Length < 1024L)
            {
                result = fi.Length.ToString() + "byte";
            }
            else
            {
                if (fi.Length > 1024L && fi.Length < 1048576L)
                {
                    result = Math.Round(FileHelper.GetFileSizeByKB(fi.Length), 2).ToString() + "KB";
                }
                else
                {
                    if (fi.Length > 1048576L && fi.Length < 1073741824L)
                    {
                        result = Math.Round(FileHelper.GetFileSizeByMB(fi.Length), 2).ToString() + "MB";
                    }
                    else
                    {
                        result = Math.Round(FileHelper.GetFileSizeByGB(fi.Length), 2).ToString() + "GB";
                    }
                }
            }
            return result;
        }

        // Common.FileHelper
        public static decimal GetFileSizeByKB(long filelength)
        {
            return Convert.ToDecimal(filelength) / 1024m;
        }
        // Common.FileHelper
        public static decimal GetFileSizeByGB(long filelength)
        {
            return Convert.ToDecimal(Convert.ToDecimal(Convert.ToDecimal(filelength / 1024L) / 1024m) / 1024m);
        }
        // Common.FileHelper
        public static decimal GetFileSizeByMB(long filelength)
        {
            return Convert.ToDecimal(Convert.ToDecimal(filelength / 1024L) / 1024m);
        }

        // Common.FileHelper
        public static string GetFileIcon(string _fileExt)
        {
            List<string> list = (
                from p in ConfigurationManager.AppSettings["Image"].Trim(new char[]
                {
            ','
                }).Split(new string[]
                {
            ","
                }, StringSplitOptions.RemoveEmptyEntries)
                select p).ToList<string>();
            List<string> list2 = (
                from p in ConfigurationManager.AppSettings["Video"].Trim(new char[]
                {
            ','
                }).Split(new string[]
                {
            ","
                }, StringSplitOptions.RemoveEmptyEntries)
                select p).ToList<string>();
            List<string> list3 = (
                from p in ConfigurationManager.AppSettings["Music"].Trim(new char[]
                {
            ','
                }).Split(new string[]
                {
            ","
                }, StringSplitOptions.RemoveEmptyEntries)
                select p).ToList<string>();
            if (list.Contains(_fileExt.ToLower().Remove(0, 1)))
            {
                return "fa fa-image";
            }
            if (list2.Contains(_fileExt.ToLower().Remove(0, 1)))
            {
                return "fa fa-film";
            }
            if (list3.Contains(_fileExt.ToLower().Remove(0, 1)))
            {
                return "fa fa-music";
            }
            string key;
            switch (key = _fileExt.ToLower())
            {
                case ".doc":
                case ".docx":
                    return "fa fa-file-word-o";
                case ".xls":
                case ".xlsx":
                    return "fa fa-file-excel-o";
                case ".ppt":
                case ".pptx":
                    return "fa fa-file-powerpoint-o";
                case ".pdf":
                    return "fa fa-file-pdf-o";
                case ".txt":
                    return "fa fa-file-text-o";
                case ".zip":
                case ".rar":
                    return "fa fa-file-zip-o";
            }
            return "fa fa-file";
        }
        // Common.FileHelper
        private static bool IsImageFile(string _fileExt)
        {
            List<string> list = (
                from p in ConfigurationManager.AppSettings["Image"].Trim(new char[]
                {
            ','
                }).Split(new string[]
                {
            ","
                }, StringSplitOptions.RemoveEmptyEntries)
                select p).ToList<string>();
            return list.Contains(_fileExt.ToLower());
        }
        // Common.FileHelper
        private static string urlconvertor(string Url)
        {
            string oldValue = HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath.ToString());
            string text = Url.Replace(oldValue, "");
            text = text.Replace("\\", "/");
            return "/" + text;
        }
        /// <summary>
        /// 读取指定位置文件列表到集合中
        /// </summary>
        /// <param name="Path">指定路径</param>
        /// <returns></returns>
        public static DataTable GetFileTable(string Path)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("ext", typeof(string));
            dt.Columns.Add("size", typeof(string));
            dt.Columns.Add("icon", typeof(string));
            dt.Columns.Add("isfolder", typeof(bool));
            dt.Columns.Add("isImage", typeof(bool));
            dt.Columns.Add("fullname", typeof(string));
            dt.Columns.Add("path", typeof(string));
            dt.Columns.Add("time", typeof(DateTime));

            DirectoryInfo dirinfo = new DirectoryInfo(Path);
            FileInfo fi;
            DirectoryInfo dir;
            string FileName = string.Empty, FileExt = string.Empty, FileSize = string.Empty, FileIcon = string.Empty, FileFullName = string.Empty, FilePath = string.Empty;
            bool IsFloder = false, IsImage = false;
            DateTime FileModify;
            try
            {
                foreach (FileSystemInfo fsi in dirinfo.GetFileSystemInfos())
                {
                    if (fsi is FileInfo)
                    {
                        fi = (FileInfo)fsi;
                        //获取文件名称
                        FileName = fi.Name.Substring(0, fi.Name.LastIndexOf('.'));
                        FileFullName = fi.Name;
                        //获取文件扩展名
                        FileExt = fi.Extension;
                        //获取文件大小
                        FileSize = GetDiyFileSize(fi);
                        //获取文件最后修改时间
                        FileModify = fi.LastWriteTime;
                        //文件图标
                        FileIcon = GetFileIcon(FileExt);
                        //是否为图片
                        IsImage = IsImageFile(FileExt.Substring(1, FileExt.Length - 1));
                        //文件路径
                        FilePath = urlconvertor(fi.FullName);
                    }
                    else
                    {
                        dir = (DirectoryInfo)fsi;
                        //获取目录名
                        FileName = dir.Name;
                        //获取目录最后修改时间
                        FileModify = dir.LastWriteTime;
                        //设置目录文件为文件夹
                        FileExt = "folder";
                        //文件夹图标
                        FileIcon = "fa fa-folder";
                        IsFloder = true;
                        //文件路径
                        FilePath = urlconvertor(dir.FullName);

                    }
                    DataRow dr = dt.NewRow();
                    dr["name"] = FileName;
                    dr["fullname"] = FileFullName;
                    dr["ext"] = FileExt;
                    dr["size"] = FileSize;
                    dr["time"] = FileModify;
                    dr["icon"] = FileIcon;
                    dr["isfolder"] = IsFloder;
                    dr["isImage"] = IsImage;
                    dr["path"] = FilePath;
                    dt.Rows.Add(dr);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            return dt;
        }
        // Common.FileHelper
        public static bool IsExistDirectory(string Path)
        {
            return Directory.Exists(Path);
        }
        // Common.FileHelper
        public static bool IsEmptyDirectory(string directoryPath)
        {
            bool result;
            try
            {
                string[] fileNames = FileHelper.GetFileNames(directoryPath);
                if (fileNames.Length > 0)
                {
                    result = false;
                }
                else
                {
                    string[] directories = FileHelper.GetDirectories(directoryPath);
                    if (directories.Length > 0)
                    {
                        result = false;
                    }
                    else
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = true;
            }
            return result;
        }
        // Common.FileHelper
        public static string GetFileName(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.Name;
        }
        // Common.FileHelper
        public static string[] GetFileNames(string directoryPath)
        {
            if (!FileHelper.IsExistDirectory(directoryPath))
            {
                throw new FileNotFoundException();
            }
            return Directory.GetFiles(directoryPath);
        }
        // Common.FileHelper
        public static string[] GetDirectories(string directoryPath)
        {
            string[] directories;
            try
            {
                directories = Directory.GetDirectories(directoryPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return directories;
        }
        // 删除文件
        public static void DeleteFile(string filePath)
        {
            if (FileHelper.IsExistFile(filePath))
            {
                File.Delete(filePath);
            }
        }

        // Common.FileHelper
        public static void Copy(string sourceFilePath, string descDirectoryPath)
        {
            File.Copy(sourceFilePath, descDirectoryPath, true);
        }

        // 文件是否存在
        public static bool IsExistFile(string filePath)
        {
            return File.Exists(filePath);
        }

        // Common.FileHelper
        public static void Move(string sourceFilePath, string descDirectoryPath)
        {
            string fileName = FileHelper.GetFileName(sourceFilePath);
            if (FileHelper.IsExistDirectory(descDirectoryPath))
            {
                if (FileHelper.IsExistFile(descDirectoryPath + "\\" + fileName))
                {
                    FileHelper.DeleteFile(descDirectoryPath + "\\" + fileName);
                    return;
                }
                File.Move(sourceFilePath, descDirectoryPath + "\\" + fileName);
            }
        }

    }
}
