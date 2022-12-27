using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using EMSConnectWithEFCore.DBContexts;
using EMSConnect.Models;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using EMSConnect.Models.Masters;
using System.Security.Cryptography;
using System.Text;

using System.Configuration;
using System.Linq;
using static EMSConnect.Models.Masters.MyDtoAllUsers;

namespace EMSConnect.Services.Masters
{
    [Route("local/[controller]")]
    [ApiController]
    public class logindetailsController : Controller
    {
        public DBConnectionContext userContext;



        public logindetailsController()
        {
            userContext = new DBConnectionContext();
        }

        [HttpGet]


        public IList<MyDtoAllUsers> Get()
        {

            using (var context = new DBConnectionContext())
            {


                var items = (from a in context.tbllogindetails
                             select new MyDtoAllUsers
                             {
                                 id=a.id,
                                 UserName = a.UserName,
                                 Password = a.Password

                             }).ToList();
                return items;
            }
        }
        [HttpPost]
        public ActionResult<IEnumerable<tbllogindetails>> GetResult([FromBody] List<tbllogindetails> lists)
        {
            try
            {
                DBConnectionContext UserContext = new DBConnectionContext();
                using (var context = new DBConnectionContext())
                {
                    // context.gtConneStatus = companycode;
                    // decimal UnitID = 0;
                    var data = context.tbllogindetails.OrderByDescending(c => c.id).Select(b => new
                    {
                        id = b.id
                    }).FirstOrDefault();
                    foreach (tbllogindetails Custlist in lists)
                    {
                        //PLID = PLID + 1;
                        var CustData = new tbllogindetails()
                        {
                            //PLID = PLID,
                            UserName = Custlist.UserName,
                            Password = Custlist.Password,


                        };

                        context.tbllogindetails.Add(CustData);
                        context.SaveChanges();
                        var items1 = (from a in context.tbllogindetails

                                      select new MyDtomessage
                                      {

                                          message = "Login Successfully"


                                      }).Distinct().ToList();
                        return Ok(new { response = items1 });
                        //foreach (MyDtoAllUsers Custlist in lists)
                        //{
                        //    //id = id + 1;
                        //    var CustData = new MyDtoAllUsers()
                        //    {
                        //        //id = id,
                        //       
                        //        //DefaultUnitConv = Custlist.DefaultUnitConv,
                        //    };
                        //    //  UserContext.MyDtoAllUsers.Add(CustData);
                        //    UserContext.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {

            }
            return Ok();

        }


    }

}

