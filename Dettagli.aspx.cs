using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace E_commerce
{
    public partial class Dettagli : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CaricaDettagliProdotto();
            }
        }

        private void CaricaDettagliProdotto()
        {
            int prodottoId;
            if (int.TryParse(Request.QueryString["ProdottoId"], out prodottoId))
            {
                string connString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string query = "SELECT NomeProdotto, Marca, ImgUrl, Prezzo, DescrizioneProdotto FROM Prodotto WHERE Id = @ProdottoId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ProdottoId", prodottoId);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        imgProdotto.Src = reader["ImgUrl"].ToString();
                        lblNomeProdotto.InnerText = reader["NomeProdotto"].ToString();
                        lblMarca.InnerText = reader["Marca"].ToString();
                        lblPrezzo.InnerText = String.Format("{0:C}", reader["Prezzo"]);
                        lblDescrizione.InnerText = reader["DescrizioneProdotto"].ToString();
                    }
                }
            }
        }

        protected void btnAggiungiAlCarrello_Click(object sender, EventArgs e)
        {
            int prodottoId;
            if (int.TryParse(Request.QueryString["ProdottoId"], out prodottoId))
            {
                string connString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "INSERT INTO Carrello (IdProdotto) VALUES (@IdProdotto)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdProdotto", prodottoId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
