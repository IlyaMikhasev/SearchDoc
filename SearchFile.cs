using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDoc
{
    internal class SearchFile
    {
        private string[] _arrIndification=new string[30];
        private DateTime _dateStartSearch;

        public SearchFile((string[] arr, DateTime date) values) {
            _arrIndification = values.arr;
            _dateStartSearch = values.date;
        }
        public string SearchFilePath() {
            string path=string.Empty;
            string myDoc = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string myDesctop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string applData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string[] folders = { myDoc, myDesctop, applData };
            foreach (var item in folders)
            {
                try
                {
                    foreach (var filename in Directory.EnumerateFiles(item,"*.txt", SearchOption.AllDirectories)) {
                        StreamReader streamReader = new StreamReader(filename);
                        FileInfo fileInfo = new FileInfo(filename);
                        DateTime timeOfModify = fileInfo.LastWriteTime;
                        DateTime timeOfСreate = fileInfo.CreationTime;
                        if (timeOfСreate >= _dateStartSearch | timeOfModify >= _dateStartSearch) {
                            foreach (var key in _arrIndification) {
                                if (filename.Contains(key))
                                    return filename;                        
                            }                    
                        }                    
                    }                

                }
                catch (Exception ex)
                {

                    Console.WriteLine( $"Ошибка: {ex.Message}");
                }
            }
            return path;
        }
    }
}
