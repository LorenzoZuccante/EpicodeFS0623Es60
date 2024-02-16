<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/PercorsoMaster/PaginaMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="E_commerce.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>I Prodotti che Vendiamo</h2>
    <div class="container mt-3">
        <div class="row">
            <asp:Repeater ID="repeaterProdotti" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card h-100" style="width: 18rem;">
                            <img src='<%# Eval("ImgUrl") %>' class="card-img-top" alt="Immagine Prodotto">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("NomeProdotto") %></h5>
                                <p class="card-text">Prezzo: <%# String.Format("{0:C}", Eval("Prezzo")) %></p>
                                <a href="Dettagli.aspx?ProdottoId=<%# Eval("Id") %>" class="btn btn-primary">Dettagli</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
