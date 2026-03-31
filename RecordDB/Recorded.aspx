<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recorded.aspx.cs" Inherits="RecordDB.Recorded" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .bgimage {
            background-image: url(images/pilatusb.jpg);
            background-size: 100%;
        }

        .bgimage-inside {
            padding-top: 37.36%; /* this is actually (426/1140)*100 */
        }
    </style>
  <div class="row">
    <div class="col-xs-10 col-md-6 center-block">
        <h2 class="headerLabel">RecordDB Management System</h2>
          <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
          <h4 class="clockFace"><asp:TextBox ID="textClock" Width="120px" CssClass="no-border" ForeColor="#2780e3" Font="Bold" runat="server"></asp:TextBox></h4>
      <br/>
      <p> <span id="date"></span></p> 
    </div>
  </div>
      <div class="row">
    <div class="col-xs-6 col-md-4 center-block">
      <div class="panel panel-primary">
        <div class="panel-heading">
          <h3 class="headerLabel">Albums Recorded by Year</h3>
        </div>
        <div class="panel-body">
          <div class="form-group">
            <label for="yearTextBox" class="mt-3 mb-2 fw-bold">Year</label>
            <div class="input-group">
              <asp:TextBox ID="yearTextBox" runat="server"
                TextMode="SingleLine"
                CssClass="form-control"
                autofocus="autofocus"
                placeholder="Year"
                title="Year"></asp:TextBox>
            </div>
          </div>
          <div class="row">
            <div class="col-xs-6">
              <div id="messageAreaDiv" 
                   runat="server" 
                   visible="false">
                <div class="well">
                  <asp:Label ID="messageLabel" runat="server"
                    CssClass="text-warning"
                    Text="Area to display messages." />
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="panel-footer clearfix">
          <asp:Button ID="submitButton" runat="server"
            Text="Submit"
            CssClass="btn btn-primary rounded-3 mt-2"
            title="Submit"
            OnClick="submitButton_Click" />
        </div>
      </div>
    </div>
  </div> 
 <div class="container">
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
          $('h2.headerLabel').css('text-align', 'center');
          $('h3.dateLabel').css('text-align', 'center');
          $('h4.clockFace').css('text-align', 'center');
          $('#<%=textClock.ClientID %>').css('text-align', 'center');
          runCode();
      </script>    
</asp:Content>

