<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TheDatabase.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
    <div>

        
        <asp:Table ID="Table1" runat="server" Height="70px" Width="600px">
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large" ForeColor="#FF6600" Height="60px" VerticalAlign="Top">Production Summary</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Font-Names="Arial" ForeColor="#FF9966" HorizontalAlign="Right" VerticalAlign="Middle">Select Vehicle</asp:TableCell>
                <asp:TableCell runat="server" Width="100px">
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
                



</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow runat="server">
                <asp:TableCell runat="server" Font-Names="Arial" ForeColor="#FF9966" HorizontalAlign="Right" VerticalAlign="Middle">Previous Months</asp:TableCell>
                <asp:TableCell runat="server" Width="100px">
                    <asp:DropDownList ID="ddl_SelMonth" runat="server" AutoPostBack="true">
                        <asp:ListItem Value="1">One</asp:ListItem> 
                        


<asp:ListItem Value="2">Two</asp:ListItem>
                        


<asp:ListItem Value="3">Three</asp:ListItem>
                        


<asp:ListItem Value="4">Four</asp:ListItem>
                        


<asp:ListItem Value="5">Five</asp:ListItem>
                        


<asp:ListItem Value="6">Six</asp:ListItem>                                  
                    


</asp:DropDownList>
                


</asp:TableCell>
                <asp:TableCell runat="server" VerticalAlign="Middle" HorizontalAlign="Right">
                    <asp:Button ID="btn_ExportToExcel" runat="server" OnClick="btn_ExportToExcel_Click" Text="Export To Excel" />
                


</asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Vehicle" HeaderText="Vehicle" SortExpression="Vehicle" />
                <asp:BoundField DataField="VCC" HeaderText="VCC" SortExpression="VCC" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="ADNT" HeaderText="ADNT" SortExpression="ADNT" />

                <asp:BoundField DataField="QuantM1" HeaderText="Quantity" SortExpression="QuantM1" Visible="False"/>
                <asp:BoundField DataField="VehM1" HeaderText="Vehicles" SortExpression="VehM1" Visible="False"/>

                <asp:BoundField DataField="QuantM2" HeaderText="Quantity" Visible="False" />
                <asp:BoundField DataField="VehM2" HeaderText="Vehicles" Visible="False" />

                <asp:BoundField DataField="QuantM3" HeaderText="Quantity" Visible="False" />
                <asp:BoundField DataField="VehM3" HeaderText="Vehicles" Visible="False" />

                <asp:BoundField DataField="QuantM4" HeaderText="Quantity" Visible="False" />
                <asp:BoundField DataField="VehM4" HeaderText="Vehicles" Visible="False" />

                <asp:BoundField DataField="QuantM5" HeaderText="Quantity" Visible="False" />
                 <asp:BoundField DataField="VehM5" HeaderText="Vehicles" Visible="False" />

                <asp:BoundField DataField="QuantM6" HeaderText="Quantity" Visible="False" />
                <asp:BoundField DataField="VehM6" HeaderText="Vehicles" Visible="False" />

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
