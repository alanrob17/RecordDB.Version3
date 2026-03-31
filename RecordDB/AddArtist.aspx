<%@ Page Title="Add New Artist" Language="C#" async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddArtist.aspx.cs" Inherits="RecordDB.AddArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<%--      <div class="row">
    <div class="col-xs-12 col-md-6 center-block">
        <h2 class="headerLabel">RecordDB Management System</h2>
          <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
          <h4 class="clockFace"><asp:TextBox ID="textClock" Width="120px" CssClass="no-border" ForeColor="#2780e3" Font="Bold" runat="server"></asp:TextBox></h4></h4>
      <br/>
      <p> <span id="date"></span></p> 
    </div>
  </div>--%>
<div class="col-md-6 center-block">
<div class="container mt-5 col-md-5">
    <h3 class="headerLabel mb-4">Add Artist</h3>
        <div class="row">
            <!-- First Column -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="firstNameTextBox" class="form-label"><strong>First name</strong></label>
                    <asp:TextBox ID="firstNameTextBox" runat="server" CssClass="form-control rounded-3" title="First Name" placeholder="First name" autofocus="autofocus"></asp:TextBox>
                </div>
            </div>
            <!-- Second Column -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="lastNameTextBox" class="form-label"><strong>Last name</strong></label>
                    <asp:TextBox ID="lastNameTextBox" runat="server" CssClass="form-control rounded-3" title="Last Name" placeholder="Last name"></asp:TextBox>
                </div>
            </div>
            </div>
            <div class="row">
                <div class="mb-3">
                    <div>
                        <label for="biographyTextBox" class="form-label"><strong>Biography</strong></label>
                        <asp:TextBox ID="biographyTextBox" runat="server" TextMode="MultiLine" CssClass="form-control rounded-3" Height="260px" title="Biography" placeholder="Biography"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div id="divMessageArea" runat="server" visible="false">
                    <div class="well p-4 mt-2 mb-1">
                        <asp:Label ID="messageLabel" runat="server" CssClass="text-warning" Text="ERROR:<br/>" />
                    </div>
                </div>
            </div>

               <asp:button id="submitButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Save" OnClick="submitButton_Click"></asp:button>&nbsp;                    
               <asp:button id="returnButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>
        <div class="row">
            <div class="center-block">
                <asp:Label ID="yearLabel" runat="server"></asp:Label><br/><br/>
            </div>
        </div>
        <div class="row">
            <footer>
                <hr />
                <p>Return to the <a href="/default">Main Menu</a></p>
            </footer>
        </div>    
</div>
</div>
    <script type="text/javascript">

<%--          var yr = new Date();
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
--%>
      </script>        
</asp:Content>
