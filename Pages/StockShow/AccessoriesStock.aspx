<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AccessoriesStock.aspx.cs" Inherits="Pages_Stock_Show_AccessoriesStock" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Accessories  Purchase  Stock</h3>
                    
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


            <div class="col-md-7">
                <%--          <div class="col-sm-6">
                    Vendor Name :
              <asp:DropDownList ID="ddlsupliername" AutoPostBack="true"  OnSelectedIndexChanged="ddlsupliername_SelectedIndexChanged" runat="server">
              </asp:DropDownList>
                </div>--%>

                <div class="col-md-6">
                    Search By Accessories :
              <asp:DropDownList ID="ddlitem"  AutoPostBack="true"  CssClass="form-control js-example-placeholder-single"  OnSelectedIndexChanged="ddlitem_SelectedIndexChanged" runat="server">
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

                <asp:TemplateField HeaderText="ItemId" Visible="false" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblvoucherno" runat="server" Visible="true" Text='<%# Eval("ItemId") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="ItemName" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblunit" runat="server" Visible="true" Text='<%# Eval("ItemName") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="&nbsp; Model">
                    <ItemTemplate>
                        <asp:Label ID="lblModel" runat="server" Visible="true" Text='<%# Eval("Model") %>'></asp:Label>
                    </ItemTemplate>
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


                <asp:TemplateField HeaderText="date" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbldate" runat="server" Visible="true" Text='<%# Eval("LastUpdateDate", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                    <ControlStyle  Width="100px" />
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PresentStock" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lblqty" runat="server" Visible="true" Text='<%# Eval("PresentStock") %>'></asp:Label>
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

