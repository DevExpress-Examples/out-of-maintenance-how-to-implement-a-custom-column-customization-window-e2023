using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxRoundPanel;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxGridView;

public partial class GridViewControlPanel : System.Web.UI.UserControl {
	private ASPxGridView grid;
	private string gridID;

	public string GridID {
		get { return this.gridID; }
		set { this.gridID = value; }
	}
	public string HeaderText {
		get { return this.ASPxPopupControlDemo.HeaderText; }
		set { this.ASPxPopupControlDemo.HeaderText = value; }
	}
	public string LinkText {
		get { return this.ASPxHyperLinkDemo.Text; }
		set { this.ASPxHyperLinkDemo.Text = value; }
	}
	protected void ASPxHyperLinkDemo_Init(object sender, EventArgs e) {
		ASPxHyperLink hyperLink = (ASPxHyperLink)sender;
		hyperLink.ClientSideEvents.Click = string.Format("function(s, e) {{ ShowHidePopUpControl({0}); }}", ASPxPopupControlDemo.ClientID);
	}
	protected void Page_Load(object sender, EventArgs e) {
		CreateControlCheckBoxes();
	}
	private void CreateControlCheckBoxes() {
		if (string.IsNullOrEmpty(this.GridID))
			throw new NullReferenceException("GridID property is null.");
		grid = NamingContainer.FindControl(GridID) as ASPxGridView;
		if (grid == null)
			throw new InvalidOperationException("ASPxGridView control was not found in NamingContainer.");
		foreach (GridViewDataColumn column in this.grid.Columns) {
                                          ASPxCheckBox columnCheckBox = new ASPxCheckBox();
                                          columnCheckBox.ID = "chb" + column.VisibleIndex.ToString();
                                          ASPxPopupControlDemo.Controls.Add(columnCheckBox);
			
                                          columnCheckBox.AutoPostBack = true;
			columnCheckBox.Text = column.FieldName;
			columnCheckBox.Checked = column.Visible;
			columnCheckBox.CheckedChanged += new EventHandler(columnCheckBox_CheckedChanged);
		}
	}
	void columnCheckBox_CheckedChanged(object sender, EventArgs e) {
		ASPxCheckBox columnCheckBox = (ASPxCheckBox)sender;
		this.grid.Columns[columnCheckBox.Text].Visible = columnCheckBox.Checked;
	}
}