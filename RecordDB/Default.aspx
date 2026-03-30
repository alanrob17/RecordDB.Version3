<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RecordDB._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        th, td {
          Font-Size:small;
        }
    </style>
    <div class="row mt-5 mb-3">
        <div class="col-xs-10 col-md-6 mx-auto">
            <h2 class="headerLabel">RecordDB Management System</h2>
            <h3 class="dateLabel">
                <asp:Label ID="dateLabel" runat="server"></asp:Label></h3>
            <h4 class="clockFace">
                <asp:TextBox ID="textClock" Width="120px" CssClass="no-border" ForeColor="#2780e3" Font="Bold" runat="server"></asp:TextBox></h4>
            <p><span id="date"></span></p>
        </div>
    </div>
    <div class="row">
        <div class="col-xs-10 col-md-6 mx-auto">
            <div class="table-responsive">
                <table class="table table-hover table-bordered colour-header">
                    <thead>
                        <tr>
                            <th class="colour-header">Options</th>
                            <th class="colour-header">Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td><a href="GetArtist/cd">View&nbsp;All&nbsp;CD&nbsp;Titles</a></td>
                            <td>View a list of all CD Titles only. Organised by artist name and date recorded.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/all">View All Titles</a></td>
                            <td>View a list of all Titles (Record and CD). Organised by artist name and date recorded.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/records">View All Records</a></td>
                            <td>View a list of all Record Titles. Organised by artist name and date recorded.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/dvds">View All DVD's</a></td>
                            <td>View a list of all DVD Titles. Organised by date bought.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/blurays">View All Blurays</a></td>
                            <td>View a list of all Bluray Titles. Organised by date bought.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="RecordList">Record List</a></td>
                            <td>View a list of all Artists and Records.</td>
                        </tr>
                        <tr>
                            <td><a href="RecordReviews">Record Reviews</a></td>
                            <td>View a list of all record reviews.</td>
                        </tr>
                        <tr>
                            <td><a href="ArtistList">List All Artists</a></td>
                            <td>View a list of all Artists.</td>
                        </tr>
                        <tr>
                            <td><a href="Search">Search for an Artist</a></td>
                            <td>View a list of all of an Artists record titles.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href='GetArtist/2022'>View 2022 Titles</a></td>
                            <td>View all albums bought in 2022.</td>
                        </tr>
                        <tr>
                            <td><a href='GetArtist/2021'>View 2021 Titles</a></td>
                            <td>View all albums bought in 2021.</td>
                        </tr>
                        <tr>
                            <td><a href='GetArtist/2020'>View 2020 Titles</a></td>
                            <td>View all albums bought in 2020.</td>
                        </tr>
                        <tr>
                            <td><a href='GetArtist/2019'>View 2019 Titles</a></td>
                            <td>View all albums bought in 2019.</td>
                        </tr>
                        <tr>
                            <td><a href='GetArtist/2018'>View 2018 Titles</a>
                            </td>
                            <td>View all albums bought in 2018.</td>
                        </tr>
                        <tr>
                            <td><a href='GetArtist/2017'>View 2017 Titles</a></td>
                            <td>View all albums bought in 2017.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="Recorded">Year Recorded</a></td>
                            <td>View all albums recorded in a particular Year.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/1111">View Four Star</a></td>
                            <td>View all Albums with an indespensible rating.
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Rock">Rock</a></td>
                            <td>View all Rock albums.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Blues">Blues</a></td>
                            <td>View all Blues albums.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Jazz">Jazz</a></td>
                            <td>View all Jazz albums.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Classical">Classical</a></td>
                            <td>View all Classical albums.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Soundtrack">Soundtrack</a></td>
                            <td>View all Soundtrack albums.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Country">Country</a></td>
                            <td>View all Country albums.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Rockdesc">Rock by Date</a></td>
                            <td>View all Rock albums by date.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Bluesdesc">Blues by Date</a></td>
                            <td>View all Blues albums by date.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Jazzdesc">Jazz by Date</a>
                            </td>
                            <td>View all Jazz albums by date.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Classicaldesc">Classical by Date</a></td>
                            <td>View all Classical albums by date.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Soundtrackdesc">Soundtrack by Date</a></td>
                            <td>View all Soundtrack albums by date.</td>
                        </tr>
                        <tr>
                            <td><a href="GetArtist/Countrydesc">Country by Date</a></td>
                            <td>View all Country albums by date.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="AddArtist">Add New Artist</a></td>
                            <td>Add a new artist to the RecordDB.</td>
                        </tr>
                        <tr>
                            <td><a href="EditArtist">Edit Artist</a></td>
                            <td>Edit an artist in the RecordDB.</td>
                        </tr>
                        <tr>
                            <td><a href="DeleteArtist">Delete Artist</a></td>
                            <td>Delete an artist in the RecordDB.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="AddRecord">Add New Record</a></td>
                            <td>Add a new Record to the RecordDB.</td>
                        </tr>
                        <tr>
                            <td><a href="EditRecord">Edit Record</a></td>
                            <td>Edit a Record in the RecordDB.</td>
                        </tr>
                        <tr>
                            <td><a href="DeleteRecord">Delete Record</a></td>
                            <td>Delete an artist's Record.</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td><a href="TotalCosts">Artist Totals</a></td>
                            <td>Calculate total number of discs and costs for each artist.</td>
                        </tr>
                        <tr>
                            <td><a href="Statistics">Statistics</a></td>
                            <td>Calculate statistics for the RecordDB.</td>
                        </tr>
                    </tbody>
                </table>
                <h4 id="database">Connected to Linux container SQL Server database.</h4>
                <asp:Label ID="yearLabel" runat="server"></asp:Label><br />
                <br />
            </div>
        </div>
    </div>
<script type="text/javascript">
        var yr = new Date();
        var year = yr.getFullYear();

        function ShowTime() {
            var dt = new Date();
            var hours = dt.getHours();

            var part = "am";
            if (hours >= 12) {
                if (hours > 12) {
                    hours -= 12;
                }
                part = "pm";
            }

            // Adjust for midnight
            if (hours === 0) {
                hours = 12;
            }

            var newtime = +hours + ":" + dt.getMinutes() + part;
            if (dt.getMinutes() < 10) {
                newtime = newtime.replace(":", ":0");
            }
            document.getElementById('<%= textClock.ClientID %>').value = newtime;
            window.setTimeout(ShowTime, 100);
        }

        function runCode() {
            window.setTimeout(ShowTime, 1000);
        }

        $(document).ready(function () {
            $('div.row').hide().fadeIn(1000);
            $('#<%=yearLabel.ClientID %>').html('&copy; Alan Robson ' + year);
            $('h2.headerLabel').css('text-align', 'center');
            $('h3.dateLabel').css('text-align', 'center');
            $('h4.clockFace').css('text-align', 'center');
            $('#<%=textClock.ClientID %>').css('text-align', 'center');
            runCode();
        });
    </script>
</asp:Content>
