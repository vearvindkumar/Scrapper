<%@ Page Language="C#" AutoEventWireup="true" AspCompat="true" CodeBehind="Default.aspx.cs" Inherits="GenomeClassifier.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Website Text</title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div id="commandConsole" class="childBlock">
        <div class="childContent">
            <h2>Get Website Text:</h2>
            <asp:Button ID="btnWebSiteText" runat="server" Text="Get URLText" onclick="btnWebSiteText_Click"/>
            <asp:Button ID="btnReset" runat="server" Text="Reset" onclick="btnReset_Click"/>
            <br />
            <asp:TextBox ID="commandLog" class="scroll" runat="server" BorderStyle="None" TextMode="MultiLine" Wrap="False">Enter URL Here</asp:TextBox>
            <br />
        </div>
    </div>
    <p id="copyright">© 2012 jakemdrew.com. All rights reserved.</p>
    <!--http://freegraphicdownload.com/3d-dna-icon-free-stock-photo/-->
    </form>
</body>
</html>
