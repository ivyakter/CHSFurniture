<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Recieve_Payment_Repot.aspx.cs" Inherits="Pages_Accounts_Recieve_Payment_Repot" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Payment/Received Details Report</h3>
                    
                </center>
        </div>
    </div>
    <div class="row" style="border: inset">
        <center>
          &nbsp;   <asp:Label ID="lblsalesid" runat="server" Visible="true" Text="Search Here" Font-Size="XX-Large" Font-Bold="true"  ForeColor="Red"></asp:Label>
        </center>

        <div class="col-md-12">

            <div class="col-md-4">
                <div class="col-sm-4">
                    From Date :    
                    <asp:TextBox ID="txtDate1" runat="server"  placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender1" runat="server" TargetControlID="txtDate1"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate1"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-4">
                    To Date :   
                    <asp:TextBox ID="txtDate2" runat="server"  placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender2" runat="server" TargetControlID="txtDate2"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate2"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <asp:Button runat="server" ID="btndatefilter" Text="By Date" OnClick="btndatefilter_Click" />
                </div>

            </div>
            <div class="col-md-4">Debit / Cerdit<br />
              <asp:DropDownList ID="ddldborcr" AutoPostBack="true" OnSelectedIndexChanged="ddldborcr_SelectedIndexChanged" runat="server">

                <asp:ListItem Value="0">--Debit / Cerdit--</asp:ListItem>
                <asp:ListItem Value="1">Debit</asp:ListItem>
                <asp:ListItem Value="2">Credit</asp:ListItem>

            </asp:DropDownList>
            </div>
            <div class="col-md-4">
            <div class="col-md-4">
            
                            </div>
                            <div class="col-md-4">
        </div>
        <div class="col-md-4">
        Distributor:
          
                        </div>
            </div>
        </div>

    </div>
    <br />

    <div style="overflow: scroll;">

        <asp:GridView ID="GridView1" AllowPaging="true"  OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" Width="90%">

            <Columns>
                <asp:TemplateField HeaderText="Voucher No." ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblvoucherno" runat="server" Visible="true" Text='<%# Eval("VoucherNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Client Name" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblbarcode" runat="server" Visible="true" Text='<%# Eval("Client_Name") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Chart of Account" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblbarcode" runat="server" Visible="true" Text='<%# Eval("ChartofAccount") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Trans Type" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblbarcode" runat="server" Visible="true" Text='<%# Eval("Trans_Type") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText=" BankName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblbarcode" runat="server" Visible="true" Text='<%# Eval("BankName") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="BranchName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblitem" runat="server" Visible="true" Text='<%# Eval("BranchName") %>'></asp:Label>
                    </ItemTemplate>
                    <%--        <FooterTemplate>
                       <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
                        </FooterTemplate>
                   <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>--%>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Debit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" runat="server" Visible="true" Text='<%# Eval("Debit") %>'></asp:Label>
                    </ItemTemplate>
                    <%--  <FooterTemplate>
                              <asp:Label ID="lblttqty" Font-Size="Larger" Font-Bold="true" runat="server" />
                           </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>--%>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Credit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblprice" runat="server" Visible="true" Text='<%# Eval("Credit") %>'></asp:Label>
                    </ItemTemplate>
                    <%--      <FooterTemplate>
                              <asp:Label ID="lblttprice" Font-Size="Larger" Font-Bold="true" runat="server" />
                           </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>--%>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server"  Visible="true" Text='<%# Eval("Date","{0:d}") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <%--<asp:TemplateField HeaderText="Branch Name" ItemStyle-HorizontalAlign="Center">
                          <ItemTemplate>
                              <asp:Label ID="lblclientid" runat="server" Visible="true" Text='<%# Eval("BranchName") %>'></asp:Label>
                          </ItemTemplate>
                          <ControlStyle  Width="100px" />
                          <ItemStyle HorizontalAlign="Center"></ItemStyle>
                      </asp:TemplateField>--%>
            </Columns>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <AlternatingRowStyle BackColor="White" />
            
        </asp:GridView>
    </div>

    <div class="row">
        <div style="margin-left: 40%">
            <asp:Button ID="btnprint" runat="server" Text="Print" OnClientClick="myFunction();"
                Height="30px" Style="font-size: medium;" Width="197px" />
        </div>

    </div>

    <script>
        function myFunction() {
            window.print();
        }
    </script>



</asp:Content>

