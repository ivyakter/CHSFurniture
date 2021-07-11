<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="ClientInformation.aspx.cs" Inherits="Pages_HumanResource_Configuration_ClientInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class=" col-md-3">
    </div>
    <div class=" col-md-6">
        <table class="table" width="100%">
            <tr>
                <td align="right">
                    <asp:Label ID="label1" runat="server" Text="Client Id :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtClientId" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="label2" runat="server" Text="Client Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtClientName" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="right">
                    <asp:Label ID="label6" runat="server" Text="Business Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBusinessName" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="label3" runat="server" Text="Contact No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    <asp:Label ID="label4" runat="server" Text="Address :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td align="right">
                    <asp:Label ID="label7" runat="server" Text="Cart of Account :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlChartofAccounts" runat="server" CssClass="form-control js-example-placeholder-single">
                            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div class=" col-md-3">
    </div>
    <center>
        <asp:GridView ID="gvemployee" AutoGenerateColumns="False" ShowFooter="True" runat="server"  PageSize="100" OnPageIndexChanging="gvemployee_PageIndexChanging" CssClass="table table-striped table-bordered table-hover" 
            OnRowCommand="gvemployee_RowCommand" Width="100%" OnRowCancelingEdit="gvemployee_RowCancelingEdit"
            OnRowEditing="gvemployee_RowEditing" OnRowUpdating="gvemployee_RowUpdating">
            <Columns>
               <asp:TemplateField HeaderText="S/N" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" runat="server" Text="<%# Container.DataItemIndex + 1 %>" />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
                    <HeaderTemplate>
                        <span>&nbsp;</span>
                        <asp:Label ID="label5" runat="server" Text="Delete Row" Width="70px"
                            Height="30px" ForeColor="#000" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="btndelete" runat="server" CommandName="cmdDelete" CommandArgument='<%#Eval("ClientId")%>'
                            Text="Delete" Height="30px" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
             
                <asp:TemplateField HeaderText="Client Id">                   
                    <ItemTemplate>
                        <asp:Label ID="lblClientId" runat="server" Text='<%#Eval("ClientId") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtClientId" runat="server" Text='<%#Eval("ClientId") %>'></asp:TextBox>
                        <asp:TextBox ID="txtId" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client Name">                   
                    <ItemTemplate>
                        <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtClientName" runat="server" Text='<%#Eval("ClientName") %>'></asp:TextBox>                       
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Business Name">                   
                    <ItemTemplate>
                        <asp:Label ID="lblBusinessName" runat="server" Text='<%#Eval("BusinessName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBusinessName" runat="server" Text='<%#Eval("BusinessName") %>'></asp:TextBox>                       
                    </EditItemTemplate>
                </asp:TemplateField>
                  <asp:TemplateField HeaderText="Contact No">                   
                    <ItemTemplate>
                        <asp:Label ID="lblContactNo" runat="server" Text='<%#Eval("ContactNo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContactNo" runat="server" Text='<%#Eval("ContactNo") %>'></asp:TextBox>                       
                    </EditItemTemplate>
                </asp:TemplateField>                
                 <asp:TemplateField HeaderText="Address">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox>                           
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Account Type">                   
                    <ItemTemplate>
                        <asp:Label ID="lblAccName" runat="server" Text='<%#Eval("AccName") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                       <asp:TextBox ID="txtAccName" runat="server" Text='<%#Eval("AccName") %>'></asp:TextBox>                           
                    </EditItemTemplate>
                </asp:TemplateField>
         </Columns>
        </asp:GridView>
    </center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>
