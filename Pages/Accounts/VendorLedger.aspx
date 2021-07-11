<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="VendorLedger.aspx.cs" Inherits="Pages_Accounts_VendorLedger" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Vendor Ledger</h3>
                    
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
                    <asp:TextBox ID="txtDate2" runat="server" placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
                    <asp:CalendarExtender ID="DateClanaderExtender2" runat="server" TargetControlID="txtDate2"
                        Format="yyyy/MM/dd">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate2"
                        CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                        ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                </div>

            </div>


            <div class="col-md-7">


                <div class="col-md-6">
                    Search By Vendor :
              <asp:DropDownList ID="ddlVendor" AutoPostBack="true" CssClass="form-control js-example-placeholder-single" OnSelectedIndexChanged="ddlVendor_SelectedIndexChanged" runat="server">
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

    <br />

    <div class="row">
    </div>


    <div class="row" style="overflow: scroll;">
        <div class="col-md-12">
              <div class="col-md-6">
            <asp:GridView ID="GridView1" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" ShowFooter="true" Font-Size="10" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" >

                <Columns>

                    <asp:TemplateField HeaderText="Trans_Type" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTrans_Type" runat="server" Visible="true" Text='<%# Eval("Trans_Type") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Payment_Client" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPayment_Client" Width="100px" runat="server" Visible="true" Text='<%# Eval("Payment_Client") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="150px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="VoucherNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblVoucherNo" runat="server" Visible="true" Text='<%# Eval("VoucherNo") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="date" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Visible="true" Text='<%# Eval("Date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Credit Amount" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblqty" runat="server" Visible="true" Text='<%# Eval("Credit") %>'></asp:Label>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Label ID="lblAllquantity" Font-Size="Larger" Font-Bold="true" runat="server" />
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                  </div>
       <div class="col-md-1">
            </div>
            <div class="col-md-5">
                   <asp:GridView ID="GridView2" AllowPaging="true" OnRowDataBound="GridView2_RowDataBound" CssClass="table table-striped table-bordered table-hover" Font-Size="10"  ShowFooter="true"  runat="server" OnPageIndexChanging="GridView2_PageIndexChanging" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="VoucherNo" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblVoucherNo" runat="server" Visible="true" Text='<%# Eval("VoucherNo") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="productItem" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblproductItem" runat="server" Visible="true" Text='<%# Eval("productItem") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="80px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="quantity" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblquantity" runat="server" Visible="true" Text='<%# Eval("quantity") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="unit" Visible="false" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblunit" runat="server" Visible="true" Text='<%# Eval("unit") %>'></asp:Label>
                        </ItemTemplate>
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price"  ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblPrice" runat="server" Visible="true" Text='<%# Eval("Price") %>'></asp:Label>
                        </ItemTemplate>        
                         <FooterTemplate>
                            <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                        </FooterTemplate>
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>              
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="ProductCost"  Visible="false" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblProductCost" runat="server" Visible="true" Text='<%# Eval("ProductCost") %>'></asp:Label>
                        </ItemTemplate>                      
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="lblTotal" runat="server" Visible="true" Text='<%# Eval("Total") %>'></asp:Label>
                        </ItemTemplate>  
                         <FooterTemplate>
                            <asp:Label ID="lblallTotal" Font-Size="Larger" Font-Bold="true" runat="server" />
                        </FooterTemplate>  
                        <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>                    
                        <ControlStyle Height="20px" Width="50px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>


                </Columns>
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
                
            </div>
        </div>
    </div>
         
          <div class="row">
        <div class="col-md-12">

            <div class="col-md-3"></div>

            <div class="col-md-5">

                <div class="col-md-12 text-center">
                    <h3>Total Paid And Purchased</h3>

                    <div class="col-md-6" style="border: 1px solid">
                        <asp:Label ID="Label1" runat="server" Text="Total Paid :"></asp:Label>
                        <asp:Label ID="lbltotalpayment" runat="server"></asp:Label>
                    </div>

                    <div class="col-md-6" style="border: 1px solid">
                        <asp:Label ID="Label2" runat="server" Text="Total purchased :"></asp:Label>
                        <asp:Label ID="lbltotalpurchased" runat="server"></asp:Label>
                    </div>
                </div>

                <div class="col-md-12 text-center">
                    <h3>Total Due</h3>
                    <div class="col-md-6" style="border: 1px solid">
                        <asp:Label ID="Label3" runat="server" Text="Total Due :"></asp:Label>
                        <asp:Label ID="lbltotaldue" runat="server"></asp:Label>
                    </div>

                    <div class="col-md-6" style="border: 1px solid">
                    </div>
                </div>
           
            </div>


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

