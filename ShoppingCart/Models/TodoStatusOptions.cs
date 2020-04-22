using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class TodoListOptions
    {

        public int TodoStatusId { get; set; }

        public int ApplicationUserId { get; set; }


        public List<SelectListItem> StatusOptions { get; set; }
    }
}
