<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="PurchaseAccessoriesReport.aspx.cs" Inherits="Pages_Procurement_PurchaseAccessoriesReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Accessories  Purchase  Report</h3>
                    
                </center>
        </div>
    </div>

    <div class="row" style="border: inset">
        <br />
        <div class="col-md-12">

            <div class="col-md-5">
                <div class="col-sm-6">
                    From Date :    
                    <asp:TextBox ID="txtDate1" runat="server"  placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender1" runat="server" TargetControlID="txtDate1"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate1"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-6">
                    To Date :   
                    <asp:TextBox ID="txtDate2" runat="server"  OnTextChanged="txtDate2_TextChanged" placeholder="YYYY-MM-DD" AutoPostBack="true" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender2" runat="server" TargetControlID="txtDate2"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate2"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <%-- <div class="col-md-2">
                    <asp:Button runat="server" ID="btndatefilter" Text="FilterResults" OnClick="btndatefilter_Click" />
                </div>--%>
            </div>


            <div class="col-md-7">
                <div class="col-sm-6">
                    Vendor Name :
              <asp:DropDownList ID="ddlsupliername" AutoPostBack="true"  CssClass="form-control" OnSelectedIndexChanged="ddlsupliername_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                </div>

                <div class="col-md-6">
                 
                        Search By Accessories :
              <asp:DropDownList ID="ddlitem"  AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                   
                </div>
            </div>
        </div>

        <%--     <div class="col-md-12">
            <div class="col-md-4">
                <div class="col-sm-8">
                    Search By Product Item :
              <asp:DropDownList ID="ddlitem"  AutoPostBack="true" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                </div>
            </div>
        </div>--%>
    </div>
    <hr />
    <br />
    <div style="overflow: scroll;">
            <asp:GridView ID="GridView1" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="50" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" Width="100%">

            <Columns>

                <asp:TemplateField HeaderText="Voucher No." ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblvoucherno" runat="server" Visible="true" Text='<%# Eval("VoucherNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="150px"/>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="unit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblunit" runat="server" Visible="true" Text='<%# Eval("unit") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SupplierName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblsupname" runat="server" Visible="true" Text='<%# Eval("SupplierName") %>'></asp:Label>
                    </ItemTemplate>

                    <ControlStyle  Width="200px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Accessories" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblproitem" runat="server" Visible="true" Text='<%# Eval("productItem") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="quantity" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" runat="server" Visible="true" Text='<%# Eval("quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblAllquantity" Font-Size="Larger" Font-Bold="true" runat="server" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText=" Total" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbltotal" runat="server" Visible="true" Text='<%# Eval("Total") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblAlltotal" Font-Size="Larger" Font-Bold="true" runat="server" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>

                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Visible="true" Text='<%# Eval("date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

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
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

