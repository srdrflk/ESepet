using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dttbl = new DataTable();
        dttbl = (DataTable)Session["buyitems"];
        if (dttbl != null)
        {
            Label3.Text = dttbl.Rows.Count.ToString();
        }
        else
        {
            Label3.Text = "0";
        }

    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "SepeteEkle")
        {
            DropDownList dlist = (DropDownList)(e.Item.FindControl("DropDownList1"));
            Response.Redirect("SepeteEkle.aspx?id=" + e.CommandArgument.ToString() + "&quantity=" + dlist.SelectedItem.ToString());
        }

    }
}