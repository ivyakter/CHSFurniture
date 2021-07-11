<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="SalarySheet.aspx.cs" Inherits="Pages_Accounts_SalarySheet" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=4.1.60919.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <div class="col-md-12 h3 text-center">
        <div class="row">
            Salary Payment   
        </div>
    </div>


    <div class="col-md-12" style="padding-top: 20px;">
        <div class="row">
        
            <div class="col-md-2">
                Select Date
            </div>
            <div class="col-md-3">

                <asp:TextBox CssClass="form-control" ID="txtDateto" runat="server" Width="200" placeholder="dd/MM/yyyy"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM-dd" TargetControlID="txtDateto"></cc1:CalendarExtender>
                <br />

            </div>

        </div>
    </div>

    <div class="row">

        <div class="col-md-12">
            <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                OnRowCommand="Gridview1_RowCommand" OnRowDataBound="Gridview1_RowDataBound" BackColor="White"
                BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="Row No." />

                    <asp:TemplateField HeaderText="&nbsp; Employee Name">
                        <ItemTemplate>
                            <asp:DropDownList Width="95%" ID="ddllabour" CssClass="form-control js-example-placeholder-single" AutoPostBack="true" OnSelectedIndexChanged="ddllabour_SelectedIndexChanged" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Month For">
                            <ItemTemplate>
                                <asp:TextBox ID="txtMonthFor" runat="server" Width="80%"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="yyyy-MM"
                                    TargetControlID="txtMonthFor">
                                </cc1:CalendarExtender>
                            </ItemTemplate>
                            <ControlStyle Width="100px" />
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:TemplateField>

                    <asp:TemplateField HeaderText="Basic Salary">
                        <ItemTemplate>
                            <asp:TextBox ID="txtbasicsalary"  Enabled="false" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Payment">
                        <ItemTemplate>
                            <asp:TextBox ID="txtpayment" OnTextChanged="txtpayment_TextChanged" AutoPostBack="true" Width="95%"  runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Due">
                        <ItemTemplate>
                            <asp:TextBox ID="txtdue" runat="server" Enabled="false"  Width="95%" />
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Pay Button">
                        <ItemTemplate>
                            <asp:Button ID="btnpay" runat="server" Text="Pay" Width="50px" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Pay" />
                        </ItemTemplate>
                        <ControlStyle Width="80%" />
                        <HeaderStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="delete" runat="server" Text="Del" OnClick="delete_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>


                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">
        </div>
        <div class="col-md-10">
            <table width="100%">
                <tr>
                    <br />
                    <asp:Label ID="label6" runat="server" Text="Comment"></asp:Label>
                    <td align="left">
                        <asp:TextBox ID="txtComment" Width="85%" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
    </div>

       <%--For Auto complete dropdown--%>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/css/select2.min.css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.3/js/select2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".js-example-placeholder-single").select2({
                placeholder: "Select",
                allowClear: true
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

