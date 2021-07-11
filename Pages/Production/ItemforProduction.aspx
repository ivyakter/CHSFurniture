<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ItemforProduction.aspx.cs" Inherits="Pages_Production_ItemforProduction" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <%--   <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>--%>
    <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>


            <div class="row">
                <div class="col-md-12">
                  <center>
                   <h4>Accessories Select For Production</h4></center> 
                </div>
            </div>
            <div class="row">
          
                <div class="col-md-12">
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
                    <%--    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="Vendor Name:"></asp:Label>
                        </div>
                        <div class="col-md-8">                        
                            <asp:DropDownList ID="ddlsuppliername" OnSelectedIndexChanged="ddlsuppliername_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label5" runat="server" Text="Vendor ID :"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtsupplierid"  runat="server" class="form-controls"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label4" runat="server" Text="Address:"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtAddress"  runat="server" class="form-controls"></asp:TextBox>
                        </div>
                    </div>
                    <br />--%>
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

                            <asp:TemplateField HeaderText="&nbsp; Product Item">
                                <ItemTemplate>
                                    <asp:DropDownList Width="95%" ID="ddlItem" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                              <asp:TemplateField HeaderText="Model">
                                <ItemTemplate>
                                    <asp:DropDownList Width="95%" ID="ddlModel" runat="server"  AutoPostBack="true" onselectedindexchanged="ddlModel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Unit">
                                <ItemTemplate>
                                    <asp:DropDownList Width="95%" ID="ddlUnit" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Price" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPrice" Width="95%"  runat="server" />
                                </ItemTemplate>
                            
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="Pc/Kg(Qty)">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtQuantity" runat="server"  AutoPostBack="true" Width="95%" OnTextChanged="txtQuantity_TextChanged" />
                                </ItemTemplate>
                                    <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" OnClick="ButtonAdd_Click1" />
                                </FooterTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTotal"  runat="Server" Width="95%" Enabled="false" />
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


        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

