<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu.ascx.cs" Inherits="UserControls_Menu" %>
<asp:Panel ID="AnmsMenuBar" runat="server" Visible="true">
    <div class="col-md-10">
        <div class="navbg">
            <div class="navbar navbar-default">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbarCollapse">
                        <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span> <span class="icon-bar"></span><span class="icon-bar"></span>
                    </button>
                </div>
                <div class="navbar-collapse collapse" id="navbarCollapse">
                    <ul class="nav navbar-nav">
                        <li class="dropdown"><a href="">HRM<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/">Attendance Report </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="~/">Employee Register </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="~/">Absent Report </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="~/">Late Report</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink97" runat="server" NavigateUrl="~/">Leave Report </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink98" runat="server" NavigateUrl="~/">Leave Status Report </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink99" runat="server" NavigateUrl="~/">Attendance Status</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/">Upload Excel File </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/">Attendance Entry </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/">Manage Leave  </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/">Assign to Shift </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink100" runat="server" NavigateUrl="~/">Assign Leave Category </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink101" runat="server" NavigateUrl="~/">Request for Leave </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink102" runat="server" NavigateUrl="~/">Approve Leave </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink103" runat="server" NavigateUrl="~/">Assign Attendance ID  </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink104" runat="server" NavigateUrl="~/">Assign IP for Attendance  </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink105" runat="server" NavigateUrl="~/">Employee Separation</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink106" runat="server" NavigateUrl="~/">Manage Disciplinary</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink107" runat="server" NavigateUrl="~/">Promotion </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink108" runat="server" NavigateUrl="~/">Search Staff </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink109" runat="server" NavigateUrl="~/">Assign Holiday</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink110" runat="server" NavigateUrl="~/">Attendance Entry (IP Free)</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink111" runat="server" NavigateUrl="~/">Assign Section </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink112" runat="server" NavigateUrl="~/">Manage Attendance</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink113" runat="server" NavigateUrl="~/">Assign Line</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink114" runat="server" NavigateUrl="~/">Leave Entry (Force)</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="~/">Administration </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="~/">Leave Category</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="~/Pages/HumanResource/Configuration/NewStaff.aspx">New Staff </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="~/">Shift Config</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink115" runat="server" NavigateUrl="~/">Assign Leave Category</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink116" runat="server" NavigateUrl="~/">Holiday Config</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink117" runat="server" NavigateUrl="~/">Disc. Maintenance</asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Payroll<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/">Salary Sheet</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/">Alter Salary Sheet </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/">Fixed Salary </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/">Variable Salary</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/">Salary Sheet</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/">Import Salary</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/">Manage Loan </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="~/">Request for Loan</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="~/">Manage OT </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="~/">Manage DT</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="~/">Wage Sheet</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="~/">Manage Salary</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink39" runat="server" NavigateUrl="~/">Sal. Parent Head </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink40" runat="server" NavigateUrl="~/">Salry Category/Grade </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink41" runat="server" NavigateUrl="~/">Salary Head </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink42" runat="server" NavigateUrl="~/">Set Salary</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="~/">Loan Category</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink44" runat="server" NavigateUrl="~/">Set OT Rate</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink45" runat="server" NavigateUrl="~/">Create Structure</asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Inventory <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/">Item Master</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/">Stock Summery </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/">Location Summery</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/">Voucher Reports </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/">Stock Movement </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/">Stock Reorder </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="~/">Stock Minimum </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink72" runat="server" NavigateUrl="~/">Slow/Fast Moving</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink73" runat="server" NavigateUrl="~/"> Profitability </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink74" runat="server" NavigateUrl="~/">Out of Stock</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink75" runat="server" NavigateUrl="~/">Store Ledger</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Analytics <b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink65" runat="server" NavigateUrl="~/">Tabulars </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink66" runat="server" NavigateUrl="~/">Graphical </asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="~/">Issue from Inventory </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="~/">New Requisition</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink34" runat="server" NavigateUrl="~/">Transfer Requisition </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink35" runat="server" NavigateUrl="~/">Manage Requisition </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink36" runat="server" NavigateUrl="~/">Damage Stock Out</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink37" runat="server" NavigateUrl="~/">Stock In </asp:HyperLink>
                                        </li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink38" runat="server" NavigateUrl="~/">Stock Out</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink46" runat="server" NavigateUrl="~/">Store Transfer</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink58" runat="server" NavigateUrl="~/">Batch</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink59" runat="server" NavigateUrl="~/">Stock Group</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink60" runat="server" NavigateUrl="~/">Stock Category </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink61" runat="server" NavigateUrl="~/">UOM </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink62" runat="server" NavigateUrl="~/">Store</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink63" runat="server" NavigateUrl="~/">Store Ledger</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink64" runat="server" NavigateUrl="~/">Voucher Setup </asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Accounts<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink47" runat="server" NavigateUrl="~/">Bank Reconciliation </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink48" runat="server" NavigateUrl="~/">Day Book </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink49" runat="server" NavigateUrl="~/">Ledger Report</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink50" runat="server" NavigateUrl="~/">PDC/BDC</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink51" runat="server" NavigateUrl="~/">Cash & Bank Book</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink52" runat="server" NavigateUrl="~/">Group Summery</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink53" runat="server" NavigateUrl="~/">Trial Balance</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink93" runat="server" NavigateUrl="~/">Cash Flow </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink94" runat="server" NavigateUrl="~/">Fixed Asset Report </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink95" runat="server" NavigateUrl="~/">Trading A/c</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink96" runat="server" NavigateUrl="~/">Profit & Loss </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink118" runat="server" NavigateUrl="~/">Balance Sheet </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink119" runat="server" NavigateUrl="~/">Cost Center Report </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink120" runat="server" NavigateUrl="~/">Receive & Payment</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink54" runat="server" NavigateUrl="~/">Bank Reconciliation</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink55" runat="server" NavigateUrl="~/">Approval Status </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink56" runat="server" NavigateUrl="~/">Receive Voucher </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink57" runat="server" NavigateUrl="~/">Payment Voucher </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink67" runat="server" NavigateUrl="~/">Journal Voucher </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink68" runat="server" NavigateUrl="~/">Contra Voucher </asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink69" runat="server" NavigateUrl="~/">Control Accounts</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink70" runat="server" NavigateUrl="~/">Account Ledgers</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink76" runat="server" NavigateUrl="~/">Dashboard A/c</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink77" runat="server" NavigateUrl="~/">Fixed Assets </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink79" runat="server" NavigateUrl="~/">Voucher Setup</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink80" runat="server" NavigateUrl="~/">Cost Category</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink81" runat="server" NavigateUrl="~/">Cost Center</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink78" runat="server" NavigateUrl="~/">Manage Budget A/c</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink82" runat="server" NavigateUrl="~/">Budget Variance</asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Procurement <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink83" runat="server" NavigateUrl="">List of Customers</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink84" runat="server" NavigateUrl="~/">Voucher Reports</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink85" runat="server" NavigateUrl="~/">Ledger Report</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink86" runat="server" NavigateUrl="~/">Accounts Payables</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink87" runat="server" NavigateUrl="~/">Purchase Register</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink88" runat="server" NavigateUrl="~/">Return Register</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink89" runat="server" NavigateUrl="~/">Component Price List</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink90" runat="server" NavigateUrl="~/">Purchase Analysis</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Analytics <b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink121" runat="server" NavigateUrl="">Tabulars </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink122" runat="server" NavigateUrl="~/">Graphical </asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink125" runat="server" NavigateUrl="~/">Purchase Requisition</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink126" runat="server" NavigateUrl="~/">Purchase Quotation</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink127" runat="server" NavigateUrl="~/">Purchase Instruction</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink128" runat="server" NavigateUrl="~/">Purchase Order</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink129" runat="server" NavigateUrl="~/">Purchase Receive</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink130" runat="server" NavigateUrl="~/">Material Receive</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink91" runat="server" NavigateUrl="~/">Purchase Invoice</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink92" runat="server" NavigateUrl="~/">Purchase Return</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink131" runat="server" NavigateUrl="~/">Vendor </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink132" runat="server" NavigateUrl="~/">Voucher Setup </asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Sales<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink140" runat="server" NavigateUrl="">List of Customers</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink141" runat="server" NavigateUrl="~/">Voucher Reports</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink142" runat="server" NavigateUrl="~/">Accounts Receivable</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink143" runat="server" NavigateUrl="~/">Sales Register</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink144" runat="server" NavigateUrl="~/">POS Register</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink133" runat="server" NavigateUrl="~/">Return Register</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink134" runat="server" NavigateUrl="~/">Price Report</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink135" runat="server" NavigateUrl="~/">Sales Analysis</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink136" runat="server" NavigateUrl="~/">Sales Commission</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Analytics <b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink123" runat="server" NavigateUrl="">Tabular</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink124" runat="server" NavigateUrl="~/">Graphical </asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink154" runat="server" NavigateUrl="~/">Sales Quotation</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink155" runat="server" NavigateUrl="~/">Sales Order</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink156" runat="server" NavigateUrl="~/">Sales Challan</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink157" runat="server" NavigateUrl="~/">Sales Invoice</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink158" runat="server" NavigateUrl="~/">Sales POS </asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink159" runat="server" NavigateUrl="~/">Sales Return </asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink160" runat="server" NavigateUrl="~/">Customer</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink161" runat="server" NavigateUrl="~/">Sales Force</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink162" runat="server" NavigateUrl="~/">Voucher Setup</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink163" runat="server" NavigateUrl="~/">Price Level</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink164" runat="server" NavigateUrl="~/">Incentive Plan</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink165" runat="server" NavigateUrl="~/">Price Catalogue</asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Doc Control<b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:HyperLink ID="HyperLink137" runat="server" NavigateUrl="~/">Search Documents</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink147" runat="server" NavigateUrl="~/">Folder Permission </asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink138" runat="server" NavigateUrl="~/">Add Folder</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink139" runat="server" NavigateUrl="~/">Document Explorer</asp:HyperLink></li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Provident Fund <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li class="deepdropdown1"><a href="">Report Builder<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink169" runat="server" NavigateUrl="">PF Status</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink170" runat="server" NavigateUrl="~/">PF Contribution Report</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Transaction<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink183" runat="server" NavigateUrl="~/">Search PF</asp:HyperLink></li>
                                        <li>
                                            <asp:HyperLink ID="HyperLink184" runat="server" NavigateUrl="~/">Full & Final Settlement</asp:HyperLink></li>
                                    </ul>
                                </li>
                                <li class="deepdropdown1"><a href="">Configuration<b class="caret"></b></a>
                                    <ul class="deepul1">
                                        <li>
                                            <asp:HyperLink ID="HyperLink189" runat="server" NavigateUrl="~/">Set PF Accounts</asp:HyperLink></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li class="dropdown"><a href="">Gratuity Fund <b class="caret"></b></a>
                            <ul class="dropdown-menu">
                                <li>
                                    <asp:HyperLink ID="HyperLink145" runat="server" NavigateUrl="~/">Report Builder</asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink146" runat="server" NavigateUrl="~/">Transaction </asp:HyperLink></li>
                                <li>
                                    <asp:HyperLink ID="HyperLink148" runat="server" NavigateUrl="~/">Configuration </asp:HyperLink></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Panel>
