using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace AcornHealth.Api {
    public class Database : IDisposable {
        public Database() {
            this._regex = new Regex("@\\w+\\b(?=(?:[^\"'\\\\]*(?:\\\\.|([\"'])(?:(?:(?!\\\\|\\1).)*\\\\.)*(?:(?!\\\\|\\1).)*\\1))*[^\"']*$)");

            var login = Environment.GetEnvironmentVariable("sql");
            this._connection = new MySqlConnection(login);
            this._connection.Open();
        }

        public MySqlDataReader ExecuteQuery(string query, params string[] data) {
            var command = new MySqlCommand(query, this._connection);

            var matches = this._regex.Matches(query);
            for (int i = 0; i < matches.Count; i++) {
                var match = matches[i].Value;
                command.Parameters.AddWithValue(match, data[i]);
            }

            command.Prepare();

            var reader = command.ExecuteReader();
            return reader;
        }

        public void Dispose() {
            this._connection.Close();
            this._connection.Dispose();
        }

        private Regex _regex;
        private MySqlConnection _connection;
    }
}