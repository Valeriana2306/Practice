using System.ComponentModel.DataAnnotations;

namespace RESTpr.Models
{
    public class Venders
    {
        [Key]
        public int v_Id { get; set; }
        public string v_Name { get; set; }
    }
}
