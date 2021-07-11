<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="SalaryReport.aspx.cs" Inherits="Pages_Accounts_SalaryReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp;Salary Total </h3>
                    
                </center>
        </div>
    </div>

    <div class="row" style="border: inset">
        <center>
          &nbsp;   <asp:Label ID="lblsalesid" runat="server" Visible="true" Text="Search Here" Font-Size="XX-Large" Font-Bold="true"  ForeColor="Red"></asp:Label>
        </center>
        <br />
        <br />
        <div class="col-md-12">
            <div class="col-md-2">
            </div>
            <div class="col-md-5">
                <div class="col-sm-6">
                    From Date :    
                    <asp:TextBox ID="txtDate1" runat="server" Height="20px" placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender1" runat="server" TargetControlID="txtDate1"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate1"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-6">
                    To Date :   
                    <asp:TextBox ID="txtDate2" runat="server" Height="20px" placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender2" runat="server" TargetControlID="txtDate2"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate2"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btncalculate" runat="server" OnClick="btncalculate_Click" Text="Show" />

            </div>
        </div>
    </div>
    <br />

<%--    <div class="row text-center">
        <div class="col-md-12">
            <div class="col-md-6">
                <asp:Label ID="lbltotalPaymenttext" runat="server" Font-Size="XX-Large" Font-Bold="true" ForeColor="Red" Text="Total Payment"></asp:Label>
                :
                 <asp:Label ID="lbltotalPayment" Font-Size="XX-Large" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
            </div>

            <div class="col-md-6">
                <asp:Label ID="lbltotalduetext" runat="server" Font-Size="XX-Large" Font-Bold="true" ForeColor="Red" Text="Total Due"></asp:Label>
                :
                 <asp:Label ID="lbltotaldue" Font-Size="XX-Large" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
            </div>
        </div>
    </div>--%>



    <div class="row text-center">
        <div class="col-md-12">

            <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" ShowFooter="true" runat="server" AutoGenerateColumns="False" Width="100%">

                <Columns>

                  
                    <asp:TemplateField HeaderText="Employee ID" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblLabourID" runat="server" Visible="true" Text='<%# Eval("LabourID") %>'></asp:Label>
                        </ItemTemplate>
                        
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Employee Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblLabourName" runat="server" Visible="true" Text='<%# Eval("LabourName") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="200px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Month For" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblMonthFor" runat="server" Visible="true" Text='<%# Eval("MonthFor","{0:MMM-yyyy}") %>'></asp:Label>
                        </ItemTemplate>                      
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Date" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Visible="true" Text='<%# Eval("Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>                      
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="BasicSalary" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblBasicSalary" runat="server" Visible="true" Text='<%# Eval("BasicSalary") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalbasic" runat="server"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Payment" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPayment" runat="server" Visible="true" Text='<%# Eval("Payment") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotalpayment" runat="server"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Due" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblDue" runat="server" Visible="true" Text='<%# Eval("Due") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaldue" runat="server"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>

        </div>
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

