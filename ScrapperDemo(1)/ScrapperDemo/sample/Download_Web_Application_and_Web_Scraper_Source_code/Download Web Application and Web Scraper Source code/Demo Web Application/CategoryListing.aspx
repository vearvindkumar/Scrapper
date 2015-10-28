<%@ Page Title="Category Listing" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="CategoryListing.aspx.cs" Inherits="CategoryListing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <h5>
        Welcome to Category Listing Page</h5>
    <p>
        <a class="bold" href="ItemListing.aspx?category=MenWear" id="menWear">Men's Wear</a>
    </p>
    <p>
        <a class="bold" href="ItemListing.aspx?category=WomenWear" id="womenWear">Women's Wear</a>
    </p>
    <p>
        <a class="bold" href="ItemListing.aspx?category=ChildrenWear" id="ChildrenWear">Children Wear</a>
    </p>
</asp:Content>
