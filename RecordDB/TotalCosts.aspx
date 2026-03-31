<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TotalCosts.aspx.cs" Inherits="RecordDB.TotalCosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="row mt-5 mb-2">
    <div class="col-xs-12 col-md-6 center-block">
        <h2 class="headerLabel">RecordDB Management System</h2>
          <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
          <h4 class="clockFace"><asp:TextBox ID="textClock" Width="120px" CssClass="no-border" ForeColor="#2780e3" Font="Bold" runat="server"></asp:TextBox></h4>
      
      <p> <span id="date"></span></p> 
        </div>
        </div>
    <div id="main" role="main" class="mainArea">
    <h4 class="headerLabel mt-3" align="center"><asp:Label ID="pageHeaderLabel" runat="server"></asp:Label></h4>
        <div class="table-responsive">
         <asp:GridView ID="totalsGridView" Width="25%" HorizontalAlign="Center" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="30"  DataSourceID="totalsDataSource" runat="server">
            <Columns>
               <asp:BoundField DataField="Name" HtmlEncode="False" HeaderStyle-CssClass="colour-header" HeaderText="Artist Name">
                   <HeaderStyle Width="50%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="TotalDiscs" HtmlEncode="False" HeaderStyle-CssClass="colour-header" HeaderText="Total Discs">
                   <HeaderStyle Width="25%"></HeaderStyle>
               </asp:BoundField>
               <asp:BoundField DataField="TotalCost" HtmlEncode="False" HeaderStyle-CssClass="colour-header" HeaderText="Total Cost" DataFormatString="{0:c}">
                   <HeaderStyle Width="25%"></HeaderStyle>
               </asp:BoundField>
            </Columns>             
         </asp:GridView>
    </div>
    <asp:Label ID="yearLabel" runat="server"></asp:Label><br/><br/>

        <asp:ObjectDataSource
            id="totalsDataSource"
            TypeName="RecordDAL.Repositories.TotalRepository"
            SelectMethod="GetTotalCosts"
            Runat="server">
        </asp:ObjectDataSource>        
    </div>    
    <div class="row">
        <footer>
            <hr />
          <p>Return to the <a href="/default">Main Menu</a></p>
        </footer>
    </div>                
    <script type="text/javascript">

          var yr = new Date();
          var year = yr.getFullYear();

          function ShowTime() {
              var dt = new Date();
              var hours = dt.getHours();

              var part = "am";
              if (hours > 12) {
                  hours -= 12;
                  part = "pm";
              }
              var newtime = +hours + ":" + dt.getMinutes() + part;
              if (dt.getMinutes() < 10) {
                  newtime = newtime.replace(":", ":0");
              }
              document.getElementById('<%= textClock.ClientID %>').value = newtime;
              window.setTimeout("ShowTime()", 100);
          }

          function runCode() {
              window.setTimeout("ShowTime()", 1000);
          }

          $('div.row').hide().fadeIn(1000);
          $('#<%=yearLabel.ClientID %>').html('&copy; Alan Robson ' + year);
          $('h2.headerLabel').css('text-align', 'center');
          $('h3.dateLabel').css('text-align', 'center');
          $('h4.clockFace').css('text-align', 'center');
          $('#<%=textClock.ClientID %>').css('text-align', 'center');

          runCode();
      </script>        
</asp:Content>
