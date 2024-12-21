using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Web
{
    public class Query
    {
        public static string usr { get; set; }
        public static string pass { get; set; }
        public static string mail { get; set; }

        public static string connAdress = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public static string command, commandMain, commandLinks;

        public static bool Login(string usr, string pass)
        {
            MySqlConnection conn = new MySqlConnection(connAdress);
            command = "SELECT * FROM Users WHERE Username=@user AND PasswordHash=@pass";
            MySqlCommand cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@user", usr);
            cmd.Parameters.AddWithValue("@pass", pass);
            conn.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read()) return true;
            else return false;
        }

        public static void Register(string usr, string mail, string pass)
        {
            MySqlConnection conn = new MySqlConnection(connAdress);
            conn.Open();
            command = "INSERT INTO Users (Username, PasswordHash, Email) VALUES (@user, @pass, @mail)";
            MySqlCommand cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@user", usr);
            cmd.Parameters.AddWithValue("@mail", mail);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.ExecuteNonQuery();
        }

        public static bool IsTaken(string usr)
        {
            MySqlConnection conn = new MySqlConnection(connAdress);
            command = "SELECT Username FROM Users WHERE Username=@user";
            MySqlCommand cmd = new MySqlCommand(command, conn);
            cmd.Parameters.AddWithValue("@user", usr);
            conn.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            if (dr.Read()) return true;
            else return false;
        }
    }
}