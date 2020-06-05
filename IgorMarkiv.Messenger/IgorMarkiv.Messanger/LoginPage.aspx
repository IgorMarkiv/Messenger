<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginPage.aspx.cs" Inherits="IgorMarkiv.Messanger.LoginPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-12">
        <div id="loginFormHolder">
            <div id="usernameFormHolder" class="container-fluid">
                <asp:TextBox id="inputUsername" runat="server"></asp:TextBox>
            </div>
            <div id="passwordFormHolder" class="container-fluid">
                <asp:TextBox id="inputPassword" runat="server"></asp:TextBox>
            </div>
            <div id="SubmitButtonFormHolder" class="container-fluid">
                <asp:Button ID="SubmitButton" runat="server" Text="submit" OnClick="SubmitButton_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
