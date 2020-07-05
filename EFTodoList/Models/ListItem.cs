using EFTodoList.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFTodoList.Models
{
    public class ToDoListItem
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Order")]
        public int ListItemOrder { get; set; }
        public string Description { get; set; }
        [Display(Name = "Completion Status")]
        public bool IsComplete { get; set; }

        public ToDoListItem(int listItemOrder, string description, bool isComplete)
        {
            ListItemOrder = listItemOrder;
            Description = description;
            IsComplete = isComplete;
        }

        public ToDoListItem()
        {
            ListItemOrder = 0;
            Description = "";
            IsComplete = false;
        }
    }
}
