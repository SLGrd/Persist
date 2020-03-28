using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Code
{
    public static class Glb
    {
        //  Variaveis recebidas pelo .Ini file               
        public static string Server;
        public static string DbPath;
        public static string CnnString = "Data Source=Cinza;Initial Catalog=Horizon;Integrated Security=True;";

        //  Logged user
        public static Users U = new Users();
    }

    public class Users
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public Users()
        {
            UserName = "";
            Password = "";
        }

        public Users(String User, String Pass)
        {
            UserName = User;
            Password = Pass;
        }

        public string CnnUserPass(string CString)
        {
            return CString + "UID = " + UserName + ";pwd = " + Password + ";";
        }

        public bool UserValidation()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection( CnnUserPass(Glb.CnnString)))
                {
                    cnn.Open();
                    cnn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na validacao do Usuario : " + ex.Message);
            }
            return false;
        }
    }
}