using ChildBuilderExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderExample
{
    public class Blog
    {
        public string[] Categories { get; set; }
        public string[] Tags { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
    }

    //public class Category
    //{
    //    public string Name { get; set; }

    //    public string Description { get; set; }
    //}

    public class BlogBuilder
    {
        private Blog Blog { get; set; }

        public BlogBuilder()
        {
            Blog = new Blog();
        }

        public BlogBuilder WithTitle(string title)
        {
            Blog.Title = title;
            return this;
        }

        public BlogBuilder WithContent(string content)
        {
            Blog.Content = content;
            return this;
        }

        public BlogBuilder WithAuthor(string author)
        {
            Blog.Author = author;
            return this;
        }

        public BlogBuilder WithTags(params string[] tags)
        {
            Blog.Tags = tags;
            return this;
        }

        public BlogBuilder WithCategories(params string[] categories)
        {
            Blog.Categories = categories;
            return this;
        }

        public Blog Build()
        {
            return Blog;
        }
    }
}
