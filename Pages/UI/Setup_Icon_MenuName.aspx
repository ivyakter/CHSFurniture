<%@ Page Title="Icon & Menu Setup" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="Setup_Icon_MenuName.aspx.cs" Inherits="Pages_UI_Setup_Icon_MenuName" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<center>
 <div style="width:100%; background-color: #F0FFFF; border-radius: 25px;">
              <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="False"  Width="85%"
                    CellPadding="3" GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" 
                    BorderStyle="None" BorderWidth="1px" >
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" />                      
                        <asp:TemplateField HeaderText="Menu Id">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRoll" Width="150px" runat="server" Text='<%#Eval("id") %>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Menu Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRegNo" Width="250px" runat="server" Text='<%#Eval("text") %>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Menu Icon">
                            <ItemTemplate>
                                <asp:TextBox ID="txtSession" Width="250px" runat="server" Text='<%#Eval("Icon") %>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>                        

                        <asp:TemplateField ShowHeader="false">
                            <ItemTemplate>                                
                                <asp:Label ID="lblid" runat="server" Text='<%#Eval("id") %>' Visible="false"></asp:Label>
                                <asp:Button ID="btnprint" runat="server" Text="Update" OnClick="btnprint_Click" />                              
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                    <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                    <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <SortedAscendingCellStyle BackColor="#F4F4FD" />
                    <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                    <SortedDescendingCellStyle BackColor="#D8D8F0" />
                    <SortedDescendingHeaderStyle BackColor="#3E3277" />
                </asp:GridView>
                </asp:Panel>
            </div>
</center>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" Runat="Server">
</asp:Content>

