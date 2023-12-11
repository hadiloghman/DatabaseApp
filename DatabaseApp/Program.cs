using DatabaseApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;

static void LooadingBlogsByEagerLoading()
{
    using(var db = new BlogDB())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        var lst = db.Blogs.Include(b => b.Posts).ToList();
        foreach(var item in lst)
        {
            Console.WriteLine($"Blog '{item.Title}' has {item.Posts.Count} posts.");
        }
    }
}

static void LooadingBlogsByLazyLoading()
{
    using (var db = new BlogDBLazy())
    {
        var loggerFactory = db.GetService<ILoggerFactory>();
        loggerFactory.AddProvider(new ConsoleLoggerProvider());

        var lst = db.Blogs.ToList();
        foreach (var item in lst)
        {
            Console.WriteLine($"Blog '{item.Title}' has {item.Posts.Count} posts.");
        }
    }
}

Console.WriteLine("*************************Eager Loading***********************");
LooadingBlogsByEagerLoading();
Console.WriteLine("************************************************");

Console.WriteLine("*************************Lazy Loading***********************");
LooadingBlogsByLazyLoading();
Console.WriteLine("************************************************");
