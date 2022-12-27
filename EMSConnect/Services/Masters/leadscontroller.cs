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
//using static MAUI.Models.Masters.MyDtoAllUsers;

namespace EMSConnect.Services.Masters
{
    [Route("local/[controller]")]
    [ApiController]

    public class leadscontroller : Controller
    {
        public DBConnectionContext leadsContext;



        public leadscontroller()
        {
            leadsContext = new DBConnectionContext();
        }



        [HttpGet]


        public IList<tblleads> Get()
        {

            using (var context = new DBConnectionContext())
            {


                var items = (from a in context.tblleads
                             select new tblleads
                             {
                                 id = a.id,
                                 status = a.status,
                                 leadscategoryid = a.leadscategoryid,
                                 employeeid = a.employeeid,
                                 leadsname = a.leadsname,
                                 mobile1 = a.mobile1,
                                 source = a.source,
                                 enquirydate = a.enquirydate,
                                 discussiondate = a.discussiondate,
                                 address = a.address,
                                 followup = a.followup,
                                 businessname = a.businessname,
                                 contactname = a.contactname,
                                 mobile2 = a.mobile2,
                                 costcentreid = a.costcentreid,
                                 followupreason = a.followupreason,
                                 field1 = a.field1,
                                 field2 = a.field2,
                                 field3 = a.field3,
                                 createdAt = a.createdAt,
                                 updatedAt = a.updatedAt,

                             }).ToList();
                return items;
            }
        }


        [HttpGet("{id}")]

        public IList<tblleads> GetID(int id)
        {
            using (var context = new DBConnectionContext())
            {

                var items = (from tbl in context.tblleads
                             where tbl.id == id
                             select new tblleads
                             {
                                 status = tbl.status,
                                 leadscategoryid = tbl.leadscategoryid,
                                 employeeid = tbl.employeeid,
                                 leadsname = tbl.leadsname,
                                 mobile1 = tbl.mobile1,
                                 source = tbl.source,
                                 enquirydate = tbl.enquirydate,
                                 discussiondate = tbl.discussiondate,
                                 address = tbl.address,
                                 followup = tbl.followup,
                                 businessname = tbl.businessname,
                                 contactname = tbl.contactname,
                                 mobile2 = tbl.mobile2,
                                 costcentreid = tbl.costcentreid,
                                 followupreason = tbl.followupreason,
                                 field1 = tbl.field1,
                                 field2 = tbl.field2,
                                 field3 = tbl.field3,
                             }).ToList();
                return items;

            }


        }

        [HttpPost]
        public ActionResult<IEnumerable<tblleads>> GetResult([FromBody] List<tblleads> lists)
        {
            try
            {
                DBConnectionContext leadsContext = new DBConnectionContext();
                using (var context = new DBConnectionContext())
                {
                    // context.gtConneStatus = companycode;
                    // decimal UnitID = 0;
                    var data = context.tblleads.OrderByDescending(c => c.id).Select(b => new
                    {
                        id = b.id
                    }).FirstOrDefault();
                    foreach (tblleads Custlist in lists)
                    {
                        //PLID = PLID + 1;
                        var CustData = new tblleads()
                        {
                            status = Custlist.status,
                            leadscategoryid = Custlist.leadscategoryid,
                            employeeid=Custlist.employeeid,
                            leadsname=Custlist.leadsname,
                            mobile1 = Custlist.mobile1,
                            source = Custlist.source,
                            enquirydate = Custlist.enquirydate,
                            discussiondate = Custlist.discussiondate,
                            address=Custlist.address,
                            followup=Custlist.followup,
                            businessname=Custlist.businessname,
                            contactname=Custlist.contactname,
                            mobile2=Custlist.mobile2,
                            costcentreid=Custlist.costcentreid,
                            followupreason=Custlist.followupreason,
                            field1=Custlist.field1,
                            field2=Custlist.field2,
                            field3=Custlist.field3,


                        };

                        context.tblleads.Add(CustData);
                        context.SaveChanges();
                        var items1 = (from a in context.tblleads

                                      select new Mydtomessage1
                                      {

                                          message = " Lead Saved Successfully"


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
        public void Update(int id)
        {
            try
            {
                using (var context = new DBConnectionContext())
                {
                    //context.gtConneStatus = companycode;
                    var data = context.tblleads.Where(c => c.id == id).FirstOrDefault();
                    if (data != null)
                    {
                        data.id = id;
                        
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
                    var data = context.tblleads.Where(c => c.id == id).FirstOrDefault();
                    if (data != null)
                    {
                        context.tblleads.Remove(data);
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
