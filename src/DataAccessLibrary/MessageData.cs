using Dapper;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class MessageData : IMessageService
    {
        private readonly ISqlDataAccess _db;
        private readonly IConfiguration _config;
        private readonly string defaultConn = "DefaultConnection";

        public MessageData(ISqlDataAccess db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<IList<PostMessageModel>> ReadAll()
        {
            string sql = "SELECT Id, PostedBy, PostedOn, Message FROM Messages";

            using var connection = new SqlConnection(_config.GetConnectionString(defaultConn));

            connection.Open();

            var result = await connection.QueryAsync(sql);

            return (IList<PostMessageModel>)result;
        }

        public async Task<PostMessageModel> ReadSingle(int id)
        {
            var sql = "SELECT * FROM Messages WHERE Id = @Id;";

            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(defaultConn));
            connection.Open();

            var result = await connection.QueryAsync(sql, new { Id = id });

            return (PostMessageModel)result;
        }

        public async Task<int> Create(PostMessageModel messageModel)
        {
            messageModel.PostedOn = DateTime.UtcNow;

            string sql = @"INSERT INTO Messages (PostedBy, PostedOn, Message) VALUES (@PostedBy, @PostedOn, @Message);";

            using var connection = new SqlConnection(_config.GetConnectionString(defaultConn));

            connection.Open();

            var rows = await connection.ExecuteAsync(sql, messageModel);

            return rows;
        }

        public async Task<int> Update(PostMessageModel messageModel)
        {
            string sql = "select * from dbo.Message";

            using var connection = new SqlConnection(_config.GetConnectionString(defaultConn));

            connection.Open();

            var rows = await connection.ExecuteAsync(sql, messageModel);

            return rows;
        }

        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Messages WHERE @Id = Id;";

            using var connection = new SqlConnection(_config.GetConnectionString(defaultConn));

            connection.Open();

            var rows = await connection.ExecuteAsync(sql, new { Id = id });

            return rows;
        }

    }
}
