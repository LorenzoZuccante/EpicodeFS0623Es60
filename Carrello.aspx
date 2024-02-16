<%@ Page Title="" Language="C#" MasterPageFile="~/PercorsoMaster/PaginaMaster.Master" AutoEventWireup="true" CodeBehind="Carrello.aspx.cs" Inherits="E_commerce.Carrello" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-custom {
            width: 90vw;
            min-height: 15vh;
            display: flex;
            align-items: center;
            margin-bottom: 1rem;
            flex-direction: row;
        }

        .img-container {
            flex-basis: 20%;
            height: 100%;
        }

        .img-container img {
            height: 100%;
            width: auto;
            object-fit: cover;
        }

        .card-body-custom {
            flex-grow: 1;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 0 1rem;
        }

        .details {
            display: flex;
            flex-direction: column;
            justify-content: center;
        }

        .btn-rimuovi, .btn-dettagli {
            white-space: nowrap;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <form runat="server">
        <asp:Repeater ID="repeaterCarrello" runat="server">
            <ItemTemplate>
                <div class="card card-custom">
                    <div class="img-container">
                        <img src='<%# Eval("ImgUrl") %>' alt="Prodotto" class="img-fluid" />
                    </div>
                    <div class="card-body-custom">
                        <div class="details">
                            <h5 class="card-title"><%# Eval("NomeProdotto") %></h5>
                            <p class="card-text">Prezzo: <%# String.Format("{0:C}", Eval("Prezzo")) %></p>
                        </div>
                        <div>
                        <asp:Button ID="btnRimuovi" runat="server" Text="Rimuovi" CommandArgument='<%# Eval("IdCarrello") %>' OnCommand="btnRimuovi_Command" CssClass="btn btn-danger btn-rimuovi" />
                        <asp:HyperLink ID="hlDettagli" runat="server" NavigateUrl='<%# "Dettagli.aspx?ProdottoId=" + Eval("Id") %>' CssClass="btn btn-primary" Text="Dettagli" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <h3>Totale: <asp:Label ID="lblTotale" runat="server"></asp:Label></h3>
        <asp:Button ID="btnSvuotaCarrello" runat="server" Text="Svuota il carrello" OnClick="btnSvuotaCarrello_Click" CssClass="btn btn-warning" />
        <asp:Label ID="lblCarrelloVuoto" runat="server" Visible="false"></asp:Label>
        </form>
    </div>
</asp:Content>
