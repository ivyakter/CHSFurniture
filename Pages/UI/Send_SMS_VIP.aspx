<%@ Page Title="VIP SMS" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true"
    CodeFile="Send_SMS_VIP.aspx.cs" Inherits="UI_Send_SMS_VIP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<script type="text/javascript">
    function HeaderClick(CheckBox) {
        //Get target base & child control.
        var TargetBaseControl =
       document.getElementById('<%= this.GridView1.ClientID %>');
        var TargetChildControl = "chkAttend";

        //Get all the control of the type INPUT in the base control.
        var Inputs = TargetBaseControl.getElementsByTagName("input");

        //Checked/Unchecked all the checkBoxes in side the GridView.
        for (var n = 0; n < Inputs.length; ++n)
            if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                Inputs[n].checked = CheckBox.checked;
        //Reset Counter
        Counter = CheckBox.checked ? TotalChkBx : 0;
    }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <asp:Label ID="Label2" runat="server" Text="Student List:"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowHeaderWhenEmpty="true"
            EmptyDataText="no data found" CellPadding="4" ForeColor="#333333" GridLines="Vertical"
            Width="600px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="S/N">
                    <ItemTemplate>                       
                        <%# Container.DataItemIndex+1 %>
                    </ItemTemplate>
                    <ControlStyle Width="20px" />
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="Name">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="address" HeaderText="Address">
                    <ControlStyle Width="528px" />
                </asp:BoundField>
                <asp:BoundField DataField="Designation" HeaderText="Designation">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:BoundField DataField="contactno" HeaderText="Mobile No">
                    <ControlStyle Width="50px" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAll" runat="server" Checked="true" onclick="javascript:HeaderClick(this);" /></HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAttend" runat="server" CssClass="chkItem" />
                    </ItemTemplate>
                    <ControlStyle Width="40px" />
                    <HeaderStyle HorizontalAlign="Left" />
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <table>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lbl1" runat="server" Text="Enter Message Here"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:TextBox ID="txtsms" runat="server" Height="91px" Width="600px" TextMode="MultiLine"></asp:TextBox> <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator" ErrorMessage="Message could not be blank" ForeColor="Red" runat="server" ControlToValidate="txtsms"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btnsubmit" runat="server" OnClick="btnsubmit_Click" Text="Send" Width="73px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">                                        
                                       Total SMS Send:  <asp:Label ID="lblTotal" ForeColor="Red" runat="server" Text=""></asp:Label> <br />
                                        <asp:Label ID="lblmgs" runat="server" ForeColor="Red" Text=""></asp:Label><br />
                                    </td>
                                </tr>
                            </table>
    </center>
</asp:Content>
