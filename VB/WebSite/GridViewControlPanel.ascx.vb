Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class GridViewControlPanel
	Inherits System.Web.UI.UserControl
	Private grid As ASPxGridView
	Private gridID_Renamed As String

	Public Property GridID() As String
		Get
			Return Me.gridID_Renamed
		End Get
		Set(ByVal value As String)
			Me.gridID_Renamed = value
		End Set
	End Property
	Public Property HeaderText() As String
		Get
			Return Me.ASPxPopupControlDemo.HeaderText
		End Get
		Set(ByVal value As String)
			Me.ASPxPopupControlDemo.HeaderText = value
		End Set
	End Property
	Public Property LinkText() As String
		Get
			Return Me.ASPxHyperLinkDemo.Text
		End Get
		Set(ByVal value As String)
			Me.ASPxHyperLinkDemo.Text = value
		End Set
	End Property
	Protected Sub ASPxHyperLinkDemo_Init(ByVal sender As Object, ByVal e As EventArgs)
		Dim hyperLink As ASPxHyperLink = CType(sender, ASPxHyperLink)
		hyperLink.ClientSideEvents.Click = String.Format("function(s, e) {{ ShowHidePopUpControl({0}); }}", ASPxPopupControlDemo.ClientID)
	End Sub
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		CreateControlCheckBoxes()
	End Sub
	Private Sub CreateControlCheckBoxes()
		If String.IsNullOrEmpty(Me.GridID) Then
			Throw New NullReferenceException("GridID property is null.")
		End If
		grid = TryCast(NamingContainer.FindControl(GridID), ASPxGridView)
		If grid Is Nothing Then
			Throw New InvalidOperationException("ASPxGridView control was not found in NamingContainer.")
		End If

		For Each column As GridViewDataColumn In Me.grid.Columns
			Dim columnCheckBox As New ASPxCheckBox()
			columnCheckBox.ID = "chb" & column.VisibleIndex.ToString()
			ASPxPopupControlDemo.Controls.Add(columnCheckBox)

			columnCheckBox.AutoPostBack = True
			columnCheckBox.Text = column.FieldName
			columnCheckBox.Checked = column.Visible
			AddHandler columnCheckBox.CheckedChanged, AddressOf columnCheckBox_CheckedChanged
		Next column

	End Sub
	Private Sub columnCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
		Dim columnCheckBox As ASPxCheckBox = CType(sender, ASPxCheckBox)
		Me.grid.Columns(columnCheckBox.Text).Visible = columnCheckBox.Checked
	End Sub
End Class