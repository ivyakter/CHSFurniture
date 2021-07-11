<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="ChangeProductPrice.aspx.cs" Inherits="Pages_Accounts_ChangeProductPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Change Product Sell Price</h3>
                    
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

            <div class="col-md-6 col-md-offset-3">
                Search By Product :
              <asp:DropDownList ID="ddlproduct" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged" runat="server">
              </asp:DropDownList>

            </div>

        </div>
    </div>

    <br />


    <div class="row" style="overflow: scroll;">
        <div class="col-md-12">
            <div class="col-md-8 col-md-offset-2">
                <asp:GridView ID="GridView1" AllowPaging="true" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" ShowFooter="true" runat="server" AutoGenerateColumns="False" Width="100%">

                    <Columns>

                        <asp:TemplateField HeaderText=" ID" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblID" runat="server" Visible="true" Text='<%# Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ProductName" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblProductName" runat="server" Visible="true" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="CostingPricing" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblCostingPricing" runat="server" Visible="true" Text='<%# Eval("CostingPrice") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="SellPrice" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblSellPrice" runat="server" Visible="true" Text='<%# Eval("SellPrice") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txtsellprice" runat="server"></asp:TextBox>
                            </EditItemTemplate>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>


                        <asp:CommandField HeaderText="Edit" CausesValidation="false" ControlStyle-CssClass="btn btn-warning btn-xs" HeaderStyle-ForeColor="Black" ShowEditButton="true">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:CommandField>

                    </Columns>
                    <HeaderStyle Font-Bold="True" ForeColor="Black" />
                    <AlternatingRowStyle BackColor="White" />


                </asp:GridView>

            </div>
            <div class="col-md-1"></div>


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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>

