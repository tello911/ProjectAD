using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectAD.Models.ViewModels
{
    public class ListCart
    {
        public int Id { get; set; }
        public static List<Cart> _carts = null;
        public List<Cart> carts
        {
            get
            {
                if (_carts == null)
                {
                    _carts = new List<Cart>();
                }
                return _carts;
            }
            set
            {
                _carts = null;
            }
        }
    }
}