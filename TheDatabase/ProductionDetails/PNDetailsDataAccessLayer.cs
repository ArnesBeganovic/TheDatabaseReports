using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
namespace TheDatabase
{
    public class SQLUlaznaTabela
    {
        /*
         * Necessary columns
         */
        public string Vehicle { get; set; }
        public string Plant { get; set; }
        public string VCC { get; set; }
        public string Description { get; set; }
        public string ADNT { get; set; }

        public string QuantM1 { get; set; }
        public string QuantM2 { get; set; }
        public string QuantM3 { get; set; }
        public string QuantM4 { get; set; }
        public string QuantM5 { get; set; }
        public string QuantM6 { get; set; }

        public string VehM1 { get; set; }
        public string VehM2 { get; set; }
        public string VehM3 { get; set; }
        public string VehM4 { get; set; }
        public string VehM5 { get; set; }
        public string VehM6 { get; set; }
        
        
    }

    public class PNDetailsDataAccessLayer
    {
        public PNDetailsDataAccessLayer()
        {

        }
        public static List<SQLUlaznaTabela> GetResult(string VehicleID,string sqlKomanda,int colsSend)
        {
            /*
             * Retreive data from database 
             */

            List<SQLUlaznaTabela> ulaz = new List<SQLUlaznaTabela>();
            string SC = ConfigurationManager.ConnectionStrings["QuotationCalculationDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(SC))
            {
                SqlCommand cmd = new SqlCommand(sqlKomanda, con);
                SqlParameter param = new SqlParameter("@Vehicle", VehicleID);
                cmd.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SQLUlaznaTabela ulazniRed = new SQLUlaznaTabela();
                    ulazniRed.Vehicle = rdr["VehicleName"].ToString();
                    ulazniRed.VCC = rdr["VCC"].ToString();
                    ulazniRed.ADNT = rdr["JCI"].ToString();
                    ulazniRed.Description = rdr["Description"].ToString();

                    if (colsSend >= 1)
                    {
                        ulazniRed.QuantM1 = rdr["QuantM1"].ToString();
                        ulazniRed.VehM1 = rdr["VehM1"].ToString();
                    }

                    if (colsSend >= 2)
                    {
                        ulazniRed.QuantM2 = rdr["QuantM2"].ToString();
                        ulazniRed.VehM2 = rdr["VehM2"].ToString();
                    }

                    if (colsSend >= 3)
                    {
                        ulazniRed.QuantM3 = rdr["QuantM3"].ToString();
                        ulazniRed.VehM3 = rdr["VehM3"].ToString();
                    }

                    if (colsSend >= 4)
                    {
                        ulazniRed.QuantM4 = rdr["QuantM4"].ToString();
                        ulazniRed.VehM4 = rdr["VehM4"].ToString();
                    }

                    if (colsSend >= 5)
                    {
                        ulazniRed.QuantM5 = rdr["QuantM5"].ToString();
                        ulazniRed.VehM5 = rdr["VehM5"].ToString();
                    }

                    if (colsSend >= 6)
                    {
                        ulazniRed.QuantM6 = rdr["QuantM6"].ToString();
                        ulazniRed.VehM6 = rdr["VehM6"].ToString();
                    }

                    ulaz.Add(ulazniRed);
                }

            }

            return ulaz;
        }

        
    }
}