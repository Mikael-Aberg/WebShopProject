using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebShopProject.Models
{
    public class Format
    {
        public int Id { get; set; }
        [DisplayName("Format")]
        public string FormatName { get; set; }
    }
}