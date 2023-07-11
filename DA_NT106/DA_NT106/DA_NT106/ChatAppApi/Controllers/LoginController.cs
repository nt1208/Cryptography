using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.SqlServer.Server;

namespace ChatAppApi.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public string Login(string userName, string Pass)
        {
            try
            {
                var connectionString = string.Format(@"Data Source=LAPTOP-I0VI3B35;Initial Catalog=ChatApp;User ID=LAPTOP-I0VI3B3/user0511; password=;");
                using (var con = new SqlConnection(connectionString))
                {
                    if(con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    using (var sqlcon = con.CreateCommand())
                    {
                        sqlcon.CommandTimeout = 60;
                        sqlcon.CommandText = "@select 1 from _USER where username = @username and password =@pass";
                        sqlcon.Parameters.Add(new SqlParameter("@username", userName));
                        sqlcon.Parameters.Add(new SqlParameter("@pass", Pass));
                        var result = sqlcon.ExecuteScalar().ToString();
                        sqlcon.Parameters.Clear();
                        if(result == "1")
                        {
                            return "";
                        }
                    }
                    return "Ten hoac mat khau khong dung";
                }
            }
            catch (Exception ex)
            {

                 return ex.Message;
            }
        }
    }
}
