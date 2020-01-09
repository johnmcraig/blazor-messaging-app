using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class MessageData
    {
        private readonly ISqlDataAccess _db;

        public MessageData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<PostMessageModel>> GetMessages()
        {
            string sql = "select * from dbo.Message";

            return _db.LoadData<PostMessageModel, dynamic>(sql, new { });
        }

        public Task InsertMessage(PostMessageModel message)
        {
            string sql = @"insert into dbo.Message () values ();";

            return _db.SaveData(sql, message);
        }
    }
}
