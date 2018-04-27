using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace PlanerAkademia
{
    public static class DataBase
    {

        #region PrivateMembers

        /// <summary>
        /// Gets the user id when logged in
        /// </summary>
        public static int UserID { get; set; }

        /// <summary>
        /// Gets all the Ids of events of this user
        /// </summary>
        public static List<int> EventID { get; set; }

        /// <summary>
        /// MySqlConnection variable
        /// </summary>
        private static MySqlConnection connection;

        /// <summary>
        /// String with informations needed to connect
        /// </summary>
        private static string connect = "Server=188.40.51.83; Port=3306; Database=snooking_AkademiaPlaner; Uid=snooking_Planer; password=LoveYouTomeczek;";

        #endregion

        #region PublicFunctions

        public static bool LogIn(string login, string password)
        {
            try
            {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ID, Login, Password FROM Users WHERE `Login` = '" +
                    login + "' AND `Password` = '" + password + "'";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                        UserID = (int)reader["ID"];
                    return true;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("To też nie dziala chuju.");
                return false;
            }
        }

        public static bool Register(string login, string password)
        {
            try
            {
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ID, Login, Password FROM Users WHERE `Login` = '" +
                    login + "'";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) return false;

                command.CommandText = "INSERT INTO `Users` (`ID`, `Login`, `Password`) VALUES " +
                "(NULL, '" + login + "', '" + password + "')";
                reader.Close();
                reader = command.ExecuteReader();
                while (reader.Read())
                    UserID = (int)reader["ID"];
                return true;
            }
            catch
            {
                Console.WriteLine("Nie dziala chuju.");
                return false;
            }
        }

        public static void AddEvent(Event eventt)
        {
            try
            {
                int EventId = 0;
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO `Events` (`ID`, `Name`, `DateAndTime`, `Description`) VALUES " +
                "(NULL, '" + eventt.Name + "', '" + eventt.InsertedDateTime + "', '" + eventt.Description + "')";
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                command.CommandText = "SELECT ID FROM `Events` WHERE Name = " + '"' + eventt.Name + '"' + 
                    " AND Description = " + '"' + eventt.Description + '"' + " AND DateAndTime = " + '"' + eventt.InsertedDateTime + '"';
                Console.WriteLine(command.CommandText);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EventId = (int)reader["ID"];
                }
                reader.Close();
                command.CommandText = "INSERT INTO `Connections`(`IDUser`, `IDEvent`) VALUES (" + UserID + "," + EventId + ")";
                reader = command.ExecuteReader();
            }
            catch
            {
                Console.WriteLine("This shit doesn't work either.");
            }
        }

        public static void ConnectEvents()
        {
            connection = new MySqlConnection(connect);
            MySqlCommand command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT IDEvent FROM `Connections` WHERE IDUser = " + UserID.ToString();
            MySqlDataReader reader = command.ExecuteReader();
            EventID = new List<int>();
            while (reader.Read())
            {
                int number;
                number = (int)reader["IDEvent"];
                EventID.Add(number);
            }
        }

        public static List<Event> ShowEvents()
        {
            try
            {
                List<Event> events = new List<Event>();
                connection = new MySqlConnection(connect);
                MySqlCommand command = connection.CreateCommand();
                connection.Open();
                ConnectEvents();
                for (int i = 0; i < EventID.Count; i++)
                {
                    int number = EventID[i];
                    command.CommandText = "SELECT * FROM `Events` WHERE ID = " + number;
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Event eve = new Event();
                        eve.Name = (string)reader["Name"];
                        int col = reader.GetOrdinal("DateAndTime");
                        var info = reader.GetMySqlDateTime(col);
                        eve.InsertedDateTime = info.ToString();
                        eve.InsertedDateTimeToVariables();
                        eve.Description = (string)reader["Description"];
                        events.Add(eve);
                    }
                    reader.Close();
                }
                return events;
            }
            catch
            {
                Console.WriteLine("Cannot show your fucking Events");
                return null;
            }
        }

        #endregion
    }
}