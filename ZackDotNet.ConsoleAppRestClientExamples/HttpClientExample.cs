using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ZackDotNet.ConsoleAppRestClientExamples
{
    internal class HttpClientExample
    {
        private readonly RestClient _client = new RestClient("https://localhost:7186");
        private readonly string _blogEndPoint = "api/blog";
        public async Task RunAsync()
        {
            //await ReadAsync();
            //await EditAsync(6);
            //await EditAsync(100);
            await DeleteAsync(6);
            //await CreateAsync("title bla", "author bla", "content bla");
            // await UpdateAsync(6, "title bla", "author bla", "content bla");
            await PatchAsync(23, null!, "author  Updated", null!);


        }
        private async Task ReadAsync()
        {
            RestRequest request = new RestRequest(_blogEndPoint, Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;
                foreach (var item in lst)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(item));
                    Console.WriteLine($"Id =>{item.BlogId}");
                    Console.WriteLine($"Title =>{item.BlogTitle}");
                    Console.WriteLine($"Author =>{item.BlogAuthor}");
                    Console.WriteLine($"Content =>{item.BlogContent}");

                }
            }
        }

        private async Task EditAsync(int id)
        {
            RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Get);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                var item = JsonConvert.DeserializeObject<BlogDto>(jsonStr)!;

                Console.WriteLine(JsonConvert.SerializeObject(item));
                Console.WriteLine($"Id =>{item.BlogId}");
                Console.WriteLine($"Title =>{item.BlogTitle}");
                Console.WriteLine($"Author =>{item.BlogAuthor}");
                Console.WriteLine($"Content =>{item.BlogContent}");


            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task CreateAsync(string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };//c# object 

            var restRequest = new RestRequest(_blogEndPoint, Method.Post);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }

        }

        private async Task UpdateAsync(int id, string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };//c# object 

            var restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Put);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);
            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }

        }

        private async Task PatchAsync(int id, string title, string author, string content)
        {
            BlogDto blogDto = new BlogDto();

            if (!string.IsNullOrEmpty(title))
                blogDto.BlogTitle = title;

            if (!string.IsNullOrEmpty(author))
                blogDto.BlogAuthor = author;

            if (!string.IsNullOrEmpty(content))
                blogDto.BlogContent = content;

            // Convert object to JSON
            var restRequest = new RestRequest($"{_blogEndPoint}/{id}", Method.Patch);
            restRequest.AddJsonBody(blogDto);
            var response = await _client.ExecuteAsync(restRequest);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }

        private async Task DeleteAsync(int id)
        {
            RestRequest request = new RestRequest($"{_blogEndPoint}/{id}", Method.Delete);
            var response = await _client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
            else
            {
                string message = response.Content!;
                Console.WriteLine(message);
            }
        }
    }
}
