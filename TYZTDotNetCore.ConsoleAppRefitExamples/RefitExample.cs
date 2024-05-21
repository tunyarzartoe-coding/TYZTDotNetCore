using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TYZTDotNetCore.ConsoleAppRefitExamples
{
    internal class RefitExample
    {
        private readonly IBlogApi _service = RestService.For<IBlogApi>("https://localhost:7186");

        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(7);
            //await EditAsync(60);
            //await CreateAsync("refit title", "refit author", "refit content");
            //await UpdateAsync(7,"update title", "update author", "update refit content");
            await DeleteAsync(7);

        }

        private async Task ReadAsync()
        {
            var lst = await _service.GetBlogs();
            foreach (var item in lst)
            {
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
        }

        private async Task EditAsync(int id)
        {
            // Refit.ApiException: 'Response status code does not indicate success: 404 (Not Found).'
            try
            {
                var item = await _service.GetBlog(id);
                Console.WriteLine($"Id => {item.BlogId}");
                Console.WriteLine($"Title => {item.BlogTitle}");
                Console.WriteLine($"Author => {item.BlogAuthor}");
                Console.WriteLine($"Content => {item.BlogContent}");
                Console.WriteLine("---------------------------------");
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.StatusCode.ToString());
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            var message = await _service.CreateBlog(blog);
            Console.WriteLine(message);
        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            var message = await _service.UpdateBlog(id, blog);
            Console.WriteLine(message);
        }

        private async Task DeleteAsync(int id)
        {
            var message = await _service.DeleteBlog(id);
            Console.WriteLine(message);
        }
    }
}
