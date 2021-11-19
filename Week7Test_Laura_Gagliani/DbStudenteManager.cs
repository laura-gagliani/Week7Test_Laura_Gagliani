using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7Test_Laura_Gagliani
{
    class DbStudenteManager
    {
        //stringhe corretta e sbagliata per il DB:
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Studente;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Stu///%/dente;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        internal static Studente GetByCode(int code)
        {
            SqlConnection connection = null;
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from Studente where Matricola=@code";
                    command.Parameters.AddWithValue("@code", code);

                    SqlDataReader reader = command.ExecuteReader();
                    Studente s = new Studente();

                    if (!reader.HasRows)
                    {
                        throw new StudentNotFoundException("Errore! Nessuno studente trovato");
                    }

                    while (reader.Read())
                    {
                        s.Nome = (string)reader["Nome"];
                        s.Cognome = (string)reader["Cognome"];
                        s.Matricola = (int)reader["Matricola"];
                    }

                    connection.Close();
                    return s;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Errore nella connessione!");
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("La matricola richiesta non è contenuta nel database");
                return null;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }




    }
}
