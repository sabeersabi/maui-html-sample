using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSConnect.Models.Masters
{
    public class tblleads
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public int status { get; set; }
        public int leadscategoryid { get; set; }
        public int employeeid { get; set; }
        public string? leadsname { get; set; } = "";
        public int mobile1 { get; set; }
        public string? source { get; set; } = "";
        public DateTime? enquirydate { get; set; }
        public DateTime? discussiondate { get; set; }
        public string address { get; set; } = "";
        public DateTime? followup { get; set; }
        public string? businessname { get; set; } = "";
        public string? contactname { get; set; } = "";
        public int mobile2 { get; set; }
        public int costcentreid { get; set; }
        public string? followupreason { get; set; } = "";
        public string? field1 { get; set; } = "";
        public string? field2 { get; set; } = "";
        public string? field3 { get; set; } = "";
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set;}

    }
    //public class Mydtoleads
    //{
    //    public int id { get; set; }
    //    public int status { get; set; }
    //    public int leadscategoryid { get; set; }
    //    public int employeeid { get; set; }
    //    public string? leadsname { get; set; } = "";
    //    public int mobile1 { get; set; }
    //    public string? source { get; set; } = "";
    //    public DateTime? enquirydate { get; set; }
    //    public DateTime? discussiondate { get; set; }
    //    public string address { get; set; } = "";
    //    public DateTime? followup { get; set; }
    //    public string? businessname { get; set; } = "";
    //    public string? contactname { get; set; } = "";
    //    public int mobile2 { get; set; }
    //    public int costcentreid { get; set; }
    //    public string? followupreason { get; set; } = "";
    //    public string? field1 { get; set; } = "";
    //    public string? field2 { get; set; } = "";
    //    public string? field3 { get; set; } = "";
    //    public DateTime? createdAt { get; set; }
    //    public DateTime? updatedAt { get; set; }

    //}
    public class Mydtomessage1
    {
        public string? message { get; set; } = "";
    }
}
