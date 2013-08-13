<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MobileVoting.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entrance Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink href="/Admin" runat="server">Original MVC Web App</asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink href="/WebForms/SupervisingController/Views/QuestionList/QuestionList.aspx" runat="server">MVP + Supervising Controller</asp:HyperLink>
        </div>
        <div>
            <asp:HyperLink href="/WebForms/WebFormsMvp/Views/QuestionList/QuestionList.aspx" runat="server">MVP + WebFormsMVP</asp:HyperLink>
        </div>
    </form>
</body>
</html>
