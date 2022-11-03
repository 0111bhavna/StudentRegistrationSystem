using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppLibraries.Models
{
    public class Result
    {
        public int ResultId { get; set; }
        public Subject Subject { get; set; }
        public Grade Grade { get; set; }
    }

}