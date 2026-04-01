<%@ Page Title="" Language="C#" Async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteArtist.aspx.cs" Inherits="RecordDB.DeleteArtist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6 center-block">
        <div class="container mt-5 col-md-5">
            <h3 class="headerLabel mb-4">Delete Artist</h3>
            <div class="row">
                <div class="mb-3">
                    <label for="artistDropDownList" class="form-label"><strong>Select Artist:</strong></label>
                    <asp:DropDownList ID="artistDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                        CssClass="form-control form-select rounded-3"
                        title="Select Artist">
                    </asp:DropDownList>
                </div>
            </div>
            <asp:Panel ID="editPanel" runat="server">
                <div class="row">
                    <!-- First Column -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="firstNameTextBox" class="form-label"><strong>First name</strong></label>
                            <asp:Label ID="firstNameLabel" runat="server"
                                CssClass="form-control rounded-3"
                                title="First Name"></asp:Label>
                        </div>
                    </div>
                    <!-- Second Column -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="lastNameTextBox" class="form-label"><strong>Last name</strong></label>
                            <asp:Label ID="lastNameLabel" runat="server"
                                CssClass="form-control rounded-3"
                                title="Last Name"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="mb-3">
                        <div>
                            <label for="nameTextBox" class="form-label"><strong>Full name</strong></label>
                            <asp:Label ID="nameLabel" runat="server"
                                CssClass="form-control rounded-3"
                                title="Full Name"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="mb-3">
                        <div>
                            <label for="biographyTextBox" class="form-label"><strong>Biography</strong></label>
                            <asp:Label ID="biographyLabel" runat="server"
                                TextMode="MultiLine"
                                CssClass="form-control rounded-3"
                                Height="360px"
                                title="Biography"></asp:Label>
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

                <asp:Button ID="deleteButton" CssClass="btn btn-danger rounded-3" runat="server" Text="Delete"
                    CommandName="Delete"
                    OnClientClick="return confirm('This will permanently delete this Artist and all their records. Are you sure you want to do this?');"
                    OnCommand="deleteButton_ItemDeleted"></asp:Button>&nbsp;                    
            <asp:Button ID="returnButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Home" OnClick="returnButton_Click"></asp:Button>
            </asp:Panel>
            <div class="row">
                <div class="center-block">
                    <asp:Label ID="yearLabel" runat="server"></asp:Label><br />
                    <br />
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

</asp:Content>
