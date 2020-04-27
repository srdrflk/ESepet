<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SiparisOnay.aspx.cs" Inherits="SiparisOnay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 49%;
            height: 74px;
        }
        .auto-style2 {
            width: 144px;
        }
        .auto-style3 {
            width: 59%;
            height: 169px;
            background-color: #99CCFF;
        }
        .auto-style4 {
            width: 175px;
            height: 68px;
        }
        .auto-style5 {
            width: 175px;
            height: 117px;
        }
        .auto-style6 {
            height: 117px;
        }
        .auto-style7 {
            height: 68px;
        }
        .auto-style8 {
            background-color: #66CCFF;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="A dan Z ye Herşey"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Sipariş Onay  Ekranı"></asp:Label>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Sipariş No</td>
                    <td>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Sipariş Tarihi</td>
                    <td>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="196px" ShowFooter="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="sno" HeaderText="S.No" />
                <asp:BoundField DataField="productid" HeaderText="Ürün ID" />
                <asp:BoundField DataField="productname" HeaderText="Ürün Adı" />
                <asp:BoundField DataField="price" HeaderText="Fiyat" />
                <asp:BoundField DataField="quantity" HeaderText="Adet" />
                <asp:BoundField DataField="totalprice" HeaderText="Toplam Fiyat" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br />
        <table border="1" class="auto-style3">
            <tr>
                <td class="auto-style5">Teslimat adresini yazınız</td>
                <td class="auto-style6">
                    <asp:TextBox ID="TextBox1" runat="server" Height="80px" TextMode="MultiLine" Width="269px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Telefon </td>
                <td class="auto-style7">
                    <asp:TextBox ID="TextBox2" runat="server" Height="25px" Width="265px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style8" Font-Bold="True" Height="45px" OnClick="Button1_Click" Text="ONAYLA" Width="176px" />
    </form>
</body>
</html>
