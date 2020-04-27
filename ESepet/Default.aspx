<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" ForeColor="Red" Text="A dan Z ye Herşey"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Italic="True" ForeColor="Red" Text="HOŞGELDİNİZ.."></asp:Label>
            <br />
            <br />
&nbsp;Sepetinizde&nbsp;
            <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label>
&nbsp;adet ürün bulunmaktadır.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" ForeColor="Blue" NavigateUrl="~/SepeteEkle.aspx">Sepeti Göster</asp:HyperLink>
            <br />
            <br />
            <asp:DataList ID="DataList1" runat="server" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource1" GridLines="Vertical" Height="551px" RepeatColumns="3" RepeatDirection="Horizontal" Width="599px" OnItemCommand="DataList1_ItemCommand">
                <AlternatingItemStyle BackColor="#DCDCDC" />
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
                <ItemTemplate>
                    <br />
                    <table border="1" class="auto-style1">
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="Label4" runat="server" Text="Product ID"></asp:Label>
                                &nbsp;&nbsp;
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("ProductID") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Label ID="Label6" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ProductImage") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">Fiyat&nbsp;
                                <asp:Label ID="Label7" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                &nbsp; TL</td>
                        </tr>
                        <tr>
                            <td style="text-align: center">Adet&nbsp;
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandArgument='<%# Eval("productid")%>' CommandName="SepeteEkle" Height="55px" ImageUrl="~/resimler/sepet.jpg" Width="90px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            </asp:DataList>
             <br />
            <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SerdarinMagazasiConnectionString %>" SelectCommand="SELECT * FROM [ProductDetail]"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
