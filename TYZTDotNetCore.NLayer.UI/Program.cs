// See https://aka.ms/new-console-template for more information
using System.Xml;
using TYZTDotNetCore.NLayer.BusinessLogic.Services;

Console.WriteLine("Hello, World!");

BL_Blog bL_Blog = new BL_Blog();
var lst = bL_Blog.GetBlogs();
//Console.WriteLine(lst);
foreach (var blog in lst)
{
    Console.WriteLine($"Blog Title: {blog.BlogTitle}");
    Console.WriteLine($"Blog Author: {blog.BlogAuthor}");
    Console.WriteLine($"Content: {blog.BlogContent}");
    Console.WriteLine(new string('-', 20));
}

Console.ReadLine();