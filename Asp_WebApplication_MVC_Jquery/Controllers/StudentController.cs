using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using Asp_WebApplication_MVC_Jquery.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace Asp_WebApplication_MVC_Jquery.Controllers
{
    public class StudentController : Controller
    {
         SqlConnection con=new SqlConnection(ConfigurationManager.ConnectionStrings["XYZ"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }
        

        public void StudentInsert(StudentModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert Student values('"+obj._name+"','"+obj._address+"','"+obj._age+"')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            
        }
        public string Display()   // public JsonResult Display()
        {
            string data = "";
            SqlCommand cmd = new SqlCommand("Select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data = JsonConvert.SerializeObject(dt);
            return data;     // return Json( data,JsonRequestBehavior.AllowGet);
        }
        public void StudentDelete(StudentModel obj)// public void StudentDelete(int A)// If not have model class class(38-39 video)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete Student where id='" + obj._id + "' ", con);
            cmd.ExecuteNonQuery();/*run the command on sqlserver, connected database.
                                  The method does not return any result set but instead returns the number of rows affected by the SQL command execution.*/
            con.Close();
        }

        
        public string EditStudent(StudentModel obj)
        {
            string data = "";
            SqlCommand cmd = new SqlCommand("Select * from Student where id='" + obj._id + "'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            data = JsonConvert.SerializeObject(dt);
            return data;
        }

        public void StudentUpdate(StudentModel obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Student set name='" + obj._name + "',address='" + obj._address + "',age='" + obj._age + "' where id='" + obj._id + "' ", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}