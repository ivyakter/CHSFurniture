<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MainMaster.master" AutoEventWireup="true" CodeFile="ProductsByCategory.aspx.cs" Inherits="Pages_Home_ProductsByCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <asp:Label runat="server" Font-Bold="true" Font-Size="XX-Large" ForeColor="#663300" ID="lblemptydate"></asp:Label>
    <div id="fas1" class="tab-pane active">
        <div class="product-slider12">
            <div class="wrap-item" data-pagination="false" data-navigation="true" data-itemscustom="[[0,1],[480,2],[768,3],[980,4],[1200,5]]">
              <asp:Label runat="server" ID="lblloigin" Visible="false"></asp:Label>
                <asp:Repeater ID="rptrproductsbysubcat" runat="server">
                    <ItemTemplate>


                         <div class="item-product">

                                                <div class="product-thumb">
                                                    <a href='<%# String.Concat("../ProductDetails.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link">
                                                        <img src="../../ProductImage/<%#Eval("PID") %>/<%#Eval("Name")%><%#Eval("Extention")%>" alt="<%#Eval("Name")%>" />
                                                    </a>
                                                    <a href='<%# String.Concat("../quickview.aspx?PID=", Eval("PID").ToString()) %>' class="quickview-link plus fancybox.iframe">quick view</a>

                                                </div>
                                                <div class="product-info">
                                                    <h3 class="product-title"><a href='<%# String.Concat("../Details.aspx?PID=", Eval("PID").ToString()) %>' class="product-thumb-link"><%# Eval("ProductName") %></a></h3>
                                                 
                                                    <div class="product-price" style="text-align:left">
                                                      <span style="font-size:small">Price :</span>  £ <ins><span><%# Eval("CostingPrice") %></span></ins> 
                                                    </div>
                                                    <br />
                                                <asp:HiddenField ID="hfPId" Value='<%# Eval("PNID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("ProductName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("CostingPrice") %>' runat="server" />
                                                   <%-- <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />--%>
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />

                                                   <%-- <asp:HiddenField ID="hfCatID" Value='<%# Eval("CategoryID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfSubCatID" Value='<%# Eval("SubCategoryID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfBrandID" Value='<%# Eval("PBrandID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfPId" Value='<%# Eval("PID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfname" Value='<%# Eval("PName") %>' runat="server" />
                                                    <asp:HiddenField ID="hfprice" Value='<%# Eval("PSelPrice") %>' runat="server" />
                                                    <asp:HiddenField ID="hfproductid" Value='<%# Eval("ProductID") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimagename" Value='<%# Eval("Name") %>' runat="server" />
                                                    <asp:HiddenField ID="hfimageExtesion" Value='<%# Eval("Extention") %>' runat="server" />--%>

                                                </div>
                                            </div>

                 
                    </ItemTemplate>
                </asp:Repeater>


            </div>
        </div>
    </div>



</asp:Content>

