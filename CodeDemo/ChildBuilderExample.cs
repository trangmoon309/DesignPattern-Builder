using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChildBuilderExample
{
    public class Blog
    {
        public List<string> Tags { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

        public Category Category { get; set; } = new Category();
    }

    public class Category
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public CategoryChild CategoryChild { get; set; }
    }

    public class CategoryChild
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

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

        public CategoryBuilder AddCategory()
        {
            return new CategoryBuilder(this, Blog);
        }

        public BlogBuilder AddCategory(Action<CategoryBuilder> categoryBuilder)
        {
            var category = new Category();
            categoryBuilder.Invoke(new CategoryBuilder(category));
            Blog.Category = category;
            return this;
        }

        public Blog Build()
        {
            return Blog;
        }
    }

    public class CategoryBuilder
    {
        private Blog Blog { get; set; }

        private Category Category { get; set; } = new Category();

        private BlogBuilder ParentBuilder { get; set; }

        public CategoryBuilder(Category category)
        {
            Category = category;
        }

        public CategoryBuilder(BlogBuilder parentBuilder, Blog blog)
        {
            ParentBuilder = parentBuilder;
            Blog = blog;
        }

        public CategoryBuilder WithName(string name)
        {
            Category.Name = name;
            return this;
        }

        public CategoryBuilder WithDescription(string description)
        {
            Category.Description = description;
            return this;
        }


        public CategoryBuilder AddCategoryChild(Action<CategoryChildBuilder> categoryBuilder)
        {
            var category = new CategoryChild();
            categoryBuilder.Invoke(new CategoryChildBuilder(category));
            Category.CategoryChild = category;
            return this;
        }

        public BlogBuilder Build()
        {
            Blog.Category = Category;
            return ParentBuilder;
        }
    }

    public class CategoryChildBuilder
    {
        private CategoryChild CategoryChild { get; set; } = new CategoryChild();

        public CategoryChildBuilder(CategoryChild category)
        {
            CategoryChild = category;
        }

        public CategoryChildBuilder WithName(string name)
        {
            CategoryChild.Name = name;
            return this;
        }

        public CategoryChildBuilder WithDescription(string description)
        {
            CategoryChild.Description = description;
            return this;
        }
    }
}
