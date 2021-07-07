using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FrontEndTeamManagement.Models;

namespace FrontEndTeamManagement.Controllers
{
    public class UserAccountController : Controller
    {
        //
        // GET: /UserAccount/
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            string constr = ConfigurationManager.ConnectionStrings["FrontEndTeamManagementConnection"].ToString();
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From tblGender", con);
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From tblSecQuestion", con);
            SqlDataAdapter da3 = new SqlDataAdapter("Select * From tblTeamRole", con);
            SqlDataAdapter da4 = new SqlDataAdapter("Select * From tblMaritalStatus", con);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            ViewBag.Gender = ToSelectList(dt1, "ID", "Gender");
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            ViewBag.QuestionList = ToSelectList(dt2, "ID", "Security_Questions");
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            ViewBag.TeamRoleList = ToSelectList(dt3, "ID", "TeamRole");
            DataTable dt4 = new DataTable();
            da4.Fill(dt4);
            ViewBag.MaritalStatusList = ToSelectList(dt4, "ID", "MaritalStatus");

            return View();
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {                   
                    Value = row[valueField].ToString(),
                    Text = row[textField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }

        [HttpPost]
        public ActionResult SaveRegistrationDetails(RegisterViewModel registerModel)
        {
            //Database Connection
            string constr = ConfigurationManager.ConnectionStrings["FrontEndTeamManagementConnection"].ToString();
            SqlConnection con = new SqlConnection(constr);
            if (ModelState.IsValid)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("AddTeamMemberDetailsProc", con);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmployeeId", registerModel.EmployeeId);
                    cmd.Parameters.AddWithValue("@FirstName", registerModel.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", registerModel.LastName);
                    cmd.Parameters.AddWithValue("@Gender", registerModel.Gender);
                    cmd.Parameters.AddWithValue("@MaritalStatus", registerModel.MaritalStatus);
                    cmd.Parameters.AddWithValue("@DateOfBirth", registerModel.DateOfBirth);
                    cmd.Parameters.AddWithValue("@CurrentAddress", registerModel.CurrentAddress);
                    cmd.Parameters.AddWithValue("@PinCode", registerModel.PinCode);
                    cmd.Parameters.AddWithValue("@PermanentAddress", registerModel.PermanentAddress);
                    cmd.Parameters.AddWithValue("@MobileNo", registerModel.MobileNo);
                    cmd.Parameters.AddWithValue("@TeamRole", registerModel.TeamRole);
                    cmd.Parameters.AddWithValue("@CompanyName", registerModel.CompanyName);
                    cmd.Parameters.AddWithValue("@Experience", registerModel.WorkExperience);
                    cmd.Parameters.AddWithValue("@TechnologyKnown", registerModel.TechnologyKnown);
                    cmd.Parameters.AddWithValue("@Email", registerModel.EmailId);
                    cmd.Parameters.AddWithValue("@UserName", registerModel.UserName);
                    cmd.Parameters.AddWithValue("@usrPassword", registerModel.Password);
                    cmd.Parameters.AddWithValue("@SecurityQuestion", registerModel.SecurityQuestion);
                    cmd.Parameters.AddWithValue("@SecurityAnswer", registerModel.SecurityAnswer);
                    //cmd.Parameters.AddWithValue("@tid", 0);
                    //cmd.Parameters["@eid"].Direction = ParameterDirection.Output;

                    //int i = cmd.ExecuteNonQuery();
                    //i = Convert.ToInt16(cmd.Parameters["@eid"].Value);
                    //con.Close();
                    //if (i >= 1)
                    //{

                    //    ViewBag.Message = "Registered Successfully";

                    //}
                    //return View("Register");
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ViewBag.Message = "Registered Successfully";
                    return RedirectToAction("Login","UserAccount");
                }
                catch (Exception ex)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                    ViewBag.result = ex.Message;
                    return View("Register");
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                return View("Register", registerModel);
            }

        }
	}
}