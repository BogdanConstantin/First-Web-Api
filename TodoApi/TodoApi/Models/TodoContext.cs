using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }

    public class Singleton
    {
        private static Singleton instance;
        private System.Collections.Generic.List<TodoItem> ListItem;

        private Singleton()
        {
            try
            {
                ListItem = new System.Collections.Generic.List<TodoItem>();
            }
            catch { }
        

        }

        public static Singleton Instance
        {
            get
            {
                if(instance==null)
                    instance=new Singleton();
                return instance;
            }
        }

        public List<TodoItem> getAll()
        {
            return ListItem;
        }

        public void add(TodoItem item)
        {
            ListItem.Add(item);
        }
    }
}
