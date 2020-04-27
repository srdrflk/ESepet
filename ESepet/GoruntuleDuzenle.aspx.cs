using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class GoruntuleDuzenle : System.Web.UI.Page
{
    DataTable dttb;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (IsPostBack)
        {
        }
        else
        {
            if (Request.QueryString["sno"] != null)
            {
                dttb = (DataTable)Session["buyitems"];

                for (int i = 0; i <= dttb.Rows.Count - 1; i++)
                {
                    int sr, sr1;
                    sr = Convert.ToInt32(dttb.Rows[i]["sno"].ToString());
                    Label3.Text = Request.QueryString["sno"];
                    Label4.Text = sr.ToString();
                    sr1 = Convert.ToInt32(Label3.Text);

                    if (sr == sr1)
                    {
                        Label3.Text = dttb.Rows[i]["sno"].ToString();
                        Label4.Text = dttb.Rows[i]["productid"].ToString();
                        Label5.Text = dttb.Rows[i]["productname"].ToString();
                        Label6.Text = dttb.Rows[i]["price"].ToString();
                        DropDownList1.Text = dttb.Rows[i]["quantity"].ToString();
                        Label7.Text = dttb.Rows[i]["totalprice"].ToString();
                        break;
                    }
                }
            }
            else
            {
            }
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {        
        int x = Convert.ToInt32(DropDownList1.Text);
        int cost = Convert.ToInt32(Label6.Text);
        int totalcost = cost * x;
        Label7.Text = totalcost.ToString();

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        dttb = (DataTable)Session["buyitems"];

        for (int i = 0; i <= dttb.Rows.Count - 1; i++)
        {
            int sr = Convert.ToInt32(dttb.Rows[i]["sno"].ToString());
            int sr1 = Convert.ToInt32(Label3.Text);

            if (sr==sr1)
            {
                dttb.Rows[i]["sno"] = Label3.Text;
                dttb.Rows[i]["productid"] = Label4.Text;
                dttb.Rows[i]["productname"] = Label5.Text;
                dttb.Rows[i]["quantity"] = DropDownList1.Text;
                dttb.Rows[i]["price"] = Label6.Text;
                dttb.Rows[i]["totalprice"] = Label7.Text;
                dttb.AcceptChanges();
                break;
            }
        }
        Response.Redirect("SepeteEkle.aspx");
    }
}