<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FandomWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <img id="MainContent_ingBrandItem" style="height:300px;" />
    </div>

    <div class="row">
        <div class="col-md-4">
             <h2 ID="txtProductName1" runat="server">product name</h2>
            <a ID="Productlink1" href="" runat="server">
            <asp:Image ID="Image1" runat="server" />
            </a>
            <p ID="txtProductDesription1" runat="server"> product desription</p>
           
        </div>
        <div class="col-md-4">
             <h2 ID="txtProductName2" runat="server">product name</h2>
            <a ID="productlink2" href ="" runat="server">
            <asp:Image ID="Image2" runat="server" />
            </a>
            <p ID="txtProductDesription2" runat="server"> product desription</p>
        </div>
        
        <div class="col-md-4">
           
             <h2 ID="txtProductName3" runat="server" >product name</h2>
            <a id="productlink3" href="" runat="server">
            <asp:Image ID="Image3" runat="server" />
            </a>
            <p ID="txtProductDesription3" runat="server"> product desription</p>
        </div>
    </div>

</asp:Content>
