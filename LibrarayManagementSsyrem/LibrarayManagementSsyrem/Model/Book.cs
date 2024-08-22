using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarayManagementSsyrem.Model
{
    public class Book
    {
        //Book Code
        public int BookCode;

        //Book Title
        public string Title { get; set; }

        //Book Author
        public string Author { get; set; }

        //Book Genre
        public string Genre { get; set; }

        //Book Price
        public int Price { get; set; }

        //Default Constructor
        public Book()
        {
            
        }


        // Parameterized Constructor
        public Book(string title, string author, string genre, int price)
        {
            this.Title = title;
            this.Author = author;
            this.Genre = genre;
            this.Price = price;
        }

    }
}
