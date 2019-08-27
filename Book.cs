using System;
namespace GRVL
{
    public class Book
    {
        public string Title;
        public string Author;
        public string Status;
        public DateTime DueDate;

        public Book(string title, string author, string status)
        {
            this.Title = title;
            this.Author = author;
            this.Status = status;
        }
        public Book(string title, string author, string status, DateTime dueDate)
        {
            this.Title = title;
            this.Author = author;
            this.Status = status;
            this.DueDate = dueDate;
        }
    }
}