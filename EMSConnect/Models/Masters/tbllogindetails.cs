using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMSConnect.Models.Masters
{
    public class tbllogindetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? UserName { get; set; } = "";
        public string? Password { get; set; } = "";



    }
    public class MyDtoAllUsers

    {
        public int id { get; set; }
        public string? UserName { get; set; } = "";
        public string? Password { get; set; } = "";


        public class MyDtomessage
        {
            public string? message { get; set; } = "";
        }
    }
}
