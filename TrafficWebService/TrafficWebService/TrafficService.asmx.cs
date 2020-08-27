using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web.Services; 
namespace TrafficWebService
{
    /// <summary>
    /// Summary description for TrafficService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    
    public class TrafficService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetAllParameters()
        {
            List<Vehicle> listTraffic = new List<Vehicle>();
            String constring = ConfigurationManager.ConnectionStrings["TrafficPr"].ConnectionString;
            SqlConnection cn   = new SqlConnection(constring);
            cn.Open();
            String strdtails = "SELECT SenderId, Calssification, DetectionDate, DetectionTime, Speed FROM TrafficDB.dbo.tbl_Traffic";
            SqlCommand cmd = new SqlCommand(strdtails, cn);
            SqlDataReader  rdr;
            rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Vehicle v = new Vehicle();
                    v.sensorId = rdr["SenderId"].ToString();
                    v.vclass = rdr["Calssification"].ToString();
                    v.detectionDate = rdr["DetectionDate"].ToString();
                    v.detectionTime = rdr["DetectionTime"].ToString();
                    v.vspeed = Convert.ToInt32(rdr["Speed"]);
                    listTraffic.Add(v);
                }
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(listTraffic));
        }
    }
}