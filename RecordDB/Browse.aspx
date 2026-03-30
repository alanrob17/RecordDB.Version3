<%@ Page Title="Browse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="RecordDB.Browse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <div class="col-xs-10 center-block">
        <h3 class="headerLabel"><asp:Label ID="pageHeaderLabel" runat="server"></asp:Label></h3>  
        <div class="table-responsive">
         <asp:GridView ID="recordGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="30"  DataSourceID="recordDataSource" runat="server">
            <Columns>
               <asp:BoundField DataField="artistName" HtmlEncode="False" HeaderText="Artist">
                   <HeaderStyle Width="20%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="name" HtmlEncode="False" HeaderText="Title">
                   <HeaderStyle Width="30%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="field" HeaderText="Field">
                   <HeaderStyle Width="10%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="recorded" HeaderText="Recorded">
                   <HeaderStyle Width="5%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="rating" HeaderText="Rating">
                   <HeaderStyle Width="5%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="bought" HeaderText="Bought" DataFormatString="{0:d}">
                   <HeaderStyle Width="10%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="pressing" HeaderText="Pressing">
                   <HeaderStyle Width="5%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="discs" HeaderText="Discs">
                   <HeaderStyle Width="5%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="media" HeaderText="Media">
                   <HeaderStyle Width="10%"></HeaderStyle>
               </asp:BoundField>
            </Columns>             
         </asp:GridView>
    </div>
    <asp:Label ID="discsLabel" runat="server"></asp:Label>
        </div>
            </div>
  <div class="row">
      <footer>
          <hr />
        <p>Return to the <a href="/default">Main Menu</a></p>
      </footer>
  </div>                
       <asp:ObjectDataSource
            id="recordDataSource"
            TypeName="RecordDAL.Repositories.RecordRepository"
            SelectMethod="Select"
            Runat="server">
                <SelectParameters>                                            
                     <asp:RouteParameter Name="show" RouteKey="show" Type="string" />
                </SelectParameters>
        </asp:ObjectDataSource>
        <script type="text/javascript">
            function runCode() {
                window.setTimeout("ShowTime()", 1000);
            }
    
            $(document).ready(function () {
                $("#<%=recordGridView.ClientID%> tr").filter(":odd").css("background-color", "#F0FAFF");
    
                var total = 0;
    
                $("#<%=recordGridView.ClientID%> tr:has(td)").each(function () {
                    var cell = $(this).find("td:eq(7)");
    
                    if (!isNaN(parseInt(cell.html()))) {
                        total += parseInt(cell.html());
                    }
                });
    
                $('h3.headerLabel').css('text-align', 'center');
                $('#<%=discsLabel.ClientID%>').append(total + ' discs');
                // alert('The total of number of records is ' + total);
            });
    </script>
</asp:Content>
