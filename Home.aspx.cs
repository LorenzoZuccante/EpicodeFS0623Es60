using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace E_commerce
{
    public partial class Home : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CaricaProdotti();
            }
        }

        private void CaricaProdotti()
        {
            List<Prodotto> listaProdotti = new List<Prodotto>();
            string connString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "SELECT Id, NomeProdotto, ImgUrl, Prezzo FROM Prodotto";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Prodotto prodotto = new Prodotto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NomeProdotto = reader["NomeProdotto"].ToString(),
                            ImgUrl = reader["ImgUrl"].ToString(),
                            Prezzo = Convert.ToDecimal(reader["Prezzo"])
                        };
                        listaProdotti.Add(prodotto);
                    }
                }
            }

            repeaterProdotti.DataSource = listaProdotti;
            repeaterProdotti.DataBind();
        }
        public class Prodotto
        {
            public int Id { get; set; }
            public string NomeProdotto { get; set; }
            public string ImgUrl { get; set; }
            public decimal Prezzo { get; set; }
        }


    }
}
