<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="MSI.Catastros.Web.Reporst" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reportes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding-right: 15px; padding-left: 15px; margin-right: auto; margin-left: auto; width: 856px;">
            <CR:CrystalReportViewer ID="crvReportes" runat="server" AutoDataBind="true" PrintMode="ActiveX" EnableDatabaseLogonPrompt="False" />
        </div>
    </form>
</body>
<a href="Reports.aspx">Reports.aspx</a>
</html>
