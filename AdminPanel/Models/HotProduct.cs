using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminPanel.Models
{
    public class HotProduct
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Stok_No { get; set; }
        public string Fiyat_No { get; set; }
        public string Adet_No { get; set; }
       
        [AllowHtml]
        public string Info { get; set; }

        public int rlt_Product_Group_Id { get; set; }

        [ForeignKey("rlt_Product_Group_Id")]
        public virtual HotProduct_Group HotProduct_Groups { get; set; }

    }
}