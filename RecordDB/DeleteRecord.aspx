<%@ Page Title="" Language="C#" async="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DeleteRecord.aspx.cs" Inherits="RecordDB.DeleteRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="col-md-6 center-block">
<div class="container mt-5 col-md-5">
    <h3 class="headerLabel mb-4">Delete Record</h3>
        <div class="row">
            <div class="mb-3">
                <label for="artistDropDownList" class="form-label"><strong>Select Artist</strong></label>
                <asp:DropDownList ID="artistDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="artistDropDownList_SelectedIndexChanged"
                  CssClass="form-control form-select rounded-3"
                  title="Select Artist"></asp:DropDownList>
            </div>
            <asp:Panel ID="recordDropDownPanel" runat="server">
            <div class="mb-3">
                <label for="recordDropDownList" class="form-label"><strong>Select Record</strong></label>
                <asp:DropDownList ID="recordDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="recordDropDownList_SelectedIndexChanged"
                  CssClass="form-control form-select rounded-3"
                  title="Select record"></asp:DropDownList>
            </div>
            </asp:Panel>
        </div>
        <asp:Panel ID="tablePanel" runat="server">
        <div class="row">
            <div class="mb-3">
                <div>
                    <label for="nameTextBox" class="form-label"><strong>Title</strong></label>
                    <asp:Label ID="nameLabel" runat="server"
                        CssClass="form-control rounded-3"
                        title="Title">
                    </asp:Label>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- First Column -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="fieldDropDownList" class="form-label"><strong>Field</strong></label>
                    <asp:Label ID="fieldLabel" runat="server"				  
                        CssClass="form-control rounded-3"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="labelTextBox" class="form-label"><strong>Label</strong></label>
                    <asp:Label ID="recordLabel" runat="server" CssClass="form-control rounded-3" title="Label"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="ratingDropDownList" class="form-label"><strong>Rating</strong></label>
                    <asp:Label ID="ratingLabel" runat="server"				  
                        CssClass="form-control rounded-3"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="mediaDropDownList" class="form-label"><strong>Media</strong></label>
                    <asp:Label ID="mediaLabel" runat="server"				  
                        CssClass="form-control rounded-3"></asp:Label>
                </div>
            </div>
            <!-- Second Column -->
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="recordedTextBox" class="form-label"><strong>Recorded</strong></label>
                    <asp:Label ID="recordedLabel" runat="server"
                         CssClass="form-control rounded-3"
                         title="Recorded"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="pressingDropDownList" class="form-label"><strong>Pressing</strong></label>
                    <asp:Label ID="pressingLabel" runat="server"				  
                        CssClass="form-control rounded-3"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="discsDropDownList" class="form-label"><strong>Discs</strong></label>
                    <asp:Label ID="discsLabel" runat="server"				  
                        CssClass="form-control rounded-3"></asp:Label>
                </div>
                <div class="mb-3">
                    <label for="boughtTextBox" class="form-label"><strong>Bought</strong></label>
                    <asp:Label ID="boughtLabel" runat="server"
                         CssClass="form-control rounded-3"
                         title="Bought"></asp:Label>
                </div>
            </div>
            </div>
            <div class="row">
                <div class="mb-3">
                    <div>
                        <label for="costTextBox" class="form-label"><strong>Cost</strong></label>
                        <asp:Label ID="costLabel" runat="server"
                            CssClass="form-control rounded-3"
                            title="Cost"></asp:Label>
                    </div>
                </div>
                <div class="mb-3">
                    <div>
                        <label for="coverNameTextBox" class="form-label"><strong>Cover Name</strong></label>
                        <asp:Label ID="coverNameLabel" runat="server"
                            CssClass="form-control rounded-3"
                            title="Cover Name"></asp:Label>
                    </div>
                </div>
                <div class="mb-3">
                    <div>
                        <label for="reviewTextBox" class="form-label"><strong>Review</strong></label>
                        <asp:Label ID="reviewLabel" runat="server"
                            CssClass="form-control rounded-3"
                            title="Review"></asp:Label>
                    </div>
                </div>
                <div class="mb-3">
                <div id="messageAreaDiv"
                  runat="server"
                  visible="false">
                  <div class="well">
                    <asp:Label ID="messageLabel" runat="server"
                      CssClass="text-warning"
                      Text="ERROR:<br/>" />
                  </div>
                </div>
                </div>
            </div>    
        </asp:Panel>
        <asp:button id="deleteButton" runat="server" 
            CssClass="btn btn-danger rounded-3"
            Text="Delete Record"
            CommandName="Delete"
            OnClientClick="return confirm('This will permanently delete this Record Are you sure you want to do this?');"
            OnCommand="deleteButton_ItemDeleted"></asp:button>&nbsp;                    
        <asp:button id="returnButton" CssClass="btn btn-primary rounded-3" runat="server" Text="Home" OnClick="returnButton_Click"></asp:button>
</div>
</div>
  <div class="row">
      <footer>
          <hr />
        <p>Return to the <a href="/default">Main Menu</a></p>
      </footer>
  </div>    
</asp:Content>
