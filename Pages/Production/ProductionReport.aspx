<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ProductionReport.aspx.cs" Inherits="Pages_Inventory_ProductionReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Production Report</h3>
                    
                </center>
        </div>
    </div>

    <div class="row" style="border: inset">
        <br />
        <div class="col-md-12">

            <div class="col-md-5">
                <div class="col-sm-6">
                    From Date :    
                    <asp:TextBox ID="txtDate1" runat="server" placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender1" runat="server" TargetControlID="txtDate1"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate1"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-6">
                    To Date :   
                    <asp:TextBox ID="txtDate2" runat="server"  AutoPostBack="true" OnTextChanged="txtDate2_TextChanged" placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
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
        <%--        <div class="col-sm-6">
                    Vendor Name :
              <asp:DropDownList ID="ddlsupliername" AutoPostBack="true" Height="20px" OnSelectedIndexChanged="ddlsupliername_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                </div>--%>

                <div class="col-md-6">
                 
                        Search By Product :
              <asp:DropDownList ID="ddlitem" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                   
                </div>
            </div>
        </div>

        <%--     <div class="col-md-12">
            <div class="col-md-4">
                <div class="col-sm-8">
                    Search By Product Item :
              <asp:DropDownList ID="ddlitem" Height="20px" AutoPostBack="true" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                </div>
            </div>
        </div>--%>
    </div>
    <hr />
    <br />
    <div style="overflow: scroll;">


        <asp:GridView ID="GridView1" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" Width="100%">

            <Columns>

                <asp:TemplateField HeaderText="OrderID" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblOrderID" runat="server" Visible="true" Text='<%# Eval("OrderID") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

               
                <asp:TemplateField HeaderText="InvoiceNo" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblInvoiceNo" runat="server" Visible="true" Text='<%# Eval("InvoiceNo") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle Height="20px" Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="ProductName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblProductName" runat="server" Visible="true" Text='<%# Eval("ProductName") %>'></asp:Label>
                    </ItemTemplate>

                    <ControlStyle Height="20px" Width="200px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
               
                <asp:TemplateField HeaderText="Model" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblModel" runat="server" Visible="true" Text='<%# Eval("Model") %>'></asp:Label>
                    </ItemTemplate>

                    <ControlStyle Height="20px" Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="UNIT" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblproitem" runat="server" Visible="true" Text='<%# Eval("UNIT") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                    <ControlStyle Height="20px" Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" runat="server" Visible="true" Text='<%# Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblAllquantity" Font-Size="Larger" Font-Bold="true" runat="server" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>
                    <ControlStyle Height="20px" Width="100px" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

