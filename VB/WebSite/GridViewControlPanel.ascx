<%@ Control Language="vb" AutoEventWireup="true" CodeFile="GridViewControlPanel.ascx.vb"
	Inherits="GridViewControlPanel" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<script type="text/javascript" language="javascript">
	function ShowHidePopUpControl(popUp) {
		if (!popUp.GetVisible()) 
			popUp.Show();
		else 
			popUp.Hide();
	}
</script>
<dx:ASPxHyperLink ID="ASPxHyperLinkDemo" runat="server" EnableClientSideAPI="True"
	NavigateUrl="javascript:void(0);" OnInit="ASPxHyperLinkDemo_Init">
</dx:ASPxHyperLink>
<dx:ASPxPopupControl ID="ASPxPopupControlDemo" runat="server" CloseAction="CloseButton"
	PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" AllowDragging="True">
	<ContentCollection>
		<dx:PopupControlContentControl runat="server">
		</dx:PopupControlContentControl>
	</ContentCollection>
</dx:ASPxPopupControl>