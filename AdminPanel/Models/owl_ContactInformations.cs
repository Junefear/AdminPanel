using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Models
{
    public class owl_ContactInformations
    {
        [Key]
        public int Id { get; set; }

        [AllowHtml]
        public string Info { get; set; }

        public string Address { get; set; }
        public string Phone_Name { get; set; }
        public string Phone_No { get; set; }
        public string Fax { get; set; }
        public string Mail_Name { get; set; }
        public string Mail_Address { get; set; }

    }
}