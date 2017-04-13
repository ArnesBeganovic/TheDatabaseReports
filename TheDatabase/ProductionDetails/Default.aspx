<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheDatabase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>

        <asp:DropDownList ID="ddl_VehicleList" runat="server" AutoPostBack="true">
            <asp:ListItem Value="V4">V4</asp:ListItem>
            <asp:ListItem Value="2">Y283 (S60)</asp:ListItem>
            <asp:ListItem Value="3">Y413 (XC60)</asp:ListItem>
            <asp:ListItem Value="4S">526 4S</asp:ListItem>
            <asp:ListItem Value="5">Y555 (V40)</asp:ListItem>
            <asp:ListItem Value="52">Y352 (V60)</asp:ListItem>
            <asp:ListItem Value="53">V60 CC</asp:ListItem>
            <asp:ListItem Value="6">Y556 (XC40)</asp:ListItem>
            <asp:ListItem Value="81">Y381 (XC70)</asp:ListItem>
            <asp:ListItem Value="85">Y285 (V70)</asp:ListItem>
            <asp:ListItem Value="86">Y286 (S80)</asp:ListItem>
            <asp:ListItem Value="V1">V541 (S90)</asp:ListItem>
            <asp:ListItem Value="V2">V542 (V90)</asp:ListItem>
            <asp:ListItem Value="V3">V543 (V90 XC)</asp:ListItem>
            <asp:ListItem Value="V6">V526 (SPA XC90)</asp:ListItem>

        </asp:DropDownList>
        <asp:Button ID="btn_ExportToExcel" runat="server" OnClick="btn_ExportToExcel_Click" Text="Export To Excel" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <Columns>
                <asp:BoundField DataField="Vehicle" HeaderText="Vehicle" SortExpression="Vehicle" />
                <asp:BoundField DataField="VCC" HeaderText="VCC" SortExpression="VCC" />
                <asp:BoundField DataField="QuantM1" HeaderText="QuantM1" SortExpression="QuantM1" />
                <asp:BoundField DataField="VehM1" HeaderText="VehM1" SortExpression="VehM1" />
                <asp:BoundField DataField="JCI" HeaderText="JCI" SortExpression="JCI" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </div>
        
    </form>
</body>
</html>
