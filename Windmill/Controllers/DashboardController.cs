using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace WindMill.Controllers
{
    //[RoutePrefix("")]
}

public class GetDashboardController : ApiController
{
    public string InntegrateDbConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

	public static string Path = ConfigurationManager.AppSettings["Path"].ToString();
	[HttpGet]
    [Route("api/GetDashboardController/GetOpenCloseTicket/{date}")]


    public Array GetOpenCloseTicket(string date)
    {
        var path = ConfigurationManager.AppSettings["urlPath"];


        try
        {
            using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mss_datas";
                cmd.Parameters.AddWithValue("@date", date);

                con.Open();
                DataSet ds = new DataSet();
                DataTable countdt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                cmd.Dispose();
                con.Close();

                var result = ds.Tables[2].AsEnumerable().Select(item => new
                {
                    openticket = item["openticket"],
                    closeticket = item["closeticket"]


                }).ToArray();

                return result;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new Array[] { };
        }
    }



    [HttpGet]
    [Route("api/GetDashboardController/GetTotalOpenTicketDetails/{Date}")]




    public Array GetTotalOpenTicketDetails(string Date)
    {
        var path = ConfigurationManager.AppSettings["urlPath"];


        try
        {
            using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mss_datas";
                cmd.Parameters.AddWithValue("@date", Date);

                con.Open();
                DataSet ds = new DataSet();
                DataTable countdt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                cmd.Dispose();
                con.Close();

                var result = ds.Tables[0].AsEnumerable().Select(item => new
                {
                    id= item["id"],
                    device = item["device"],
                    status = item["devicestatus"],
                    intime= item["intime"],


                }).ToArray();

                return result;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new Array[] { };
        }
    }




    [HttpGet]
    [Route("api/GetDashboardController/GetTotalcloseTicketDetails/{date}")]




    public Array GetTotalcloseTicketDetails(string date)
    {
        var path = ConfigurationManager.AppSettings["urlPath"];


        try
        {
            using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "mss_datas";
                cmd.Parameters.AddWithValue("@date", date);

                con.Open();
                DataSet ds = new DataSet();
                DataTable countdt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                da.Dispose();
                cmd.Dispose();
                con.Close();

                var result = ds.Tables[1].AsEnumerable().Select(item => new
                {
                    device = item["device"],
                    status = item["devicestatus"],
                    outtime= item["outtime"],
                    descr = item["descr"]


                }).ToArray();

                return result;

            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return new Array[] { };
        }
    }



	[HttpGet]
	[Route("api/GetDashboardController/GetofflineDetails/{date}")]




	public Array GetofflineDetails(string date)
	{
		var path = ConfigurationManager.AppSettings["urlPath"];


		try
		{
			using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "mss_datas";
				cmd.Parameters.AddWithValue("@date", date);

				con.Open();
				DataSet ds = new DataSet();
				DataTable countdt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);
				da.Dispose();
				cmd.Dispose();
				con.Close();

				var result = ds.Tables[4].AsEnumerable().Select(item => new
				{
					device = item["device"],
					rtime= item["remote_time"],
					name = item["devicename"]


				}).ToArray();

				return result;

			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			return new Array[] { };
		}
	}






	[HttpGet]
	[Route("api/GetDashboardController/getallclosedtickets/{fromdate}/{todate}/{deviceid}")]




	public Array getallclosedtickets(string fromdate,string todate,string deviceid)
	{
		var path = ConfigurationManager.AppSettings["urlPath"];


		try
		{
			using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "mss_reports";
				cmd.Parameters.AddWithValue("@fromdate", fromdate);
                cmd.Parameters.AddWithValue("@todate", todate);
				cmd.Parameters.AddWithValue("@device", deviceid);
				con.Open();
				DataSet ds = new DataSet();
				DataTable countdt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);
				da.Dispose();
				cmd.Dispose();
				con.Close();

				var result = ds.Tables[0].AsEnumerable().Select(item => new
				{
					device = item["device"],
					status = item["devicestatus"],
					outtime = item["outtime"],
                    intime = item["intime"],
                    duration = item["diff"]


				}).ToArray();

				return result;

			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			return new Array[] { };
		}
	}



	[HttpGet]
	[Route("api/GetDashboardController/closeticket/{id}/{comment}")]




	public Array closeticket(string id,string comment)
	{
		var path = ConfigurationManager.AppSettings["urlPath"];


		try
		{
			using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "mss_comments";
				cmd.Parameters.AddWithValue("@id", id);
				cmd.Parameters.AddWithValue("@comment", comment);


				con.Open();
				DataSet ds = new DataSet();
				DataTable countdt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);
				da.Dispose();
				cmd.Dispose();
				con.Close();

				var result = ds.Tables[0].AsEnumerable().Select(item => new
				{
					result = item["result"],
					


				}).ToArray();

				return result;

			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			return new Array[] { };
		}
	}


	[HttpGet]
	[Route("api/GetDashboardController/getdeviceid/")]




	public Array getdeviceid()
	{
		var path = ConfigurationManager.AppSettings["urlPath"];


		try
		{
			using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = con;
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "mss_deviceid";
				


				con.Open();
				DataSet ds = new DataSet();
				DataTable countdt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(ds);
				da.Dispose();
				cmd.Dispose();
				con.Close();

				var result = ds.Tables[0].AsEnumerable().Select(item => new
				{
					result = item["device"],
					name = item["devicename"]



				}).ToArray();

				return result;

			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
			return new Array[] { };
		}
	}





	[HttpPost]
	[Route("api/GetDashboardController/GetDetailspost/{content}")]
	public string GetDetailspost(string content)
	{
		try
		{

			using (var stream = new FileStream(
		   Path, FileMode.Append, FileAccess.Write, FileShare.Write, 4096))
			{
				var bytes = Encoding.UTF8.GetBytes(Environment.NewLine + content);
				stream.Write(bytes, 0, bytes.Length);
			}

			var str = content.Split(']');
			var deviceid = str[0] + "]";

			var gsmno = deviceid.Split('L');

			var devicestatus = gsmno[1].Split('[');


			var time = str[1].Split('T');
			time[1] = time[1].Replace("-", ":");

			var remotetime = time[0].Substring(1, time[0].Length - 1) + " " + time[1];

			var datetime = gsmno[0] + "," + devicestatus[0] + "," + devicestatus[1].Substring(0, devicestatus[1].Length - 1);



			try
			{
				using (SqlConnection con = new SqlConnection(InntegrateDbConnectionString))
				{
					SqlCommand cmd = new SqlCommand();
					cmd.Connection = con;
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "mss_rawdata";
					cmd.Parameters.AddWithValue("@device", deviceid);
					cmd.Parameters.AddWithValue("@remote_time", remotetime);
					cmd.Parameters.AddWithValue("@gsmno", gsmno[0]);

					cmd.Parameters.AddWithValue("@deviceid", devicestatus[0]);
					cmd.Parameters.AddWithValue("@devicestatus", devicestatus.Length == 0 ? "" : devicestatus[1].Substring(0, devicestatus[1].Length - 1));


					con.Open();
					DataSet ds = new DataSet();
					DataTable countdt = new DataTable();
					SqlDataAdapter da = new SqlDataAdapter(cmd);
					da.Fill(ds);
					da.Dispose();
					cmd.Dispose();
					con.Close();



				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}


			return remotetime;
		}
		catch (Exception ex)
		{
			ex.ToString();
			return ex.ToString();
		}


	}


}







