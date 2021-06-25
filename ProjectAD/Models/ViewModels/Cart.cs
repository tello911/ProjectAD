using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectAD.Models.ViewModels
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public Cart()
        {
            Id = 0;
            Name = "";
            Count = 0;
        }

        public Cart(int id, string name, int count)
        {
            Id = id;
            Name = name;
            Count = count;
        }
    }
}