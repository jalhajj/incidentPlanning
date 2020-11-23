using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlClient;

namespace planning.Utils
{
    public class MailSenderUti
    {

        internal static bool SendMail(int incidentId, string name)
        {
            try
            {
                //SqlDataReader reader = null;
                //SqlConnection con;
                //con = new SqlConnection(Properties.Settings.Default.connectionString);
                //    con.Open();
                using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["FromEmail"], "elhajjjad@outlook.com"))
                {
                    String body = "" + name + " est bloque sur l'incident " + incidentId;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = ConfigurationManager.AppSettings["Host"];
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    mm.Subject = "Incidents ";
                    mm.Body = body;
                    smtp.Send(mm);

                  //  System.Threading.Thread.Sleep(3000);
                 //   Environment.Exit(0);
                }
                //    SendEmail("Farid", reader, con);
                return true;
            }
            catch (Exception e)
            {
                return false;


            };
        }
    }
}