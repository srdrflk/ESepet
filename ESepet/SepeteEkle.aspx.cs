using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SepeteEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dttb = new DataTable();
            DataRow dtrow;
            dttb.Columns.Add("sno");
            dttb.Columns.Add("productID");
            dttb.Columns.Add("productname");
            dttb.Columns.Add("quantity");
            dttb.Columns.Add("price");
            dttb.Columns.Add("totalprice");
            dttb.Columns.Add("productimage");

            if (Request.QueryString["ID"] != null)
            {
                if (Session["buyitems"] == null)
                {
                    dtrow = dttb.NewRow();
                    string baglanti = "Data Source = FF\\SQLEXPRESS; Initial Catalog = SerdarinMagazasi; User ID = sa; Password = 123;";
                    SqlConnection con = new SqlConnection(baglanti);

                    string myquery = "select * from productdetail where productID = " + Request.QueryString["ID"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dtrow["sno"] = dttb.Rows.Count + 1;
                    dtrow["productid"] = ds.Tables[0].Rows[0]["productid"].ToString();
                    dtrow["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                    dtrow["productimage"] = ds.Tables[0].Rows[0]["productimage"].ToString();
                    dtrow["quantity"] = Request.QueryString["quantity"];
                    dtrow["price"] = ds.Tables[0].Rows[0]["price"].ToString();

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                    int quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                    int totalprice = price * quantity;
                    dtrow["totalprice"] = totalprice;
                    dttb.Rows.Add(dtrow);
                    GridView1.DataSource = dttb;
                    GridView1.DataBind();

                    Session["buyitems"] = dttb;
                    GridView1.FooterRow.Cells[5].Text = "Toplam Tutar "; ;
                    GridView1.FooterRow.Cells[6].Text = geneltoplam().ToString();
                    Response.Redirect("SepeteEkle.aspx");

                }
                else
                {
                    dttb = (DataTable)Session["buyitems"];
                    int sr = dttb.Rows.Count;

                    dtrow = dttb.NewRow();
                    string baglanti = "Data Source=FF\\SQLEXPRESS;Initial Catalog=SerdarinMagazasi;User ID=sa;Password=123";
                    SqlConnection con = new SqlConnection(baglanti);
                    string myquery = "select * from productdetail where productID = " + Request.QueryString["id"];
                    SqlCommand cmd = new SqlCommand(myquery, con);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dtrow["sno"] = dttb.Rows.Count + 1;
                    dtrow["productid"] = ds.Tables[0].Rows[0]["productid"].ToString();
                    dtrow["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                    dtrow["productimage"] = ds.Tables[0].Rows[0]["productimage"].ToString();
                    dtrow["quantity"] = Request.QueryString["quantity"];
                    dtrow["price"] = ds.Tables[0].Rows[0]["price"].ToString();

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                    int quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                    int totalprice = price * quantity;
                    dtrow["totalprice"] = totalprice;
                    dttb.Rows.Add(dtrow);
                    GridView1.DataSource = dttb;
                    GridView1.DataBind();

                    Session["buyitems"] = dttb;
                    GridView1.FooterRow.Cells[5].Text = "Toplam Tutar ";
                    GridView1.FooterRow.Cells[6].Text = geneltoplam().ToString();
                    Response.Redirect("SepeteEkle.aspx");

                }
            }
            else
            {
                dttb = (DataTable)Session["buyitems"];
                GridView1.DataSource = dttb;
                GridView1.DataBind();
                if (GridView1.Rows.Count > 0)
                {
                    GridView1.FooterRow.Cells[5].Text = "Toplam Tutar";
                    GridView1.FooterRow.Cells[6].Text = geneltoplam().ToString();
                }
            }
            Label2.Text = GridView1.Rows.Count.ToString();
        }
    }

    public int geneltoplam()
    {
        DataTable dttb = new DataTable();
        dttb = (DataTable)Session["buyitems"];
        int nrow = dttb.Rows.Count;
        int i = 0;
        int gnltoplam = 0;
        while (i < nrow)
        {
            gnltoplam = gnltoplam + Convert.ToInt32(dttb.Rows[i]["totalprice"].ToString());
            i = i + 1;
        }
        return gnltoplam;
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataTable dt = new DataTable();
        dt = (DataTable)Session["buyitems"];


        for (int i = 0; i <= dt.Rows.Count-1; i++)
        {
            int sr;
            int sr1;
            string qdata;
            string dtdata;
            sr = Convert.ToInt32(dt.Rows[i]["sno"].ToString());
            TableCell cell = GridView1.Rows[e.RowIndex].Cells[0];
            qdata = cell.Text;
            dtdata = sr.ToString();
            sr1 = Convert.ToInt32(qdata);

            if (sr == sr1)
            {
                dt.Rows[i].Delete();
                dt.AcceptChanges();
                break;

            }
        }

        for (int i = 1; i <= dt.Rows.Count; i++)
        {
            dt.Rows[i - 1]["sno"] = i;
            dt.AcceptChanges();
        }

        Session["buyitems"] = dt;
        Response.Redirect("SepeteEkle.aspx");
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("GoruntuleDuzenle.aspx?sno=" + GridView1.SelectedRow.Cells[0].Text);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SiparisOnay.aspx");
    }
}