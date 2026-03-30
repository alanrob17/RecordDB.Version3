<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordList.aspx.cs" Inherits="RecordDB.RecordList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-center">
        <div class="col-10 col-md-8 col-lg-6 mt-5 text-center">
            <h2 class="headerLabel">RecordDB Management System</h2>
            <h3 class="dateLabel"><asp:label ID="dateLabel" runat="server"></asp:label></h3>
            <h4 class="clockFace"><asp:TextBox ID="textClock" Width="120px" CssClass="no-border" ForeColor="#2780e3" Font="Bold" runat="server"></asp:TextBox></h4>
            <br/>
            <p> <span id="date"></span></p> 
        </div>
    </div>
    <div class="row justify-content-center">
        <div class="col-sm-2"></div>
        <div class="col-10 col-md-8 col-lg-6">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="headerLabel">Record List</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Literal ID="recordLiteral" runat="server"></asp:Literal>            
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <div id="divMessageArea" 
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
            <asp:Label ID="yearLabel" runat="server"></asp:Label><br/><br/>
        </div>
    </div>  
    <div class="row justify-content-center">
        <div class="col-10 col-md-8 col-lg-6 text-center">
            <footer>
                <hr />
                <p>Return to the <a href="/default">Main Menu</a></p>
            </footer>
        </div>
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
