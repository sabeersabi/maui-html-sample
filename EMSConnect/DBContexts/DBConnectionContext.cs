
using EMSConnect.Models.Masters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace EMSConnectWithEFCore.DBContexts
{
    public class DBConnectionContext : DbContext
    {
        public static String SqlServerIP = "";
        public static String SqlServerName = "";
        public static String Network = "";

        public static String CDKey = "";
        public static String PRODUCT = "";
        public static String OurCompanyName = "";
        public String[] CompanyName = new string[3];
        public string filePath = "";
        public static string SQlConnection = "";
        // private object sqlOptions;
        //public internal string? gtConneStatus;
        public string? gtConneStatus { get; set; }
        //   public static object gtConneStatus;
        //public string? gtConneStatus { get; set; }
        //public string gtConneStatus = "Exist";

        #region EntityConnection

        public DbSet<tbllogindetails> tbllogindetails { get; set; }

       
        public DbSet<tblstatus> tblstatus { get; set; }
        public DbSet<tblleads> tblleads { get; set; }
        public DbSet<tblleadscategory> tblleadscategory { get; set; }






        #endregion
        // public List<Itemlist> EmployeesList { get; set; }

        #region GetConnection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            try
            {
                string[] splitVar;
                string myline;
                int i = 0;
                string mydocpath = @"C:\DCSData\Settings\MAUI.ini";

                if (File.Exists(mydocpath))
                {
                    using (StreamReader reader = File.OpenText(mydocpath))
                    {
                        string? strresult;
                        while (!reader.EndOfStream) // reader.Peek >= 0
                        {
                            strresult = reader.ReadLine();

                            if (strresult is null) { strresult = ""; }
                            if (strresult != "")
                            {
                                myline = strresult;
                                if (myline.Trim() != "")
                                {
                                    splitVar = myline.Split("^^^");
                                    if (splitVar.GetUpperBound(0) >= 0)
                                    {
                                        if (splitVar[1] is null) { splitVar[1] = ""; }
                                        if (splitVar[0] == "NETWORK")
                                        {
                                            Network = splitVar[1];
                                        }
                                        if (splitVar[0] == "SERVERNAME")
                                        {
                                            SqlServerName = splitVar[1];
                                        }
                                        if (splitVar[0] == "CDKEY")
                                        {
                                            CDKey = splitVar[1];
                                        }
                                        if (splitVar[0] == "PRODUCT")
                                        {
                                            PRODUCT = splitVar[1];
                                        }

                                        if (splitVar[0] == "DBNAME" && i < 3)
                                        {
                                            CompanyName[i] = splitVar[1];
                                            if (i == 0)
                                            {
                                                OurCompanyName = CompanyName[i];
                                            }

                                            i++;
                                        }
                                    }
                                }

                            }


                        }
                    }
                }
                if (gtConneStatus == "" || gtConneStatus == null)
                {
                    OurCompanyName = OurCompanyName;

                }
                else
                {
                    OurCompanyName = gtConneStatus;

                }
            }
            catch (Exception)
            {
                Network = "";
                SqlServerName = "";
                CompanyName[0] = "";
                CompanyName[1] = "";
                CompanyName[2] = "";


            }



            //optionsBuilder.UseSqlServer($"Server=" + SqlServerName.Trim() + ";" +
            //$"Database=" + OurCompanyName.Trim() + ";" +
            //$"Trusted_Connection=False;" +
            //$"MultipleActiveResultSets=true;" +
            //$"user id=sa;" +
            //$"password=NEWTECH007$;" +
            //$"ConnectRetryCount=0");

            //  if (gtConneStatus == "")
            //  {
            //      string connString = "Server = " + SqlServerName.Trim() + "; " +
            //$"Database=" + gtConneStatus + ";" +
            //$"Trusted_Connection=False;" +
            //$"MultipleActiveResultSets=true;" +
            //$"user id=sa;" +
            //$"password=NEWTECH007$;" +
            //$"ConnectRetryCount=0";
            //      optionsBuilder.UseSqlServer(connString, sqlServerOptionsAction: sqlOptions =>
            //      {
            //          sqlOptions.EnableRetryOnFailure(
            //          maxRetryCount: 15,
            //          maxRetryDelay: TimeSpan.FromSeconds(30),
            //          errorNumbersToAdd: null);

            //          sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
            //      });
            //  }
            //  else
            //  { 

            string connString = "Server = " + SqlServerName.Trim() + "; " +
              $"Database=" + OurCompanyName.Trim() + ";" +
              $"Trusted_Connection=True;" +
              $"MultipleActiveResultSets=true;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;" +
              $"user id=sa;" +
              $"password=NEWTECH007$;" +
              $"ConnectRetryCount=0";
            optionsBuilder.UseSqlServer(connString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 255,
                maxRetryDelay: TimeSpan.FromSeconds(1000),
                errorNumbersToAdd: null);


                sqlOptions.CommandTimeout((int)TimeSpan.FromMinutes(100).TotalSeconds);
            });
            //}

            //{
            //    object value = sqlOptions.EnableRetryOnFailure(
            //    maxRetryCount: 15,
            //    maxRetryDelay: TimeSpan.FromSeconds(30),
            //    errorNumbersToAdd: null);
            //};

            //Encrypt = True;
            //TrustServerCertificate = True;
            //User Instance = False
        }



        //}
        //class Global
        //{
        //    public static string Globalcompnycode;
        //    public static string Status;
        //    public static string Adim;

        //}
        #endregion
        internal void Remove<T>(IQueryable<T> customer)
        {
            throw new NotImplementedException();
        }


        public class Itemlist
        {
            public string Text { get; set; }
            public int Value { get; set; }
        }

        internal void SaveChangesWithTriggers()
        {
            throw new NotImplementedException();
        }

    }
}