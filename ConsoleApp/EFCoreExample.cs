using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZackDotNet.ConsoleApp
{
    internal class EFCoreExample
    {
        private readonly AppDbContent db = new AppDbContent();

        public void Run() 
        {
            //Read();
            //Edit(13);
            //Create("title 100", "author 100", "content 100");
            //Update(15, "title updated", "author updated", "content updated");
            Delete(12);
        }
        private void Read()
        {
            var lst =db.Blogs.ToList();
            foreach (BlogDto item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

                Console.WriteLine("------------------------------");
            }
        }
        private void Edit(int id)
        {
           var item =  db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.Write("No data found!");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

            Console.WriteLine("------------------------------");
        }
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item); 
            int result = db.SaveChanges();

            string message = result > 0 ? "Saving Success." : "Saving Failed.";
            Console.WriteLine(message);
        }
        private void Update(int id,string title, string author, string content)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.Write("No data found!");
                return;
            }
            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
        
            int result = db.SaveChanges();

            string message = result > 0 ? "Updating Success." : "Updating Failed.";
            Console.WriteLine(message);
        }
        private void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.Write("No data found!");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleting Success." : "Deleting Failed.";
            Console.WriteLine(message);

        }
    }
}
