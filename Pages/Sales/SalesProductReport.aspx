<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="SalesProductReport.aspx.cs" Inherits="Pages_Sales_SalesProductReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

         <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp;Sales Product Report</h3>
                    
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

            <div class="col-md-3"></div>
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
                    <asp:TextBox ID="txtDate2" runat="server"  OnTextChanged="txtDate2_TextChanged" AutoPostBack="true" placeholder="YYYY-MM-DD" class="form-control"></asp:TextBox>
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


        <asp:GridView ID="GridView1" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" Width="100%">

            <Columns>

                <asp:TemplateField HeaderText="Item" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblItem" runat="server" Visible="true" Text='<%# Eval("Item") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblPrice" runat="server" Visible="true" Text='<%# Eval("Price") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Unit" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblsupname" runat="server" Visible="true" Text='<%# Eval("Unit") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblQuantity" runat="server" Visible="true" Text='<%# Eval("Quantity") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="amount" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" runat="server" Visible="true" Text='<%# Eval("amount") %>'></asp:Label>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Label ID="lblAllquantity" Font-Size="Larger" Font-Bold="true" runat="server" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Center" Font-Size="Larger" Font-Bold="True"></FooterStyle>
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
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

