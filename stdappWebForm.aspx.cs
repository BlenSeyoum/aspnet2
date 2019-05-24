using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace Studentapp
{   
    
    public partial class stdappWebForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constring"].ConnectionString);
        SqlDataAdapter sqlda = new SqlDataAdapter();
        DataSet ds = new DataSet();
        Random random = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            if (!IsPostBack)
            {
                dateofBirthCalendar.Visible = false;
                createdDateCalendar.Visible = false;
            }
            SqlCommand sqlcmd = new SqlCommand("stdpSelect", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(ds, "tblStudent");
            this.GridViewstudentlist.DataSource = ds;
            this.GridViewstudentlist.DataBind();
            
        }
       
        protected void Save_Click(object sender, EventArgs e)
        {
            
            string studID;
            int studIDran;
            studIDran = random.Next(900, 1000);
            studID = "AWS/0" + studIDran.ToString() + "/95";
            SqlCommand sqlcmdid = new SqlCommand("searchID", con);
            sqlcmdid.CommandType = CommandType.StoredProcedure;
            if (studID == (sqlcmdid.Parameters.AddWithValue("@studID", studID ).Value).ToString())

            {
                   studIDran = random.Next(900, 1000);
                   studID = "AWS/0" + studIDran.ToString() + "/95";
            }
            txtstudID.Visible = false;
            string firstname = txtfirstname.Text;
            string fathername = txtfathername.Text;
            string grandfathername = txtgrandfathername.Text;
            string dateofBirth = txtdateofBirth.Text;
            string createdDate = txtcreatedDate.Text;
            string gender = txtgender.Text;
            SqlCommand sqlcmd = new SqlCommand("stdpInsert", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@studID", studID);
            sqlcmd.Parameters.AddWithValue("@firstname", firstname);
            sqlcmd.Parameters.AddWithValue("@fathername", fathername);
            sqlcmd.Parameters.AddWithValue("@grandfathername", grandfathername);
            sqlcmd.Parameters.AddWithValue("@dateofBirth", dateofBirth);
            sqlcmd.Parameters.AddWithValue("@createdDate", createdDate);
            sqlcmd.Parameters.AddWithValue("@gender", gender);
            sqlcmd.Connection = con;
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(ds, "tblStudent");
            this.GridViewstudentlist.DataSource = ds;
            this.GridViewstudentlist.DataBind();
            Response.Redirect(Request.Url.AbsoluteUri);
            
        }
        protected void Update_Click(object sender, EventArgs e)
        {

            string studID = txtstudID.Text;
            string firstname = txtfirstname.Text;
            string fathername = txtfathername.Text;
            string grandfathername = txtgrandfathername.Text;
            string dateofBirth = txtdateofBirth.Text;
            string createdDate = txtcreatedDate.Text;
            string gender = txtgender.Text;
            SqlCommand sqlcmd = new SqlCommand("stdpUpdates", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@studID", studID);
            sqlcmd.Parameters.AddWithValue("@firstname", firstname);
            sqlcmd.Parameters.AddWithValue("@fathername", fathername);
            sqlcmd.Parameters.AddWithValue("@grandfathername", grandfathername);
            sqlcmd.Parameters.AddWithValue("@dateofBirth", dateofBirth);
            sqlcmd.Parameters.AddWithValue("@createdDate", createdDate);
            sqlcmd.Parameters.AddWithValue("@gender", gender);
            sqlcmd.Connection = con;
            sqlda.SelectCommand = sqlcmd;
            sqlda.Fill(ds, "tblStudent");
            this.GridViewstudentlist.DataSource = ds;
            this.GridViewstudentlist.DataBind();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void ImageButtondateofBirth_Click(object sender, ImageClickEventArgs e)
        {
            if (dateofBirthCalendar.Visible)
            {
                dateofBirthCalendar.Visible = false;
            }
            else
            {
                dateofBirthCalendar.Visible = true;
            }
        }

        protected void ImageButtoncreatedDate_Click(object sender, ImageClickEventArgs e)
        {
            if (createdDateCalendar.Visible)
            {
                createdDateCalendar.Visible = false;
            }
            else
            {
                createdDateCalendar.Visible = true;
            }
        }

       
         protected void dateofBirthCalendar_SelectionChanged(object sender, EventArgs e)
        {
            this.txtdateofBirth.Text = dateofBirthCalendar.SelectedDate.ToShortDateString();
            dateofBirthCalendar.Visible = false;

        }

         protected void createdDateCalendar_SelectionChanged(object sender, EventArgs e)
         {
             this.txtcreatedDate.Text = createdDateCalendar.SelectedDate.ToShortDateString();
             createdDateCalendar.Visible = false;

         }
         protected void GridViewstudentlist_SelectedIndexChanged(object sender, EventArgs e)
         {
             txtstudID.Text = GridViewstudentlist.SelectedRow.Cells[1].Text;
             txtfirstname.Text = GridViewstudentlist.SelectedRow.Cells[2].Text;
             txtfathername.Text = GridViewstudentlist.SelectedRow.Cells[3].Text;
             txtgrandfathername.Text = GridViewstudentlist.SelectedRow.Cells[4].Text;
             txtdateofBirth.Text = GridViewstudentlist.SelectedRow.Cells[5].Text;
             txtcreatedDate.Text = GridViewstudentlist.SelectedRow.Cells[6].Text;
             txtgender.Text = GridViewstudentlist.SelectedRow.Cells[7].Text;

         }
        

         protected void Search_Click(object sender, EventArgs e)
         {
             string studID = Searchbox.Text;
             string firstname = Searchbox.Text;
             SqlCommand sqlcmd = new SqlCommand("searchstudent", con);
             sqlcmd.CommandType = CommandType.StoredProcedure;
             sqlcmd.Parameters.AddWithValue("@studID", studID);
             sqlcmd.Parameters.AddWithValue("@firstname", firstname);
             SqlDataReader read = sqlcmd.ExecuteReader();

             while (read.Read())
             {
                 txtstudID.Text = (read["studID"].ToString());
                 txtfirstname.Text = (read["firstname"].ToString());
                 txtfathername.Text = (read["fathername"].ToString());
                 txtgrandfathername.Text = (read["grandfathername"].ToString());
                 txtdateofBirth.Text = (read["dateofBirth"].ToString());
                 txtcreatedDate.Text = (read["createdDate"].ToString());
                 txtgender.Text = (read["gender"].ToString());
             }
             read.Close();
         }
             
     }
}