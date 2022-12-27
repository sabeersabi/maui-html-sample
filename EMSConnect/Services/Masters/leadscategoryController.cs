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

namespace EMSConnect.Services.Masters
{
    [Route("local/[controller]")]
    [ApiController]

    public class leadscategoryController : Controller
    {

        public DBConnectionContext leadscategoryContext;



        public leadscategoryController()
        {
            leadscategoryContext = new DBConnectionContext();
        }

        [HttpGet]


        public IList<tblleadscategory> Get()
        {

            using (var context = new DBConnectionContext())
            {


                var items = (from a in context.tblleadscategory
                             select new tblleadscategory
                             {
                                 id = a.id,
                                 categoryname = a.categoryname
,
                                 description = a.description,
                                 status= a.status,

                             }).ToList();
                return items;
            }
        }
        [HttpGet("{id}")]

        public IList<tblleadscategory> GetID(int id)
        {
            using (var context = new DBConnectionContext())
            {

                var items = (from tbl in context.tblleadscategory
                             where tbl.id == id
                             select new tblleadscategory
                             {
                                 id = tbl.id,
                                 categoryname = tbl.categoryname,
                                 description = tbl.description,
                                 status = tbl.status,
                        
                                 createdAt = tbl.createdAt,
                                 updatedAt = tbl.updatedAt,
                             }).ToList();
                return items;

            }


        }



        [HttpPost]
        public ActionResult<IEnumerable<tblleadscategory>> GetResult([FromBody] List<tblleadscategory> lists)
        {
            try
            {
                DBConnectionContext leadscategory = new DBConnectionContext();
                using (var context = new DBConnectionContext())
                {
                    // context.gtConneStatus = companycode;
                    // decimal UnitID = 0;
                    var data = context.tblleadscategory.OrderByDescending(c => c.id).Select(b => new
                    {
                        id = b.id
                    }).FirstOrDefault();
                    foreach (tblleadscategory Custlist in lists)
                    {
                        //PLID = PLID + 1;
                        var CustData = new tblleadscategory()
                        {
                            //PLID = PLID,
                            categoryname = Custlist.categoryname,
                            description = Custlist.description,
                            status = Custlist.status,
                           


                        };

                        context.tblleadscategory.Add(CustData);
                        context.SaveChanges();
                        var items1 = (from a in context.tblleadscategory

                                      select new MyDtoMessage
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
        public void Update(int id, string categoryname, string description,int status)
        {
            try
            {
                using (var context = new DBConnectionContext())
                {
                    //context.gtConneStatus = companycode;
                    var data = context.tblleadscategory.Where(c => c.id == id).FirstOrDefault();
                    if (data != null)
                    {
                        data.id = id;
                        data.categoryname = categoryname;
                        data.description = description;
                        data.status = status;
                        
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
                    var data = context.tblleadscategory.Where(c => c.id == id).FirstOrDefault();
                    if (data != null)
                    {
                        context.tblleadscategory.Remove(data);
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
