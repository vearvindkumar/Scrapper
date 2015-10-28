<%@ Page Title="Item Listing Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="ItemListing.aspx.cs" Inherits="ItemListing" %>

<asp:Content ID="headContent" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="pageMainContent" ContentPlaceHolderID="MainContent" runat="Server">
    <table width="100%">
        <tr>
            <td align="right">
                <a class="categoryListing" id="categoryListing" runat="server" clientidmode="Static"
                    href="CategoryListing.aspx"><< Back to Category Listing</a>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:XmlDataSource ID="xmlSource" runat="server" DataFile="~/XMLDataBase/MenFashion.xml">
                </asp:XmlDataSource>
                <asp:GridView ID="gvItemListing" runat="server" DataSourceID="xmlSource" AutoGenerateColumns="false"
                    AllowPaging="true" PageSize="5" Width="100%" PagerSettings-Position="Bottom">
                    <Columns>
                        <asp:TemplateField HeaderText="Products">
                            <ItemTemplate>
                                <p id="productID" runat="server">
                                    ProductID: <b>
                                        <%# XPath("ProductID") %></b>
                                </p>
                                <p id="productName" runat="server">
                                    ProductName: <b>
                                        <%# XPath("ProductName")%></b></p>
                                <p id="productPrice" runat="server">
                                    ProductPrice: <b>
                                        <%# XPath("ProductPrice")%></b></p>
                                <p id="colorAvailable" runat="server">
                                    Colors Available: <b>
                                        <%# XPath("ColorAvailable")%></b></p>
                                <p id="deliveryDays" runat="server">
                                    Delivery Days: <b>
                                        <%# XPath("DeliveryDays")%></b></p>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
