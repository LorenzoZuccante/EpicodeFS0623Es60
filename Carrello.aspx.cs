using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace E_commerce
{
    public partial class Carrello : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CaricaCarrello();
            }
        }

        private void CaricaCarrello()
        {
            string connString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            List<dynamic> prodotti = new List<dynamic>();
            decimal totale = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = @"
                SELECT c.Id AS IdCarrello, p.Id, p.NomeProdotto, p.ImgUrl, p.Prezzo
                FROM Carrello c
                JOIN Prodotto p ON c.IdProdotto = p.Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            prodotti.Add(new
                            {
                                IdCarrello = reader["IdCarrello"],
                                NomeProdotto = reader["NomeProdotto"].ToString(),
                                Id = reader["id"].ToString(),
                                ImgUrl = reader["ImgUrl"].ToString(),
                                Prezzo = Convert.ToDecimal(reader["Prezzo"])
                            });
                            totale += Convert.ToDecimal(reader["Prezzo"]);
                        }
                    }
                }
            }

            
            

            repeaterCarrello.DataSource = prodotti;
            repeaterCarrello.DataBind();

            lblTotale.Text = $" {totale:C}";
        }

        protected void btnRimuovi_Command(object sender, CommandEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM Carrello WHERE Id = @IdCarrello";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdCarrello", Convert.ToInt32(e.CommandArgument));
                    cmd.ExecuteNonQuery();
                }
            }

            CaricaCarrello();
        }

        protected void btnSvuotaCarrello_Click(object sender, EventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "DELETE FROM Carrello";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            CaricaCarrello();
        }
    }
}
