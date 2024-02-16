<%@ Page Title="" Language="C#" MasterPageFile="~/PercorsoMaster/PaginaMaster.Master" AutoEventWireup="true" CodeBehind="Dettagli.aspx.cs" Inherits="E_commerce.Dettagli" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <div class="row">
            <div class="col-md-6">
                <img id="imgProdotto" runat="server" class="img-fluid" alt="Immagine Prodotto" />
            </div>
            <div class="col-md-6">
                <h2 id="lblNomeProdotto" runat="server"></h2>
                <p><strong>Marca:</strong> <span id="lblMarca" runat="server"></span></p>
                <p><strong>Prezzo:</strong> <span id="lblPrezzo" runat="server"></span></p>
                <p><strong>Descrizione:</strong> <span id="lblDescrizione" runat="server"></span></p>
                <form runat="server">
                <asp:Button ID="btnAggiungiAlCarrello" runat="server" Text="Aggiungi al carrello" OnClick="btnAggiungiAlCarrello_Click" CssClass="btn btn-primary" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
