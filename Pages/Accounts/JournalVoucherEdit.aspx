<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="JournalVoucherEdit.aspx.cs" Inherits="Pages_JournalVoucherEdit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <div style="height: 100%;">
        <asp:Panel ID="Panel1" runat="server">
            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-6">
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label" runat="server" Text="Journal Voucher No: "></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtJournalNo" runat="server" Enabled="false" CssClass="form-control Textbox"
                                    Style="height: 18px;"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="lblreference" runat="server" Text="Journal Type:"></asp:Label>
                            </div>
                            <div class="col-md-6">                           
                                <asp:DropDownList ID="ddlCashorCredit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCashorCredit_SelectedIndexChanged" CssClass="form-control">                               
                            </asp:DropDownList>
                             <asp:Label ID="lblBablance" runat="server"></asp:Label>
                            </div>
                        </div>
                           <div class="row form-group">
                            <div class="col-sm-3 col-sm-offset-1">
                                <asp:Label ID="label3" runat="server" Visible="false" Text="Bank Name"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                <asp:DropDownList ID="ddlBank" runat="server" class="form-control Textbox" Visible="false" style="height: 18px;">
                                </asp:DropDownList>
                            </div>
                        </div>   
                         <div class="row form-group">                     
                        <div class="col-sm-3 col-sm-offset-1">
                                <asp:Label ID="label8" runat="server" Visible="false" Text="Transaction No"></asp:Label>
                            </div>
                            <div class="col-sm-6">
                                 <asp:TextBox ID="txtCheck" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                            </div> 
                        </div> 
                    </div>
                    <div class="col-md-6" style="height: 25px;">
                        <div class="row form-group">
                            <div class="col-md-4">
                                <asp:Label ID="label5" runat="server" Text="Date"></asp:Label>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtDate" runat="server" CssClass="form-control" Style="height: 18px;
                                    width: 230px; margin-left: -5px;"></asp:TextBox>
                                <asp:CalendarExtender ID="DateClanaderExtender" runat="server" TargetControlID="txtDate"
                                    Format="yyyy-MM-dd">
                                </asp:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                    CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                                    ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                            </div>
                            <asp:Label ID="lbldiscode" runat="server" ></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

   
                <div>
            <div>
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
            </div>
            <br />
            <br />
            <asp:GridView ID="Gridview1" runat="server" ShowFooter="True" Width="100%" AutoGenerateColumns="False"
                CssClass="table" OnRowCommand="Gridview1_RowCommand" OnRowDataBound="Gridview1_RowDataBound"
                BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px"
                CellPadding="3" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="RowNumber" HeaderText="Row No." />
                    <asp:TemplateField HeaderText="Chart of Account">
                        <ItemTemplate>
                                 <asp:HiddenField ID="hfchartofacc" runat="server" Value='<%#Eval("Column1") %>' />
                                <asp:DropDownList ID="ddlChartofAccounts" CssClass="form-control js-example-placeholder-single" OnSelectedIndexChanged="ddlChartofAccounts_SelectedIndexChanged1" runat="server" Width="95%">
                                </asp:DropDownList>

                            <%--<asp:DropDownList ID="ddlChartofAccounts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlChartofAccounts_SelectedIndexChanged1" CssClass="form-control js-example-placeholder-single">
                            </asp:DropDownList>--%>
                        </ItemTemplate>
                    </asp:TemplateField>
             
                    <asp:TemplateField HeaderText="Debit">
                        <ItemTemplate>
                            <asp:TextBox ID="txtDebit" Text='<%#Eval("Column3") %>'   runat="server" Width="90%"></asp:TextBox>
                        </ItemTemplate>
                       <%--     <FooterTemplate>
                            <asp:Label ID="lbldebittotal"  Font-Bold="true" runat="server" />
                        </FooterTemplate>--%>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Credit">
                        <ItemTemplate>
                            <asp:TextBox ID="txtCredit"   Text='<%#Eval("Column2") %>'  runat="server" Width="90%"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Remarks">
                        <ItemTemplate>
                            <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" Visible="false" Text="Add New Row" OnClick="ButtonAdd_Click1" />
                        </FooterTemplate>
                    </asp:TemplateField>


                     <%-- <asp:BoundField DataField="journalid" HeaderText="Row No." />--%>

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
    
      

       <div class="col-md-12">
           <div class="col-md-2 col-md-offset-3">
                <asp:Label ID="lbldebittotal"  Font-Bold="true" runat="server" />
           </div>

             <div class="col-md-2 col-md-offset-3">
                <asp:Label ID="lblcredittotal"  Font-Bold="true" runat="server" />
           </div>
       </div>
  <%--      <div style="height: 20px; width: 90%; text-align: right;">
            Total Amount :
            <asp:TextBox ID="txtTotal" runat="server" Enabled="false"></asp:TextBox>
        </div>--%>
        <div class="">
            <div class="">
                <asp:Button ID="btnSave" runat="server" Text="Update" OnClick="btnSave_Click" />
            </div>
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

