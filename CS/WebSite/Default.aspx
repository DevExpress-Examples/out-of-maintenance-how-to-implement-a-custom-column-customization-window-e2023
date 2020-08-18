<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Src="~/GridViewControlPanel.ascx" TagPrefix="cp" TagName="GridViewControlPanel" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>How to implement a custom Column Customization window</title>
</head>
<body>
	<form id="mainForm" runat="server">
	<div>
		<cp:GridViewControlPanel ID="cp1" runat="server" HeaderText="Grid View Control Panel"
			LinkText="Show Grid View Control Panel" GridID="ASPxGridViewDemo" />
		<br />
		<dx:ASPxGridView ID="ASPxGridViewDemo" runat="server" AutoGenerateColumns="False"
			DataSourceID="AccessDataSourceDemo" KeyFieldName="EmployeeID">
			<Columns>
				<dx:GridViewDataTextColumn FieldName="EmployeeID" ReadOnly="True" VisibleIndex="0">
					<EditFormSettings Visible="False" />
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="1">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="2">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="3">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="4">
				</dx:GridViewDataTextColumn>
				<dx:GridViewDataTextColumn FieldName="HomePhone" VisibleIndex="5">
				</dx:GridViewDataTextColumn>
			</Columns>
		</dx:ASPxGridView>
	</div>
	<asp:AccessDataSource ID="AccessDataSourceDemo" runat="server" DataFile="~/App_Data/nwind.mdb"
		SelectCommand="SELECT [EmployeeID], [LastName], [FirstName], [Title], [Country], [HomePhone] FROM [Employees]">
	</asp:AccessDataSource>
	</form>
</body>
</html>