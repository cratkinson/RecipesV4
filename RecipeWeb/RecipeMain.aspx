<%@ Page Title="My Recipes" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="RecipeMain.aspx.vb" Inherits="RecipeWeb.RecipeMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:DropDownList ID="listRecipes" runat="server"></asp:DropDownList>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
