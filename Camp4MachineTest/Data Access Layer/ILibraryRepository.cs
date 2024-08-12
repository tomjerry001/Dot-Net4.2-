using LibraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camp4MachineTest.Data_Access_Layer
{
    public interface ILibraryRepository
    {
        Dictionary<string,Book> LoadBooks();

        void SaveBooks(Dictionary<string, Book> books);
    }
}
