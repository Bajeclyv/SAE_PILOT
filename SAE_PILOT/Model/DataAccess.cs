

using System.Collections.Generic;
using System.Data;
using System.Windows;
using Microsoft.Extensions.Logging;
using Npgsql;


namespace TD3_BindingBDPension.Model
{

    public  class DataAccess
    {
        private static readonly DataAccess instance = new DataAccess();
        private readonly string connectionString = "Host=srv-peda-new;Port=5433;Username=poupeaub;Password=62TVka;Database=poupeaub_sae201;Options='-c search_path=poupeaub'";
        //private readonly string connectionString = "Host=srv-peda.iut-acy.local;Port=5433;Username=poupeaub;Password=62TVka;Database=poupeaub_sae201;Options='-c search_path=poupeaub'";
        //private readonly string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=1201;Database=dupuyy_pilot;Options='-c search_path=public'";

        private NpgsqlConnection connection;

        public static DataAccess Instance
        {
            get
            {
                return instance;
            }
        }

        //  Constructeur privé pour empêcher l'instanciation multiple
        private DataAccess()
        {
            
            try
            {
                connection = new NpgsqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Problème de connexion GetConnection \n" + connectionString);
                throw;
            }
        }


        // pour récupérer la connexion (et l'ouvrir si nécessaire)
        public NpgsqlConnection GetConnection()
        {
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    LogError.Log(ex, "Problème de connexion GetConnection \n" + connectionString);
                    throw;                
                }
            }

        
            return connection;
        }

        //  pour requêtes SELECT et retourne un DataTable ( table de données en mémoire)
        public DataTable ExecuteSelect(NpgsqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            try
            {
                cmd.Connection = GetConnection();
                using (var adapter = new NpgsqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (Exception ex)
            {
                LogError.Log(ex, "Erreur SQL");
                throw;
            }
            return dataTable;
        }

        //   pour requêtes INSERT et renvoie l'ID généré

        public int ExecuteInsert(NpgsqlCommand cmd)
        {
            int nb = 0;
            try
            {
                cmd.Connection = GetConnection();
                nb = (int)cmd.ExecuteScalar();

            }
            catch (Exception ex) { 
                LogError.Log(ex, "Problème avec une requête INSERT : " + cmd.CommandText);
                throw; }
            return nb;
        }




        //  pour requêtes UPDATE, DELETE
        public int ExecuteSet(NpgsqlCommand cmd)
        {
            int nb = 0;
            try
            {
                cmd.Connection = GetConnection();
                nb = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                LogError.Log(ex, "Problème avec une requête SET : " + cmd.CommandText);
                throw;
            }
            return nb;

        }

        // pour requêtes avec une seule valeur retour  (ex : COUNT, SUM) 
        public object ExecuteSelectUneValeur(NpgsqlCommand cmd)
        {
            object res = null;
            try
            {
                cmd.Connection = GetConnection();
                res = cmd.ExecuteScalar();
            }
            catch (Exception ex) {
                LogError.Log(ex, "Problème avec une requete SELECT " + cmd.CommandText);
                throw;
            }
            return res;

        }

        //  Fermer la connexion 
        public void CloseConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}



