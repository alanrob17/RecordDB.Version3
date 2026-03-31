<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="RecordDB.Statistics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mt-5 mb-3">
        <div class="col-xs-12 col-md-6 center-block">
            <h2 class="headerLabel">RecordDB Management System</h2>
            <h3 class="dateLabel">
                <asp:Label ID="dateLabel" runat="server"></asp:Label></h3>
            <h4 class="clockFace">
                <asp:TextBox ID="textClock" Width="120px" CssClass="no-border" ForeColor="#2780e3" Font="Bold" runat="server"></asp:TextBox></h4>

            <p><span id="date"></span></p>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-12 col-md-4 center-block">

            <div class="table-responsive">
                <table class="table table-hover table-bordered colour-header">
                    <thead>
                        <tr>
                            <th class="colour-header">Statistics</th>
                            <th class="colour-header">Total</th>
                        </tr>
                    </thead>
                    <tr>
                        <td><strong>Number of Discs bought in 2022</strong></td>
                        <td>
                            <asp:Label runat="server" ID="disks2022Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on Discs in 2022</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cost2022Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average cost of a Disc in 2022</strong></td>
                        <td>
                            <asp:Label runat="server" ID="av2022Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Discs bought in 2021</strong></td>
                        <td>
                            <asp:Label runat="server" ID="disks2021Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on Discs in 2021</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cost2021Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average cost of a Disc in 2021</strong></td>
                        <td>
                            <asp:Label runat="server" ID="av2021Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Discs bought in 2020</strong></td>
                        <td>
                            <asp:Label runat="server" ID="disks2020Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on Discs in 2020</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cost2020Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average cost of a Disc in 2020</strong></td>
                        <td>
                            <asp:Label runat="server" ID="av2020Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Discs bought in 2019</strong></td>
                        <td>
                            <asp:Label runat="server" ID="disks2019Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on Discs in 2019</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cost2019Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average cost of a Disc in 2019</strong></td>
                        <td>
                            <asp:Label runat="server" ID="av2019Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Discs bought in 2018</strong></td>
                        <td>
                            <asp:Label runat="server" ID="disks2018Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on Discs in 2018</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cost2018Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average cost of a Disc in 2018</strong></td>
                        <td>
                            <asp:Label runat="server" ID="av2018Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Discs bought in 2017</strong></td>
                        <td>
                            <asp:Label runat="server" ID="disks2017Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on Discs in 2017</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cost2017Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average cost of a Disc in 2017</strong></td>
                        <td>
                            <asp:Label runat="server" ID="av2017Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Total Number of CD's</strong></td>
                        <td>
                            <asp:Label runat="server" ID="totalCDsLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Total Amount spent on CD's</strong></td>
                        <td>
                            <asp:Label runat="server" ID="cDCostLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Average spent on a CD</strong></td>
                        <td>
                            <asp:Label runat="server" ID="avCDCostLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Total Number of Records</strong></td>
                        <td>
                            <asp:Label runat="server" ID="totalRecordsLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Amount spent on Records</strong></td>
                        <td>
                            <asp:Label runat="server" ID="recordCostLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Total amount spent</strong></td>
                        <td>
                            <asp:Label runat="server" ID="totalCostLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Rock albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="rockDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Folk albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="folkDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Acoustic albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="acousticDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Jazz/Fusion albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="jazzDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Blues albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="bluesDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Country albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="countryDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Classical albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="classicalDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Soundtrack albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="soundtrackDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td><strong>Number of Indispensible albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="fourStarDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Slightly flawed albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="threeStarDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Average albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="twoStarDisksLabel"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>Number of Mediocre albums</strong></td>
                        <td>
                            <asp:Label runat="server" ID="oneStarDisksLabel"></asp:Label></td>
                    </tr>
                </table>
                <asp:Label ID="yearLabel" runat="server"></asp:Label><br />
                <br />
            </div>
        </div>
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
