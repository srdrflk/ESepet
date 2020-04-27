using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class SiparisOnay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dttb = new DataTable();
            DataRow dr;
            dttb.Columns.Add("sno");
            dttb.Columns.Add("productid");
            dttb.Columns.Add("productname");
            dttb.Columns.Add("quantity");
            dttb.Columns.Add("price");
            dttb.Columns.Add("totalprice");
            dttb.Columns.Add("productimage");

            if (Request.QueryString["id"] != null)
            {
                if (Session["buyitems"] == null)
                {
                    dr = dttb.NewRow();
                    string baglanti = "Data Source=FF\\SQLEXPRESS;Initial Catalog=SerdarinMagazasi;User ID=sa;Password=123";
                    SqlConnection con = new SqlConnection(baglanti);
                    string myquery = "select * from productdetail where productid = " + Request.QueryString["id"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["sno"] = 1;
                    dr["productid"] = ds.Tables[0].Rows[0]["productid"].ToString();
                    dr["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                    dr["productimage"] = ds.Tables[0].Rows[0]["productimage"].ToString();
                    dr["quantity"] = Request.QueryString["quantity"];
                    dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                    int quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                    int totalprice = price * quantity;
                    dr["totalprice"] = totalprice;

                    dttb.Rows.Add(dr);
                    GridView1.DataSource = dttb;
                    GridView1.DataBind();

                    Session["buyitems"] = dttb;
                    GridView1.FooterRow.Cells[4].Text = "Toplam Fiyat";
                    GridView1.FooterRow.Cells[5].Text = geneltoplam().ToString();
                    Response.Redirect("SepeteEkle.aspx");

                }
                else
                {
                    dttb = (DataTable)Session["buyitems"];
                    int sr = dttb.Rows.Count;

                    dr = dttb.NewRow();
                    string baglanti = "Data Source=FF\\SQLEXPRESS;Initial Catalog=SerdarinMagazasi;User ID=sa;Password=123";
                    SqlConnection con = new SqlConnection(baglanti);
                    string myquery = "select * from productdetail where productid = " + Request.QueryString["id"];
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = myquery;
                    cmd.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dr["sno"] = sr + 1;
                    dr["productid"] = ds.Tables[0].Rows[0]["productid"].ToString();
                    dr["productname"] = ds.Tables[0].Rows[0]["productname"].ToString();
                    dr["productimage"] = ds.Tables[0].Rows[0]["productimage"].ToString();
                    dr["quantity"] = Request.QueryString["quantity"];
                    dr["price"] = ds.Tables[0].Rows[0]["price"].ToString();

                    int price = Convert.ToInt32(ds.Tables[0].Rows[0]["price"].ToString());
                    int quantity = Convert.ToInt32(Request.QueryString["quantity"].ToString());
                    int totalprice = price * quantity;
                    dr["totalprice"] = totalprice;

                    dttb.Rows.Add(dr);
                    GridView1.DataSource = dttb;
                    GridView1.DataBind();

                    Session["buyitems"] = dttb;
                    GridView1.FooterRow.Cells[4].Text = "Toplam Fiyat";
                    GridView1.FooterRow.Cells[5].Text = geneltoplam().ToString();
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
                    GridView1.FooterRow.Cells[4].Text = "Toplam Fiyat";
                    GridView1.FooterRow.Cells[5].Text = geneltoplam().ToString();
                }
            }
        }
        Label4.Text = DateTime.Now.ToShortDateString();
        findorderid();
    }

    public int geneltoplam()
    {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["buyitems"];
            int nrow = dt.Rows.Count;
            int i = 0;
            int gtotal = 0;
            while (i<nrow)
            {
                gtotal = gtotal + Convert.ToInt32(dt.Rows[i]["totalprice"].ToString());
                i = i + 1;
            }
            return gtotal;
    }

    public void findorderid()
    {
        String pass = "abcdefghijklmnopqrstuvwxyz123456789";
        Random r = new Random();
        char[] mypass = new char[5];
        for (int i = 0; i < 5; i++)
        {
            mypass[i] = pass[(int)(35 * r.NextDouble())];

        }
        String orderid;
        orderid = "Order" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + new string(mypass);

        Label3.Text = orderid;


    }

    public void saveaddress()
    {
        String updatepass = "insert into orderaddress(orderid,address,mobilenumber) values('" + Label3.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "')";
        string baglanti = "Data Source=FF\\SQLEXPRESS;Initial Catalog=ShoppingData;User ID=sa;Password=123";
        SqlConnection con = new SqlConnection(baglanti);
        con.Open();
        SqlCommand cmd1 = new SqlCommand();
        cmd1.CommandText = updatepass;
        cmd1.Connection = con;
        cmd1.ExecuteNonQuery();
        con.Close();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dttb = (DataTable)Session["buyitems"];

        for (int i = 0; i <= dttb.Rows.Count - 1; i++)
        {
            String updatepass= "insert into orderdetails(orderid,sno,productid,productname,price,quantity,dateoforder) values('" + Label3.Text + "'," + dttb.Rows[i]["sno"] + "," + dttb.Rows[i]["productid"] + ",'" + dttb.Rows[i]["productname"] + "'," + dttb.Rows[i]["price"] + "," + dttb.Rows[i]["quantity"] + ",'" + Label4.Text + "')";
            string baglanti = "Data Source=FF\\SQLEXPRESS;Initial Catalog=ShoppingData;User ID=sa;Password=123";
            SqlConnection con = new SqlConnection(baglanti);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = updatepass;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();

        }
        saveaddress();
        Response.Redirect("SonEkran.aspx");
    }
}