using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSConnect.Models.Masters

{
    public class tblleadscategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public string categoryname { get; set; } = "";
        public string description { get; set; } = "";
        public int status { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
    public class MyDtoMessage
    {
        public string? message { get; set; } = "";
    }
}

