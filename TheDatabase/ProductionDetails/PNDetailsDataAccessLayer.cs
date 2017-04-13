using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace TheDatabase
{
    public class SQLUlaznaTabela
    {
        public string Vehicle { get; set; }
        public string VCC { get; set; }
        public string QuantM1 { get; set; }
        public string VehM1 { get; set; }
        public string JCI { get; set; }
        public string Description { get; set; }
    }

    public class PNDetailsDataAccessLayer
    {
        public PNDetailsDataAccessLayer()
        {

        }
        public static List<SQLUlaznaTabela> GetResult(string VehicleID)
        {
            List<SQLUlaznaTabela> ulaz = new List<SQLUlaznaTabela>();
            string SC = ConfigurationManager.ConnectionStrings["QuotationCalculationDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(SC))
            {
                SqlCommand cmd = new SqlCommand("Select VehicleName, VCC,QuantM1,VehM1,JCI,Description from ProdPerVehicleLastYear where Vehicle = @Vehicle", con);
                SqlParameter param = new SqlParameter("@Vehicle", VehicleID);
                cmd.Parameters.Add(param);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    SQLUlaznaTabela ulazniRed = new SQLUlaznaTabela();
                    ulazniRed.Vehicle = rdr["VehicleName"].ToString();
                    ulazniRed.VCC = rdr["VCC"].ToString();
                    ulazniRed.QuantM1 = rdr["QuantM1"].ToString();
                    ulazniRed.VehM1 = rdr["VehM1"].ToString();
                    ulazniRed.JCI = rdr["JCI"].ToString();
                    ulazniRed.Description = rdr["Description"].ToString();
                    ulaz.Add(ulazniRed);
                }

            }

            return ulaz;
        }
    }
}