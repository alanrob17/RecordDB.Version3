<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistList.aspx.cs" Inherits="RecordDB.ArtistList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
    <div class="col-xs-6 col-md-4 center-block">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3 class="headerLabel">Artist List</h3>
            </div>
        </div>
    </div>
    <div class="table-responsive">
        <asp:GridView ID="artistGridView" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" AllowPaging="True" PageSize="30"  DataSourceID="artistObjectDataSource" runat="server">
            <Columns>
                <asp:BoundField DataField="ArtistId" HtmlEncode="False" HeaderText="ArtistId">
                </asp:BoundField>
                <asp:BoundField DataField="FirstName" HeaderText="First Name">
                </asp:BoundField>
                <asp:BoundField DataField="LastName" HeaderText="Last Name">
                </asp:BoundField>
                <asp:BoundField DataField="Name" HtmlEncode="False" HeaderText="Artist">
                </asp:BoundField>
                <asp:BoundField DataField="Biography" HeaderText="Biography">
                    <HeaderStyle Width="70%"></HeaderStyle>
                </asp:BoundField>
            </Columns>             
        </asp:GridView>
    </div>
    </div>
    <asp:ObjectDataSource ID="artistObjectDataSource" TypeName="RecordDAL.Repositories.ArtistRepository" SelectMethod="GetArtists" runat="server"></asp:ObjectDataSource>   
    <div class="row">
        <footer>
            <hr />
            <p>Return to the <a href="/default">Main Menu</a></p>
        </footer>
    </div>        
</asp:Content>
