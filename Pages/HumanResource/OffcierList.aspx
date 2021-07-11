<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master"
    AutoEventWireup="true" CodeFile="OffcierList.aspx.cs" Inherits="Pages_HumanResource_OffcierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        function PrintDetailsView() {
            var detailsview = document.getElementById('<%= pnldate.ClientID %>');
            var printWindow = window.open('', '', 'width=1000,height=600,toolbar=0,scrollbars=1,status=0,resizable=1');
            printWindow.document.write(detailsview.outerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="col-md-12 table-responsive">
                <div>
                    <table class="table">
                        <tr>
                            <td align="right" style="width: 200px; padding-top: 12px; font-weight: 700;">
                                <asp:Label ID="label2" runat="server" Width="100px" Text="Designation:"></asp:Label>
                            </td>
                            <td align="left" style="width: 150px">
                                <asp:DropDownList ID="ddldesignation" OnSelectedIndexChanged="ddldesignation_SelectedIndexChanged"
                                    runat="server" class="form-control" Height="30px" Width="165px" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:Panel ID="pnldate" runat="server" Style="background-color: #FFFFFF" Width="100%">
                    <center>
                        <h3>
                            Employee List</h3>
                        <asp:GridView ID="gvOfficer" runat="server" AutoGenerateColumns="False" Font-Names="Arial"
                            Width="100%" Font-Size="11pt" ForeColor="#000" AlternatingRowStyle-BackColor="#C2D69B"
                            HeaderStyle-BackColor="green" OnRowCancelingEdit="gvOfficer_RowCancelingEdit"
                            OnRowEditing="gvOfficer_RowEditing" OnRowUpdating="gvOfficer_RowUpdating" OnPageIndexChanging="gvOfficer_PageIndexChanging"
                            PageSize="10">
                            <AlternatingRowStyle BackColor="#C2D69B"></AlternatingRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="Row No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="OfficerId" HeaderText="Officer Id"></asp:BoundField>
                                <asp:BoundField DataField="OFF_TYPE_NAME" HeaderText="Designation"></asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Officer Name"></asp:BoundField>
                                <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                                <asp:BoundField DataField="Mobile" HeaderText="Mobile"></asp:BoundField>
                                <asp:TemplateField HeaderText="OfficerId">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfficerId" Text='<%#Eval("OfficerId") %>' runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:Label ID="txtOfficerId" Text='<%#Eval("OfficerId") %>' runat="server"></asp:Label>
                                    </EditItemTemplate>
                                    <ControlStyle Width="80px" />
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>                               
                                <asp:CommandField HeaderText="Edit" ShowEditButton="true" />
                            </Columns>
                            <AlternatingRowStyle BackColor="#C2D69B" />
                        </asp:GridView>
                    </center>
                </asp:Panel>
                <asp:Button ID="btnprintDate" runat="server" Text="Print" OnClientClick="PrintDetailsView();"
                    Height="25px" Style="font-size: small;" Width="100px" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="Server">
</asp:Content>
