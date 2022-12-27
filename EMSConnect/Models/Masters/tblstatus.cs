using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSConnect.Models.Masters
{
    public class tblstatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public string? name { get; set; } = "";
        public string? description { get; set; } = "";
        public int field1 { get; set; }
        public string? field1value { get; set; } = "";
        public int field2 { get; set; }
        public string? field2value { get; set; } = "";
        public int field3 { get; set; }
        public string? field3value { get; set; } = "";
        public string? type { get; set; } = "";
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
    }
    public class Mydtostatus
        {
        public int id { get; set; }
        public string? name { get; set; } = "";
        public string? description { get; set; } = "";
        public int field1 { get; set; }
        public string? field1value { get; set; } = "";
        public int field2 { get; set; }
        public string? field2value { get; set; } = "";
        public int field3 { get; set; }
        public string? field3value { get; set; } = "";
        public string? type { get; set; } = "";
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }


    }
    public class Mydtomessage
    {
        public string? message { get; set; } = "";
    }
}
