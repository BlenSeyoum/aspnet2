using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

namespace CourseReg
{
    public partial class CourseRegDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }

        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("selectproc"))
                {
                    
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            grwCourse.DataSource = dt;
                            grwCourse.DataBind();
                        }
                    }
                }
            }
        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grwCourse.Rows)
            {
                if (row.RowIndex == grwCourse.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grwCourse, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grwCourse.Rows[e.RowIndex];
            string cid = Convert.ToString(grwCourse.DataKeys[e.RowIndex].Values[0]);

            string consr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(consr))
            {
                using (SqlCommand cmd = new SqlCommand("deleteproc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@courseNo", cid);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            grwCourse.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void Update(object sender, EventArgs e)
        {
            string cnum = cNumber.Text;
            string cname = cName.Text;
            DateTime cDatestring = DateTime.Parse(cdate.Text);

            string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("updateproc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@courseNo", cnum);
                    cmd.Parameters.AddWithValue("@courseName", cname);
                    cmd.Parameters.AddWithValue("@createdDate", cDatestring);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.Url.ToString());
                }
            }
            this.BindGrid();

        }
        protected void savedb(object sender, EventArgs e)
        {
            string cnum = cNumber.Text;
            string cname = cName.Text;
            DateTime cDatestring = DateTime.Parse(cdate.Text);


            String cumid=null;

            for (int i = 400; i <= 900; i++)
            {
                cumid = cnum + i;
            }


            string constr = ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("insertproc"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@courseNo", cnum);
                    cmd.Parameters.AddWithValue("@courseName", cname);
                    cmd.Parameters.AddWithValue("@createdDate", cDatestring);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect(Request.Url.ToString());
                }
            }
            this.BindGrid();

        }

        protected void grw_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editrow")
            {
                
                btnupdate.Visible=true;

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = grwCourse.Rows[rowIndex];
 
                string cnumber = (row.FindControl("cNum") as Label).Text;
                cNumber.Text = cnumber;
                string name = (row.FindControl("cname") as Label).Text;
                cName.Text = name;
                string cdate2 = (row.FindControl("cdate1") as Label).Text;
                cdate.Text = cdate2;             

            }
        }



    }

}