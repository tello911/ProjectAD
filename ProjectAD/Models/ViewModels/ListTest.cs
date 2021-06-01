using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectAD.Models.ViewModels;

namespace ProjectAD.Models.ViewModels
{
    public class ListTest
    {
        public int Id { get; set; }
        public static List<Test> _tests = null;
        public List<Test> tests { 
            get 
            {
                if (_tests == null)
                {
                    _tests = new List<Test>();
                }
                return _tests;
            }
            set
            {
                _tests = null;
            }
        }        


    }
}