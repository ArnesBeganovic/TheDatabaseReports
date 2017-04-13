using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheDatabase
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource =  PNDetailsDataAccessLayer.GetResult(ddl_VehicleList.SelectedValue);
            GridView1.DataBind();
        }
      
        protected void btn_ExportToExcel_Click(object sender, EventArgs e)
        {   // Clear all content output from the buffer stream 
            Response.ClearContent();
            // Specify the default file name using "content-disposition" RESPONSE header 
            Response.AppendHeader("content-disposition", "attachment; filename=Employees.xls");
            // Set excel as the HTTP MIME type 
            Response.ContentType = "application/excel";
            // Create an instance of stringWriter for writing information to a string System.IO.
            StringWriter stringWriter = new System.IO.StringWriter();
            // Create an instance of HtmlTextWriter class for writing markup 
            // characters and text to an ASP.NET server control output stream 
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            // Set white color as the background color for gridview header row 
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");
            // Set background color of each cell of GridView1 header row 
            foreach (TableCell tableCell in GridView1.HeaderRow.Cells) {
                tableCell.Style["background-color"] = "#A55129";
            }
            // Set background color of each cell of each data row of GridView1 
            foreach (GridViewRow gridViewRow in GridView1.Rows) {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells) {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }
            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
    
}