using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms1
{
    class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=root;database=paksoleg");
        //Подключение к базе данных
        public void OpenConnection()
            //открываем соединение с базой данных
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseConnection()
            //Закрываем соединение с базой данных
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Close();
        }

        public MySqlConnection GetConnection()
            //Возвращает соединение , говорит, с какой базой будем работать
        {
            return connection;
        }
    }
}
