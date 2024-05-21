// See https://aka.ms/new-console-template for more information
using System.ComponentModel.DataAnnotations;

public class BlogDto
{
    [Key]
    public int BlogId { get; set; }
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }


}