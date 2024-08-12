using LibraryManagementSystem;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Camp4MachineTest.Data_Access_Layer
{
    public class LibraryRepositoryImpl : ILibraryRepository
    {
        private const string jsonFilePath = "library.json";

        public Dictionary<string, Book> LoadBooks()
        {
            string jsonData = File.ReadAllText(jsonFilePath);   
            return JsonConvert.DeserializeObject<Dictionary<string, Book>>(jsonData);    
        }


        public void SaveBooks(Dictionary<string, Book> books)
        {
            string jsonData = JsonConvert.SerializeObject(books, Formatting.Indented);
            File.WriteAllText(jsonFilePath, jsonData);
        }
    }
}
