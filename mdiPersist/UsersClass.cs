using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Code.Glb;

namespace Code
{
    public class UserTypes
    {
        public class CodeMsg
        {
            public int RetValue { get; set; }
            public int RowId { get; set; }
            public int ErrCode { get; set; }
            public string ErrMsg { get; set; }

            public CodeMsg()
            {
                RetValue = -99;
                RowId = -1;
                ErrCode = -99;
                ErrMsg = "Erro na execucao do comando";
            }
        }
    }

    class UserFunctions
    {
        public static ComboBox FillCmbYears(ComboBox cmb, int initialYear, int currentYear)
        {
            cmb.Items.Clear();
            for (int i = initialYear; i <= currentYear; i++)
            {
                cmb.Items.Add(i);
            }
            return cmb;
        }

        public static ComboBox FillCmbMonth(ComboBox cmb)
        {
            cmb.Items.Clear();
            cmb.ValueMember = "NumMes";
            cmb.DisplayMember = "NomeMes";

            for (byte i = 1; i <= 12; i++)
            {
                //Mes m = new Mes(i);
                //cmb.Items.Add(m);
            }
            return cmb;
        }
    }

    public static class Utils
    {
        public static void SendMsg(string msg)
        {
            MessageBox.Show(msg,
                "Setup",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        public static void GetFormPosition( Form F)
        {
            try
            {
                string w = U.CnnUserPass(CnnString);
                using (SqlConnection cn = new SqlConnection( w))
                {
                    using (SqlCommand cmd = new SqlCommand("spPersistValue_Get", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        for (int i = 1; i <= 4; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@userName", U.UserName);
                            cmd.Parameters.AddWithValue("@formName", F.Name);
                            cmd.Parameters.AddWithValue("@componentName", F.Name);

                            switch (i)
                            {
                                case 1:
                                    cmd.Parameters.AddWithValue("@propertyName", "Left");
                                    cmd.Parameters.AddWithValue("@savedValue",  F.Left);
                                    break;
                                case 2:
                                    cmd.Parameters.AddWithValue("@propertyName", "Top");
                                    cmd.Parameters.AddWithValue("@savedValue",  F.Top);
                                    break;
                                case 3:
                                    cmd.Parameters.AddWithValue("@propertyName", "Width");
                                    cmd.Parameters.AddWithValue("@savedValue",  F.Width);
                                    break;
                                case 4:
                                    cmd.Parameters.AddWithValue("@propertyName", "Height");
                                    cmd.Parameters.AddWithValue("@savedValue",  F.Height);
                                    break;
                                default:
                                    break;
                            }
                           
                            cn.Open();
                            var s = cmd.ExecuteScalar();
                            cn.Close();

                            if (s != null)
                            {
                                switch (i)
                                {
                                    case 1:
                                        F.Left = Convert.ToInt32(s);
                                        break;
                                    case 2:
                                        F.Top = Convert.ToInt32(s);
                                        break;
                                    case 3:
                                        F.Width = Convert.ToInt32(s);
                                        break;
                                    case 4:
                                        F.Height = Convert.ToInt32(s);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SendMsg("erro na conexao " + ex.Message);                
            }                
        }

        public static void SaveFormPosition( Form F)
        {
            if (F.WindowState == FormWindowState.Normal)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(U.CnnUserPass(CnnString)))
                    {
                        using (SqlCommand cmd = new SqlCommand("spPersistValue_Save", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            for (int i = 1; i <= 4; i++)
                            {
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@userName", U.UserName);
                                cmd.Parameters.AddWithValue("@formName", F.Name);
                                cmd.Parameters.AddWithValue("@componentName", F.Name);
                                switch (i)
                                {
                                    case 1:
                                        cmd.Parameters.AddWithValue("@propertyName", "Left");
                                        cmd.Parameters.AddWithValue("@savedValue",  F.Left );
                                        break;
                                    case 2:
                                        cmd.Parameters.AddWithValue("@propertyName", "Top");
                                        cmd.Parameters.AddWithValue("@savedValue",  F.Top);
                                        break;
                                    case 3:
                                        cmd.Parameters.AddWithValue("@propertyName", "Width");
                                        cmd.Parameters.AddWithValue("@savedValue",  F.Width);
                                        break;
                                    case 4:
                                        cmd.Parameters.AddWithValue("@propertyName", "Height");
                                        cmd.Parameters.AddWithValue("@savedValue",  F.Height);
                                        break;
                                }

                                cn.Open();
                                int retVal = cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    SendMsg("erro na conexao " + ex.Message);
                }
            }
        }

        public static void SaveControlValue(string UserName, Form F, Control C, string P)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(U.CnnUserPass(CnnString)))
                {
                    using (SqlCommand cmd = new SqlCommand("spPersistValue_Save", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@userName",      UserName);
                        cmd.Parameters.AddWithValue("@formName",      F.Name );
                        cmd.Parameters.AddWithValue("@componentName", C.Name );
                        cmd.Parameters.AddWithValue("@propertyName",  P      );    
                        cmd.Parameters.AddWithValue("@savedValue", 
                            C.GetType().GetProperty(P).GetValue(C, null).ToString());

                        cn.Open();
                        int retVal = cmd.ExecuteNonQuery();                    
                    }
                }
            }
            catch (Exception ex)
            {
                SendMsg("erro na conexao " + ex.Message);
            }
        }

        public static void GetControlValue(string UserName, Form F, Control C, string P)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(U.CnnUserPass(CnnString)))
                {
                    using (SqlCommand cmd = new SqlCommand("spPersistValue_Get", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@userName",      UserName );
                        cmd.Parameters.AddWithValue("@formName",      F.Name );
                        cmd.Parameters.AddWithValue("@componentName", C.Name );
                        cmd.Parameters.AddWithValue("@propertyName",  P );
                        cmd.Parameters.AddWithValue("@savedValue", "P");
                        cn.Open();
                        var s = cmd.ExecuteScalar();
                        cn.Close();

                        if ( s != null)
                        {
                            C.GetType().GetProperty( P).SetValue(C, s);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SendMsg("erro na conexao " + ex.Message);
            }
        }

        public static void SaveDefaultValue(string fName, string cName, string dValue)
        {
            SqlConnection cn = new SqlConnection(Glb.CnnString);
            SqlCommand cmd = new SqlCommand("SaveDefaultValue", cn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@formName", fName);
            cmd.Parameters.AddWithValue("@componentName", cName);
            cmd.Parameters.AddWithValue("@savedValue", dValue);

            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static void GetDefaultValue(Form f, Control c)
        {
            SqlConnection cn = new SqlConnection(Glb.CnnString);
            SqlCommand cmd = new SqlCommand("Select savedValue from SavedValues" +
                                            " where formName = @fName and componentName = @cName", cn)
            {
                CommandType = System.Data.CommandType.Text
            };
            cmd.Parameters.AddWithValue("@fName", f.Name);
            cmd.Parameters.AddWithValue("@cName", c.Name);
            //  Get default value
            cn.Open();
            var s = cmd.ExecuteScalar();
            cn.Close();
            //  Move value to corresponding control property
            if (s != null)
            {
                switch (c.GetType().Name)
                {
                    case "TextBox":
                        c.Text = s.ToString(); break;
                    case "NumericUpDown":
                        ((NumericUpDown)c).Text = s.ToString(); break;
                    case "PictureBox":
                        ((PictureBox)c).BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(s)); break;
                    case "DateTimePicker":
                        ((DateTimePicker)c).Value = Convert.ToDateTime(s.ToString()); break;
                    default:
                        break;
                }
            }
        }
    }
}
