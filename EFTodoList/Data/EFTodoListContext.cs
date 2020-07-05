using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFTodoList.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFTodoList.Data
{
    public class EFTodoContext : DbContext
    {
        public static DatabaseFacade DBFacade;
        public EFTodoContext(DbContextOptions<EFTodoContext> options)
            : base(options)
        {
            DBFacade = Database;
            this.Database.EnsureCreated();
            if (ToDoListItems.Count() == 0)
            {
                var ListItems = new List<ToDoListItem>
      {
            new ToDoListItem(0,"Open Visual Studio",true ),
            new ToDoListItem(1,"Create a new project",true ),
            new ToDoListItem(2,"Choose ASP.NET Core Web Application",true ),
            new ToDoListItem(3,"Name the project",true ),
            new ToDoListItem(4,"Choose .NET Core",true ),
            new ToDoListItem(5,"Choose  ASP.NET Core 3.1",true ),
            new ToDoListItem(6,"Choose MVC Web Application",true ),
            new ToDoListItem(7,"Design a Todo List",true ),
            new ToDoListItem(8,"Implement a Todo List using scaffolding",true ),
            new ToDoListItem(9,"Add list items for testing and examples",true ),
            new ToDoListItem(10,"Test the new Todo List ",true ),
            new ToDoListItem(11,"Push the new Web Application to gitHub",true ),
            new ToDoListItem(12,"Get hired by Priority1",false )
      };
                ListItems.ForEach(s => this.ListItem.Add(s));
                SaveChanges();
            }
        }
        public DbSet<ToDoListItem> ToDoListItems { get; set; }
        public DbSet<EFTodoList.Models.ToDoListItem> ListItem { get; set; }
    }
}
