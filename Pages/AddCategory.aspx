<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/AdminMaster.master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="Pages_Set_AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript" language="javascript">

        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=imgCurrent1.ClientID%>').prop('src', e.target.result)
                };
                reader.readAsDataURL(input.files[0]);
                }

            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <br />
    <br />

<%--    <asp:UpdatePanel ID="updatepanel1" runat="server">
        <ContentTemplate>--%>


            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-8 col-md-offset-1">


                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-md-2">
                                    Category ID :
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtcatid" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-2">
                                    Category Name:
                                </label>
                                <div class="col-md-4">
                                    <asp:TextBox CssClass="form-control" ID="txtcategoryname" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2">
                                    Big Image(680x300):
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fuImg01" ToolTip="Size : 680x300" CssClass="form-control" runat="server" onchange="ShowImagePreview(this);" />
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-2">
                                    Small Image(180x195):
                                </label>
                                <div class="col-md-4">
                                    <asp:FileUpload ID="fuImg02" ToolTip="Size : 180x195" CssClass="form-control" runat="server" onchange="ShowImagePreview(this);" />
                                </div>
                            </div>




                            <div class="form-group">
                                <div class="col-md-10 col-sm-9 col-md-offset-2 col-sm-offset-3">
                                    <asp:Button CssClass="Button" ID="btnSave" runat="Server" Text="Save" meta:resourcekey="btnSaveResource1"
                                        OnClick="btnSave_Click" />
                                  
                                    <asp:Button CssClass="Button" ID="hlkBack" Text="Back" runat="server" PostBackUrl="ListCategory.aspx"
                                        CausesValidation="False" meta:resourcekey="hlkBackResource1" />
                                </div>
                            </div>
                        </div>
                    </div>




                    <div class="col-md-3">

                        <asp:Image ID="imgCurrent1" runat="server" Height="150px" Width="150px" ImageAlign="Middle" /><br />
                        <span style="color: Red">Big Image Dimention : 440x550</span>

                    </div>
                </div>
            </div>
 <%--       </ContentTemplate>
    </asp:UpdatePanel>--%>



</asp:Content>

