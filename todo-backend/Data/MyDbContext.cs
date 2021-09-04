using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_backend.Models;

namespace todo_backend.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext (DbContextOptions<MyDbContext> option): base(option)
        {

        }

        public DbSet <TodoList> TodoLists { get; set; }
        public DbSet <Item> Items { get; set; }
    }
}
