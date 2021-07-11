<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="CostingSheet.aspx.cs" Inherits="Pages_Accounts_CostingSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="row">
        <div class="col-md-12">
            <center>
                    <h3>
                        &nbsp; Client Ledger</h3>
                    
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
            <div class="col-md-6">
                <asp:GridView ID="GridView1" AllowPaging="true" CssClass="table table-striped table-bordered table-hover" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="10" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound" runat="server" AutoGenerateColumns="False" Width="100%">

                    <Columns>

                        <asp:TemplateField HeaderText="Product ID" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblProductID" runat="server" Visible="true" Text='<%# Eval("ProductID") %>'></asp:Label>
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

                        <asp:TemplateField HeaderText="Accessorie sName" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoriesName" runat="server" Visible="true" Text='<%# Eval("AccessoriesName") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblQuantity" runat="server" Visible="true" Text='<%# Eval("Quantity") %>'></asp:Label>
                            </ItemTemplate>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Price" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Visible="true" Text='<%# Eval("Price") %>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbltotaltext" runat="server" Text="Total"></asp:Label>
                            </FooterTemplate>
                            <FooterStyle HorizontalAlign="Center" Font-Size="X-Large" Font-Bold="True"></FooterStyle>
                            <ControlStyle Height="20px" Width="100px" />
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="AccessoriesTotal" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lblAccessoriesTotal" runat="server" Visible="true" Text='<%# Eval("AccessoriesTotal") %>'></asp:Label>
                            </ItemTemplate>
                              <FooterTemplate>
                                <asp:Label ID="lblAccessoriesTotalToatal" Font-Size="Larger" Font-Bold="true" runat="server" />
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

