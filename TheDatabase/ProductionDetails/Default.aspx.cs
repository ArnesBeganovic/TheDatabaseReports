using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Collections.Generic;

namespace TheDatabase
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prepare sql command
            string sqlKomanda = "Select case when VehicleName is null then Vehicle else VehicleName end as VehicleName, VCC,JCI,Description,";
            int colsSend = 0;

            //Based on selected month, prepare sql columns to be returned
            switch (ddl_SelMonth.SelectedValue)
            {
                case "1":
                    sqlKomanda += "QuantM1,VehM1 from ProdPerVehicleLastYear where Vehicle = @Vehicle";
                    colsSend = 1;
                    break;
                case "2":
                    sqlKomanda += "QuantM1,VehM1,QuantM2,VehM2 from ProdPerVehicleLastYear where Vehicle = @Vehicle";
                    colsSend = 2;
                    break;
                case "3":
                    sqlKomanda += "QuantM1,VehM1,QuantM2,VehM2,QuantM3,VehM3 from ProdPerVehicleLastYear where Vehicle = @Vehicle";
                    colsSend = 3;
                    break;
                case "4":
                    sqlKomanda += "QuantM1,VehM1,QuantM2,VehM2,QuantM3,VehM3,QuantM4,VehM4 from ProdPerVehicleLastYear where Vehicle = @Vehicle";
                    colsSend = 4;
                    break;
                case "5":
                    sqlKomanda += "QuantM1,VehM1,QuantM2,VehM2,QuantM3,VehM3,QuantM4,VehM4,QuantM5,VehM5 from ProdPerVehicleLastYear where Vehicle = @Vehicle";
                    colsSend = 5;
                    break;
                case "6":
                    sqlKomanda += "QuantM1,VehM1,QuantM2,VehM2,QuantM3,VehM3,QuantM4,VehM4,QuantM5,VehM5,QuantM6,VehM6 from ProdPerVehicleLastYear where Vehicle = @Vehicle";
                    colsSend = 6;
                    break;
            }

            //Bind gridview to datasource
            GridView1.DataSource =  PNDetailsDataAccessLayer.GetResult(ddl_VehicleList.SelectedValue, sqlKomanda,colsSend);
            GridView1.DataBind();


        }
      
        protected void btn_ExportToExcel_Click(object sender, EventArgs e)
        {   
            
            /*
             * Exports gridview to excel and generates file name based on user selection and datetime
             */
            
            // Clear all content output from the buffer stream 
            Response.ClearContent();
            //Get month array in order to populate other cells in header extra row
            List<string> SelectedMonths = VratiMjesece(DateTime.Now.ToString("MM"));



            string fileName = ddl_VehicleList.SelectedItem + "_" + SelectedMonths[0] + "_" + DateTime.Now.ToString("yyyyMMddHHss");

            // Specify the default file name using "content-disposition" RESPONSE header 
            Response.AppendHeader("content-disposition", "attachment; filename="+ fileName + ".xls");
            // Set excel as the HTTP MIME type 
            Response.ContentType = "application/excel";
            // Create an instance of stringWriter for writing information to a string System.IO.
            StringWriter stringWriter = new System.IO.StringWriter();
            // Create an instance of HtmlTextWriter class for writing markup 
            // characters and text to an ASP.NET server control output stream 
            HtmlTextWriter htw = new HtmlTextWriter(stringWriter);
            // Set white color as the background color for gridview header row 
            GridView1.HeaderRow.Style.Add("background-color", "#FFFFFF");

            foreach (TableCell tableCell in GridView1.Rows[0].Cells) {
                tableCell.Style["background-color"] = "#A55129";
            }
            /*
            // Set background color of each cell of each data row of GridView1 
            foreach (GridViewRow gridViewRow in GridView1.Rows) {
                gridViewRow.BackColor = System.Drawing.Color.White;
                foreach (TableCell gridViewRowTableCell in gridViewRow.Cells) {
                    gridViewRowTableCell.Style["background-color"] = "#FFF7E7";
                }
            }
            */
            GridView1.RenderControl(htw);
            Response.Write(stringWriter.ToString());
            Response.End();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /*
             * Need to override this method in order to make export to excel work without trhowing exceptions
             */
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*
             * This function prepares gridview header. User can choose how meny columns to show with dropdown list
             * Based on that input, script has to show such amount of columns. Every month has two subcolumns Quantity and Nr of vehicles
             * It has to hide all month columns first and then unhide those that user want to see. Header has to contain month name and it
             * has to have colspan = 2 to include quantity and nr of vehicles.
             */
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //Prepare extra header row
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //First extra header row cell is empty 4 colspan.
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell);

                //Get month array in order to populate other cells in header extra row
                List<string> SelectedMonths = VratiMjesece(DateTime.Now.ToString("MM"));

                //Hide all production columns from gridview
                for(int i = 4; i <= 15; i++)
                {
                    GridView1.Columns[i].Visible = false;
                }


                //Now, show columns and add extra cell for header based on user month input. Month names are dynamic. Add upp to 6 such months or 12 columns.
                if (Convert.ToInt32(ddl_SelMonth.SelectedValue) >= 1) {
                    GridView1.Columns[4].Visible = true;
                    GridView1.Columns[5].Visible = true;
                    HeaderCell = new TableCell();
                    HeaderCell.Text = SelectedMonths[0];
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }

                if (Convert.ToInt32(ddl_SelMonth.SelectedValue) >= 2)
                {
                    GridView1.Columns[6].Visible = true;
                    GridView1.Columns[7].Visible = true;
                    HeaderCell = new TableCell();
                    HeaderCell.Text = SelectedMonths[1];
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }

                if (Convert.ToInt32(ddl_SelMonth.SelectedValue) >= 3)
                {
                    GridView1.Columns[8].Visible = true;
                    GridView1.Columns[9].Visible = true;
                    HeaderCell = new TableCell();
                    HeaderCell.Text = SelectedMonths[2];
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }

                if (Convert.ToInt32(ddl_SelMonth.SelectedValue) >= 4)
                {
                    GridView1.Columns[10].Visible = true;
                    GridView1.Columns[11].Visible = true;
                    HeaderCell = new TableCell();
                    HeaderCell.Text = SelectedMonths[3];
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }

                if (Convert.ToInt32(ddl_SelMonth.SelectedValue) >= 5)
                {
                    GridView1.Columns[12].Visible = true;
                    GridView1.Columns[13].Visible = true;
                    HeaderCell = new TableCell();
                    HeaderCell.Text = SelectedMonths[4];
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }

                if (Convert.ToInt32(ddl_SelMonth.SelectedValue) >= 6)
                {
                    GridView1.Columns[14].Visible = true;
                    GridView1.Columns[15].Visible = true;
                    HeaderCell = new TableCell();
                    HeaderCell.Text = SelectedMonths[5];
                    HeaderCell.ColumnSpan = 2;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderGridRow.Cells.Add(HeaderCell);
                }

                //Add extra cells in header extra row
                GridView1.Controls[0].Controls.AddAt(0, HeaderGridRow);
            }
        }

        private List<string> VratiMjesece(string mjesec)
        {
            /*
             * Retuns list of 6 months based on current month. Table in Qutation database contains one year of pre-calculated production data
             * starting with previous month. Current month is not in that table
             * Now we want to extract data based on user input. Number of months is dynamic and based on that gridview needs to build extra
             * header row and populate it with correct month names. Data in The Database is stored in columns called QuantM1, QuantM2 which
             * means Production Quantity from minus one month (M1), or minus two months (M2) etc. Each month data moves one month and new
             * data arrives. THat's why, this function has to calculate which month name gridview will show at extra header row.
             */

            //Prepare array 
            string[] ListaMjeseci = new string[18];
            ListaMjeseci[0] = "July";
            ListaMjeseci[1] = "August";
            ListaMjeseci[2] = "September";
            ListaMjeseci[3] = "October";
            ListaMjeseci[4] = "November";
            ListaMjeseci[5] = "December";
            ListaMjeseci[6] = "January";
            ListaMjeseci[7] = "February";
            ListaMjeseci[8] = "March";
            ListaMjeseci[9] = "April";
            ListaMjeseci[10] = "May";
            ListaMjeseci[11] = "June";
            ListaMjeseci[12] = "July";
            ListaMjeseci[13] = "August";
            ListaMjeseci[14] = "September";
            ListaMjeseci[15] = "October";
            ListaMjeseci[16] = "November";
            ListaMjeseci[17] = "December";

            //Prepare list
            List<string> mjeseci = new List<string>();

            //Calculate first month in arrray
            int StartCounter = GetStartCounter(mjesec);

            //Loop array backwards and add MOnth name to the list
            for(int i = StartCounter; i >= StartCounter - 5; i--)
            {
                mjeseci.Add(ListaMjeseci[i]);
            }

            //Return list
            return mjeseci;
        } 
        
        private int GetStartCounter(string mjesec)
        {
            /*
             * This function returns starting loop value to month array. It will loop backwards and based on current month. THe trick is to start
             * five months ahead because it can happend that user wants to show six months starting from March which means it has to take months
             * from previous year. Switch statement deals with it. 
             */


            int returnValue = 0;

            switch (mjesec)
            {
                case "01":
                    returnValue =  5;
                    break;
                case "02":
                    returnValue = 6;
                    break;
                case "03":
                    returnValue = 7;
                    break;
                case "04":
                    returnValue = 8;
                    break;
                case "05":
                    returnValue = 9;
                    break;
                case "06":
                    returnValue = 10;
                    break;
                case "07":
                    returnValue = 11;
                    break;
                case "08":
                    returnValue = 12;
                    break;
                case "09":
                    returnValue = 13;
                    break;
                case "10":
                    returnValue = 14;
                    break;
                case "11":
                    returnValue = 15;
                    break;
                case "12":
                    returnValue = 16;
                    break;

            }

            return returnValue;
        }
    }
    
}