<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Pages_Cart_Cart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:Label runat="server" ID="sessionuser"></asp:Label>

    <div id="content">
        <div class="content-page woocommerce">
            <div class="container">
                <div class="cart-content-page">
                    <h2 class="title-shop-page">my cart</h2>



                    <asp:GridView ID="GridView1" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound"
                        OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting"
                        OnRowCommand="GridView1_RowCommand" CssClass="table table-striped table-bordered table-hover" DataKeyNames="pid" AutoGenerateColumns="False"
                        runat="server" Visible="False" EmptyDataText="Empty Shopping Cart">

                        <AlternatingRowStyle BackColor="White" />

                        <Columns>
                            <asp:TemplateField HeaderText="Product Id" ItemStyle-HorizontalAlign="Center" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("pid") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                         <%--    <asp:TemplateField HeaderText="Barcode" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblBarcode" runat="server" Text='<%# Eval("Barcode") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="Product Image" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <img src="../../ProductImage/<%#Eval("pid") %>/<%#Eval("Imagename")%><%#Eval("Imageextension")%>" width="70" height="70" alt="<%#Eval("Imagename")%>" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product Name" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblpname" runat="server" Text='<%# Eval("pname") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" FooterStyle-HorizontalAlign="Right">
                                <ItemTemplate>
                                    <asp:Button ID="btdcre" runat="server" Text="-" CommandName="decrement" Visible="false" CausesValidation="false"
                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    <asp:Label ID="LblQ" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                                    <%--<asp:Button ID="btincre" runat="server" Text="+" CommandName="increment" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />--%>
                                    <asp:Button ID="btincre" runat="server" Text="+" CausesValidation="false" CommandName="increment" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCtyUpdate" runat="server" Width="20px" Text='<%# Eval("quantity") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ControlStyle Height="20px" Width="50px" />
                                <FooterStyle HorizontalAlign="Right"></FooterStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Unit Price" FooterStyle-Font-Bold="True" FooterStyle-HorizontalAlign="Left"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lblprice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    &nbsp;
                            <asp:Label ID="Label1" runat="server" Text="Grand Total :"></asp:Label>
                                </FooterTemplate>
                                <FooterStyle HorizontalAlign="Center" Font-Bold="True"></FooterStyle>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Total Price" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotal" runat="server" Text='<%# Eval("total") %>'></asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Label ID="lbltt" Font-Bold="true" runat="server" />
                                </FooterTemplate>
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:CommandField ButtonType="Button" ShowDeleteButton="True" />
                        </Columns>



                    </asp:GridView>


                </div>
                <br />
                <br />

                <div class="row" style="text-align: center">

                    <%-- <a href="CheckOut.aspx" class="btn btn-danger btn-md">Check Out</a>--%>

                    <asp:Button ID="btOrder" runat="server" CssClass="btn btn-info" Text="Order Now" CausesValidation="false" OnClick="btOrder_Click" />
                    &nbsp;&nbsp;&nbsp;
                           <a href="../../Default.aspx" class="btn btn-danger btn-md">Continur Shopping</a>
                </div>

                <%--//////////////////////--%>

                <div class="col-md-12" id="paymentoption">
                    <asp:Panel ID="Panel2" runat="server" Visible="false">
                        <asp:Label Text="Please Choice Payment Option" Font-Italic="true" Font-Size="Larger" ForeColor="Red" runat="server" ID="lblpayment"></asp:Label>
                        <hr />
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="#cod">cash On Delivery</a></li>
                            <li><a data-toggle="tab" href="#wallets">Payment On Mobile</a></li>
                            <li><a data-toggle="tab" href="#cards">CREDIT/DEBIT CARDS</a></li>

                        </ul>

                        <div class="tab-content col-sm-12">

                            <div id="cod" class="tab-pane fade in active">
                                <div style="font-size: inherit; line-height: inherit;">
                                    <p>Pay cash at your doorstep at the time of order delivery.</p>
                                    <p style="margin: 17px 0"></p>
                                    <p style="margin: 17px 0"><b>Important:</b></p>
                                    <p style="margin: 17px 0">Please have the exact amount available as our delivery driver may not be carrying sufficient change.</p>
                                    <p style="margin: 17px 0"></p>
                                    <p style="margin: 17px 0">If you have multiple items in an order, you might not receive every item at same time. Don't worry - all your items will arrive shortly.</p>
                                    <p style="margin: 17px 0"></p>
                                    <p style="margin: 17px 0"><b>Caution: Final Step </b></p>
                                    <p style="margin: 17px 0">This is the final step. Once you click "Confirm Order", you will not be able to change or edit your order. </p>
                                    <p>To cancel, edit or change your order go back to cart page <a href="<%=Page.ResolveUrl("~")%>EcommerceUI/Home.aspx" target="_blank"><font color="Blue">click here</font></a></p>
                                    <p style="margin: 17px 0"></p>
                                    <p style="margin: 17px 0">Please note that we have the right to refuse or cancel any order at any time whether or not the order has been confirmed and your credit card charged. In case of cancellation of prepaid orders (fully or partially), full amount paid by the customer will be refunded within 2-3 business days of cancelling the orders.</p>
                                    <p style="margin: 17px 0">*By clicking "Confirm Order" you are agreeing to all </p>
                                    <div>
                                        <asp:Button ID="btncod" UseSubmitBehavior="false" CausesValidation="false" runat="server" Text="Confirm Cash On Delivery" CssClass="btn btn-danger" OnClick="btncod_Click" />
                                    </div>
                                </div>

                            </div>

                            <div id="wallets" class="tab-pane fade">
                                <div style="font-size: inherit; line-height: inherit;">
                                    <p>Pay online using your <b>Bkash, Rocket, M-Cash, SureCash or other Mobile Payment account.</b></p>
                                    <p style="margin: 17px 0"></p>
                                    <p><b>To complete payment:</b></p>
                                    <p>Step 1- Click Confirm Order below</p>
                                    <p>Step 2- Select your Mobile Payment provider</p>
                                    <p>Step 3- Fill in your details and click Pay Now</p>
                                    <p style="margin: 17px 0"></p>
                                    <p><b>Cancellation  Policy: </b></p>

                                    <p style="margin: 17px 0">Please have the exact amount available as our delivery driver may not be carrying sufficient change.</p>
                                    <p style="margin: 17px 0"></p>
                                    <p><b>Online Refund Policy:</b></p>
                                    <p style="margin: 17px 0"></p>
                                    <p>Online refund will take 7 to 10 working days. It might take longer based on bank and transaction method.</p>
                                    <p>*By clicking "Confirm Order" you are agreeing to all <a href="<%=Page.ResolveUrl("~")%>" style="color: blue;">Terms &amp; Conditions.</a></p>

                                    <div>
                                        <%-- <asp:Button ID="btnShowLogin" runat="server" Text="Confirm Mobile payment" CssClass="btn btn-danger" />--%>


                                        <asp:Button ID="Button1" CssClass="btn btn-primary btn-md" runat="server" Text="Pay With Mobile" />



                                        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="Button1"
                                            CancelControlID="Button2" BackgroundCssClass="Background">
                                        </cc1:ModalPopupExtender>

                                        <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">



                                            <div class="modal-dialog">
                                                <div class="modal-content">
                                                    <div class="modal-header">



                                                        <asp:Label ID="lbltotalamount" Font-Size="XX-Large" Text="Choice Your Option : " Visible="true" Font-Bold="true" runat="server" />
                                                        <asp:Label ID="lblttformidel" Font-Size="XX-Large" Visible="true" Font-Bold="true" runat="server" />



                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="col-md-12">
                                                            <div class="row">
                                                                <div class="col-md-3">
                                                                    <div class="logoDesigner">
                                                                        <div class="single-products">
                                                                            <div class=" row text-center">
                                                                                <div class="col-md-12">
                                                                                    <div class="DesignerImage">
                                                                                        <img class="img-responsive" src="<%=Page.ResolveUrl("~")%>images/bkash2.png" alt="No IMG" />
                                                                                    </div>
                                                                                    <div class="Lavel">
                                                                                        <div class="ratting">
                                                                                            <span style="font-style: italic; font-size: small">Our number is  01685793893</span>

                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row DesignerName">
                                                                                <div class="col-md-12">

                                                                                    <asp:Button ID="bkashtransaction" Text="Select" runat="server" OnClick="bkashtransaction_Click1" Class="btn btn-primary btn-sm" />
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-3">
                                                                    <div class="logoDesigner">
                                                                        <div class="single-products">
                                                                            <div class=" row text-center">
                                                                                <div class="col-md-12">
                                                                                    <div class="DesignerImage">
                                                                                        <img class="img-responsive" src="<%=Page.ResolveUrl("~")%>images/Rocket.png"  style="height:113px;" alt="No IMG" />
                                                                                    </div>
                                                                                    <div class="Lavel">
                                                                                        <div class="ratting">
                                                                                            <span style="font-style: italic; font-size: small">Our number is  01685793893</span>

                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row DesignerName">
                                                                                <div class="col-md-12">

                                                                                    <asp:Button ID="btnrocket" Text="Select" runat="server" OnClick="btnrocket_Click" Class="btn btn-primary btn-sm" />
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="col-md-3">
                                                                    <div class="logoDesigner">
                                                                        <div class="single-products">
                                                                            <div class=" row text-center">
                                                                                <div class="col-md-12">
                                                                                    <div class="DesignerImage">
                                                                                        <img class="img-responsive" src="<%=Page.ResolveUrl("~")%>images/bkash2.png" alt="No IMG" />
                                                                                    </div>
                                                                                    <div class="Lavel">
                                                                                        <div class="ratting">
                                                                                            <span style="font-style: italic; font-size: small">Our number is  01685793893</span>

                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="row DesignerName">
                                                                                <div class="col-md-12">

                                                                                    <asp:Button ID="btndbbl" Text="Select" runat="server" OnClick="btndbbl_Click" Class="btn btn-primary btn-sm" />
                                                                                </div>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="modal-footer" style="border-top:none">
                                             
                                                        <asp:Button ID="Button2" runat="server" class="btn btn-default" Text="Close" />
                                                    </div>
                                                </div>
                                            </div>


                                            <br />
                                        </asp:Panel>

                                    </div>
                                </div>

                            </div>
                            <div id="cards" class="tab-pane fade">
                                <div style="font-size: inherit; line-height: inherit;">
                                    <p><b>Please ensure your card is active and on hand to fill in your details.</b></p>
                                    <p style="margin: 17px 0"></p>
                                    <p>Click Confirm Order below to complete payment and check-out.</p>

                                    <p style="margin: 17px 0"></p>
                                    <p><b>Cancellation  Policy: </b></p>

                                    <p style="margin: 17px 0">Please have the exact amount available as our delivery driver may not be carrying sufficient change.</p>
                                    <p style="margin: 17px 0"></p>
                                    <p><b>Online Refund Policy:</b></p>
                                    <p style="margin: 17px 0"></p>
                                    <p>Online refund will take 7 to 10 working days. It might take longer based on bank and transaction method.</p>
                                    <p>*By clicking "Confirm Order" you are agreeing to all <a href="<%=Page.ResolveUrl("~")%>" style="color: blue;">Terms &amp; Conditions.</a></p>

                                    <div>
                                        <div>
                                            <%-- <asp:Button ID="btnShowLogin" runat="server" Text="Confirm Mobile payment" CssClass="btn btn-danger" />--%>


                                            <asp:Button ID="btncard" CssClass="btn btn-primary btn-md" OnClick="btncard_Click" runat="server" Text="Pay With card" />

                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>

                    </asp:Panel>
                </div>


                <%--///////////////////////--%>

                <div class="col-md-12">
                    <asp:Panel ID="Panel1" runat="server" Visible="false">
                        <div class="col-md-6 col-md-offset-3">

                            <asp:Label Text="Please Fillup All Information To Confirm Order" Font-Italic="true" Font-Size="Larger" ForeColor="Red" runat="server" ID="lblconfirm"></asp:Label>
                            <hr />
                            <div class="row form-group">
                                <asp:Label for="email" Text="Name :" runat="server" ID="lblname" class="col-sm-3 control-label">
                                </asp:Label>
                                <div class="col-sm-9 inputGroupContainer">
                                    <div class="input-group">

                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Full Name" />
                                        <span class="input-group-addon"><i class="fa fa-user" aria-hidden="true"></i></span>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtname"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>


                            <div class="row form-group">
                                <asp:Label ID="lblemaul2" runat="server" Text="Email :" class="col-sm-3 control-label">
                                </asp:Label>
                                <div class="col-sm-9 inputGroupContainer">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtemail" runat="server" class="form-control" placeholder="Email" />
                                        <span class="input-group-addon"><i class="fa fa-envelope" aria-hidden="true"></i></span>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtemail2"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label runat="server" Text="Mobile :" ID="lblmobile" class="col-sm-3 control-label">
                                </asp:Label>
                                <div class="col-sm-9 inputGroupContainer">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="Mobile" />
                                        <span class="input-group-addon"><i class="fa fa-phone" aria-hidden="true"></i></span>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row form-group">
                                <asp:Label Text="Address :" runat="server" ID="lblpass2" class="col-sm-3 control-label">
                                </asp:Label>
                                <div class="col-sm-9 inputGroupContainer">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class="form-control" placeholder="Address" />

                                        <span class="input-group-addon"><i class="fa fa-address-card-o" aria-hidden="true"></i></span>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="text-danger" runat="server" ErrorMessage="This field is Required !" ControlToValidate="txtpass2"></asp:RequiredFieldValidator>--%>
                                    </div>
                                </div>
                            </div>


                            <div class="col-sm-9">
                                <asp:Button ID="btSubmit" runat="server" Text="Submit" CssClass="btn btn-default" CausesValidation="false" OnClick="btSubmit_Click" />
                                <asp:Label ID="lblemailresult" runat="server"></asp:Label>
                            </div>
                            <asp:Label ID="lblcustomerid" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblms" runat="server" Visible="false"></asp:Label>

                        </div>
                    </asp:Panel>

                </div>

            </div>
        </div>
    </div>





</asp:Content>

