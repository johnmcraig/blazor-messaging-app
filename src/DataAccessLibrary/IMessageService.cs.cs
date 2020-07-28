using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IMessageService
    {
        Task<IList<PostMessageModel>> ReadAll();
        Task<PostMessageModel> ReadSingle(int id);
        Task<int> Create(PostMessageModel messageModel);
        Task<int> Update(PostMessageModel messageModel);
        Task<int> Delete(int id);
    }
}
