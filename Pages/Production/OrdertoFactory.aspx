<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="OrdertoFactory.aspx.cs" Inherits="Pages_Inventory_OrdertoFactory" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

     <asp:UpdatePanel ID="updatepanel" runat="server">
        <ContentTemplate>
            
             <asp:Label   ID="lblcostinglast" Visible="false" runat="server" ></asp:Label>
            <div class="row">
                <div class="col-md-12 text-center">
                    <h3>Order To Factory</h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-4">
                        <div class="col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Invoice No:"></asp:Label>
                        </div>
                        <div class="col-md-8">                       
                            <asp:TextBox ID="txtVoucherName" runat="server" Enabled="false"  class="form-controls"></asp:TextBox>
                        </div>
                    </div>
                   <div class="col-md-4">
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" Text="Order Date:"></asp:Label>
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
                     <div class="col-md-4">
                        <div class="col-md-3">
                            <asp:Label ID="Label3" runat="server" Text="Delivery Date:"></asp:Label>
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtDeliveryDate" runat="server"  class="form-controls"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDeliveryDate"
                                Format="yyyy/MM/dd">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDeliveryDate"
                                CssClass="failureNotification" ErrorMessage="Date required." ToolTip="Date required."
                                ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div> <br />
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
                                    <asp:DropDownList Width="95%" ID="ddlModel" runat="server" AutoPostBack="true" 
                                        onselectedindexchanged="ddlModel_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Unit">
                                <ItemTemplate>
                                    <asp:DropDownList Width="95%" ID="ddlUnit" runat="server">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Price" Visible="false" >
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

                             <asp:TemplateField HeaderText="Remarks">
                                <ItemTemplate>
                                   <asp:TextBox ID="txtRemarks" runat="server" Width="95%"></asp:TextBox>
                                </ItemTemplate>                               
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtTotal"  runat="Server" Width="95%" Enabled="false" />
                                </ItemTemplate>
                                <FooterTemplate>
                                     <asp:Label  Visible="false" ID="lblcosting" runat="server" ></asp:Label>
                                </FooterTemplate>
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
                <div class="col-md-11">
                 <asp:DataList ID="rptimage" RepeatDirection="Horizontal" runat="server">
                <ItemTemplate>
                 <img width="150" height="150" src="../../ProductImage/<%#Eval("PID") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt="<%#Eval("Name") %>" onerror="this.src='images/noimage.jpg'">   
                 <br />
                 <asp:Label ID="lblPname" runat="server" Text='<%#Eval("Pname") %>'></asp:Label> 
                 <asp:Label ID="Label4" runat="server" Text='<%#Eval("Model") %>'></asp:Label> 
                </ItemTemplate>
                </asp:DataList>
                </div>                 
            </div>

            <div class="row">
                <div class="col-md-1">
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-success" Width="150px" Text="Save" OnClick="btnSave_Click" />
                    </div>
                    <div class="col-md-9">
                       <asp:Button ID="btnSessionOut" runat="server" CssClass="btn-danger" Text="Clear All" 
                 onclick="btnSessionOut_Click" />
                </div>
            </div>

        <%--    
            <asp:GridView ID="GridView2" ShowFooter="True" sh Width="100%" AutoGenerateColumns="False"
                runat="server" EmptyDataText="Empty Store">
                <Columns>
                    <asp:TemplateField HeaderText="Item BarCode" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                     <img width="150" height="150" src="../../ProductImage/<%#Eval("PID") %>/<%#Eval("Name") %><%#Eval("Extention") %>" alt="<%#Eval("Name") %>" onerror="this.src='images/noimage.jpg'">   
                    </ItemTemplate>
                        <ControlStyle Height="20px" Width="100px" />
                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>--%>         
        </ContentTemplate>
    </asp:UpdatePanel>





</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

