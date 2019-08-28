using System;
using System.Collections.Generic;
using System.Text;
namespace GRVL
{
    public class BookManager
    {
        public BookManager()
        {
        }
        public string Checkout(Book book)
        {
            book.DueDate = DateTime.Now.AddDays(14);
            book.Status = "Checked out";
            return ($"Thanks for checking out {book.Title}. {book.Title} is due back {book.DueDate}");
        }

        public string ReturnBook(Book book)
        {
            book.Status = "Available";
            return ($"Thanks for returning {book.Title}");
        }
    }
}
