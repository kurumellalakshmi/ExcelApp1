using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Data;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            using (XLWorkbook workbook=new XLWorkbook(FileUpload1.PostedFile.InputStream))
            {
                IXLWorksheet sheet = workbook.Worksheet(1);
                DataTable dt = new DataTable();
                bool firstRow = true;
                foreach(IXLRow row in sheet.Rows())
                {
                    if (firstRow)
                    {
                        foreach (IXLCell cell in row.Cells())
                        {
                            dt.Columns.Add(cell.Value.ToString());
                        }
                        firstRow = false;
                    }
                    else
                    {
                        dt.Rows.Add();
                        int i = 0;
                        foreach(IXLCell cell in row.Cells())
                        {
                            dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                            i++;
                        }
                    }
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

        }
    }
}