// See https://aka.ms/new-console-template for more information
using TYZTDotNetCore.ConsoleAppEFCore.Databases.Models;

Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
var lst = db.TblPieCharts.ToList();

Console.WriteLine(lst.Count);

Console.ReadLine();