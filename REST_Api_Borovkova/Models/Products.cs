using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RESTpr.Models
{
    public class Products
    {
        [Key]
        public int p_Id { get; set; }
        public string p_Name { get; set; }
        public int v_Id { get; set; }
        public int p_Quant { get; set; }
    }
}
