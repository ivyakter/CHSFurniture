<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="SaleVoucherEdit.aspx.cs" Inherits="Pages_Sales_SaleVoucherEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:Label ID="lbltotal" runat="server" Visible="false"></asp:Label>
    <div class="h2 text-red text-center">
       Accessories Sales Invoice Edit
    </div>

    <%--    <div class="row">--%>
    <asp:Panel ID="PanelAccessories" runat="server">

        <hr />
        <div class="row">
            <%--     <div class="col-md-2">
                </div>--%>
            <div class="col-md-12">
                <div class="col-md-6">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Invoice No:"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtVoucherName" runat="server" Enabled="false"  class="form-controls"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtDate" runat="server"  class="form-controls"></asp:TextBox>
                            <asp:CalendarExtender ID="DateClanaderExtender" runat="server" TargetControlID="txtDate"
                                Format="yyyy/MM/dd">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="Client Name:"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <%-- <asp:TextBox ID="txtSupplierName" runat="server"   class="form-controls"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddlClientname"  CssClass="form-control js-example-placeholder-single" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                </div>              
        </div>
            </div>
        <hr />
        <div class="row">
            <%--  <div class="col-md-1">
                </div>--%>
            <div class="col-md-12">
                <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                    OnRowCommand="Gridview1_RowCommand" OnRowDataBound="Gridview1_RowDataBound" BackColor="White"
                    BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:BoundField DataField="RowNumber" HeaderText="Row No." />

                        <asp:TemplateField HeaderText="&nbsp; Product Item">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfddlItem" runat="server" Value='<%#Eval("Column1") %>' />
                                <asp:DropDownList Width="95%"  ID="ddlItem" CssClass="form-control js-example-placeholder-single" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:HiddenField ID="hfddlModel" runat="server" Value='<%#Eval("Column2") %>' />
                                    <asp:DropDownList Width="200px" ID="ddlModel" CssClass="form-control js-example-placeholder-single" runat="server" >
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                        <asp:TemplateField HeaderText="Unit">
                            <ItemTemplate>
                                <asp:HiddenField ID="hfddlUnit" runat="server" Value='<%#Eval("Column3") %>' />
                                <asp:DropDownList Width="200px" ID="ddlUnit" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:TextBox ID="txtPrice" Text='<%#Eval("Column4") %>' Width="95%"  runat="server" />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" />
                            </FooterTemplate>
                        </asp:TemplateField>

                        <%--  <asp:TemplateField HeaderText="Dram/Bag(Qty)">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQtyDramorBag"  runat="server" Width="95%" />
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="Pc/Kg(Qty)">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("Column5") %>'  AutoPostBack="true" Width="95%" OnTextChanged="txtQuantity_TextChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:TextBox ID="txtTotal"  Text='<%#Eval("Column6") %>' runat="Server" Width="95%" Enabled="false" />
                            </ItemTemplate>
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
                        <asp:TextBox ID="txtAllTotal" Visible="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txtComment" Width="85%" TextMode="MultiLine" Height="80px" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="row">
            <div class="col-md-1">
            </div>
            <div class="col-md-11" style="float: initial;">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </asp:Panel>

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
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

