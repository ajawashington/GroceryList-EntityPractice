using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models.ViewModels
{
    public class TodoListOptions
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int ToDoStatusId { get; set; }
        public List<SelectListItem> StatusOptions { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
