using System.Reflection.Metadata;
using ZackDotNet.RestApiWithNLayer.Db;

namespace ZackDotNet.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContent _content;
        public DA_Blog()
        {
            _content = new AppDbContent();      
        }
        public List<BlogModel> GetBlogs()
        {
            var lst = _content.Blogs.ToList();
            return lst;
        }
        public BlogModel GetBlog(int id)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            return item!;
        }
        public int CreateBlog(BlogModel requestModel)
        {
            _content.Blogs.Add(requestModel);
            var result = _content.SaveChanges();
            return result;
        }
        public int UpdateBlog(int id,BlogModel requestModel)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item == null)
            {
                return 0;
            }
            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            var result = _content.SaveChanges();
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return 0;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }

            var result = _content.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _content.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                return 0;
            }
            _content.Blogs.Remove(item);
            var result = _content.SaveChanges();
            return result;
        }
    }
}
