<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SepeteEkle.aspx.cs" Inherits="SepeteEkle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" Text="A dan Z ye Herşey"></asp:Label>
            <br />
            <br />
            Sepetinizdeki ürün sayısı
            <asp:Label ID="Label2" runat="server" Font-Bold="True"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#0066FF" NavigateUrl="~/Default.aspx">Mağazaya tekrar git</asp:HyperLink>
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Height="365px" ShowFooter="True" style="text-align: center" Width="804px" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="sno" HeaderText="Sıra No">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="productid" HeaderText="Ürün ID">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:ImageField DataImageUrlField="productimage" HeaderText="Ürün Görseli">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:ImageField>
                    <asp:BoundField DataField="productname" HeaderText="Ürün Adı">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="price" HeaderText="Fiyat">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="quantity" HeaderText="Adet">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="totalprice" HeaderText="Toplam Fiyat">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField SelectText="Görüntüle/Düzenle" ShowSelectButton="True" />
                    <asp:CommandField DeleteText="Sepetten Çıkart" ShowDeleteButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" Font-Underline="False" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" Height="57px" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
        <p>
            &nbsp;</p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Onay Ekranına Git" Width="132px" />
    </form>
</body>
</html>
