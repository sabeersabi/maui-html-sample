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

using Microsoft.AspNetCore.Mvc;
using static EMSConnect.Models.Masters.MyDtoAllUsers;

namespace MAUI.Services.Masters
{
    [Route("local/[controller]")]
    [ApiController]

    public class statusController : Controller
    {

        public DBConnectionContext statusContext;



        public statusController()
        {
            statusContext = new DBConnectionContext();
        }

        [HttpGet]


        public IList<Mydtostatus> Get()
        {

            using (var context = new DBConnectionContext())
            {


                var items = (from a in context.tblstatus
                             select new Mydtostatus
                             {
                                id= a.id,
                                name= a.name,
                                description= a.description,
                                field1= a.field1,
                                field1value=a.field1value,
                                field2=a.field2,
                                field2value=a.field2value,
                                field3=a.field3,
                                field3value=a.field3value,
                                type=a.type,
                                createdAt= a.createdAt,
                                updatedAt= a.updatedAt,

                             }).ToList();
                return items;
            }
        }
        [HttpGet("{id}")]

        public IList<tblstatus> GetID(int id)
        {
            using (var context = new DBConnectionContext())
            {

                var items = (from tbl in context.tblstatus
                             where tbl.id == id
                             select new tblstatus
                             {
                                 id = tbl.id,
                                 name = tbl.name,
                                 description = tbl.description,
                                 field1 = tbl.field1,
                                 field1value=tbl.field1value,
                                 field2=tbl.field2,
                                 field2value=tbl.field2value,
                                 field3=tbl.field3,
                                 field3value=tbl.field3value,
                                 type=tbl.type,
                                 createdAt = tbl.createdAt,
                                 updatedAt = tbl.updatedAt,
                             }).ToList();
                return items;

            }


        }
       


        [HttpPost]
        public ActionResult<IEnumerable<tblstatus>> GetResult([FromBody] List<tblstatus> lists)
        {
            try
            {
                DBConnectionContext statusContext = new DBConnectionContext();
                using (var context = new DBConnectionContext())
                {
                    // context.gtConneStatus = companycode;
                    // decimal UnitID = 0;
                    var data = context.tblstatus.OrderByDescending(c => c.id).Select(b => new
                    {
                        id = b.id
                    }).FirstOrDefault();
                    foreach (tblstatus Custlist in lists)
                    {
                        //PLID = PLID + 1;
                        var CustData = new tblstatus()
                        {
                            //PLID = PLID,
                            name = Custlist.name,
                            description = Custlist.description,
                            field1 = Custlist.field1,
                            field1value = Custlist.field1value,
                            field2 = Custlist.field2,
                            field2value = Custlist.field2value,
                            field3 = Custlist.field3,
                            field3value = Custlist.field3value,
                            type= Custlist.type,


                        };

                        context.tblstatus.Add(CustData);
                        context.SaveChanges();
                        var items1 = (from a in context.tblstatus

                                      select new MyDtomessage
                                      {

                                          message = "Saved Successfully"


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
        [HttpPatch("{id}")]
        public void Update(int id, string name, string description)
        {
            try
            {
                using (var context = new DBConnectionContext())
                {
                    //context.gtConneStatus = companycode;
                    var data = context.tblstatus.Where(c => c.id == id).FirstOrDefault();
                    if (data != null)
                    {
                        data.id = id;
                        data.name = name;
                        data.description = description;
                        context.SaveChanges();
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {

            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                var context = new DBConnectionContext();
                {
                    //context.gtConneStatus = companycode;
                    var data = context.tblstatus.Where(c => c.id == id).FirstOrDefault();
                    if (data != null)
                    {
                        context.tblstatus.Remove(data);
                        context.SaveChanges();
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

    }

}
