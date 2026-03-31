<%@ Page Title="" Language="C#" async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditArtist.aspx.cs" Inherits="RecordDB.EditArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="container mt-5 col-md-5">
    <h3 class="headerLabel mb-4">Update Artist</h3>
        <div class="row">
            <div class="mb-3">
              <label for="artistDropDownList" class="form-label"><strong>Select Artist:</strong></label>
                <asp:DropDownList ID="artistDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                  CssClass="form-control form-select rounded-3"
                  title="Select Artist"></asp:DropDownList>
            </div>
        </div>
        <asp:Panel ID="editPanel" runat="server">
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
                        <label for="nameTextBox" class="form-label"><strong>Name</strong></label>
                        <asp:TextBox ID="nameTextBox" runat="server"
                  CssClass="form-control rounded-3"
                  title="Name" placeholder="Name"></asp:TextBox>
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
            </asp:Panel>
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
</asp:Content>
