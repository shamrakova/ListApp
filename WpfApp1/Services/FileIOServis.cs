using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.models;

namespace WpfApp1.Services
{
    internal class FileIOService
    {
        private readonly string Path;
        public FileIOService(string path)
        {
            Path = path;
        }
        public BindingList<toDoModel> LoadData()
        {
            var fileExists = File.Exists(Path);
            if (!fileExists)
            {
                File.CreateText(Path).Dispose();
                return new BindingList<toDoModel>();
            }
            using(var reader = File.OpenText(Path))
            {
                var fileText = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<toDoModel>>(fileText);
            }
        }
        public void SaveDate(object toDodata)
        {
            using(StreamWriter writer = File.CreateText(Path))
            {
                string output = JsonConvert.SerializeObject(toDodata);  
                writer.Write(output);   
            }
            
        }
    }
}
