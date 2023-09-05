using chatterBox.DTO;
using chatterBox.EntityFrameworkCore;
using chatterBox.Messages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace chatterBox.Message
{
    //CrudAppService<MessageInfo, MessageDto, Guid, PagedAndSortedResultRequestDto>
    [Authorize]
    public class MessageAppService : ApplicationService
    {
        //private readonly IRepository<MessageInfo, Guid> _repository; IRepository<MessageInfo, Guid> repository: base(repository)
        private readonly ICurrentUser _currentUser;
        private readonly chatterBoxDbContext _dbContext;

        public MessageAppService(ICurrentUser currentUser, chatterBoxDbContext dbContext)
        {
            //_repository = repository;
            _currentUser = currentUser;
            _dbContext = dbContext;
        }
        public Guid GetCurrentUser()
        {
            var CurrentUser = _currentUser.GetId();
            return CurrentUser;
        }

        public async Task<MessageInfo> send(CreateMessageDto msg)
        {
            var CurrentUser = _currentUser.GetId();
            var message = new MessageInfo
            {
                Id = GuidGenerator.Create(),
                SenderId = (CurrentUser),
                ReceiverId = msg.ReceiverId,
                MsgBody = msg.MsgBody,
                TimeStamp = DateTime.Now

            };
            var result = await _dbContext.messageInfo.AddAsync(message);
            _dbContext.SaveChanges();
            //ObjectMapper.Map(MessageInfo, message);
            //var result= await _repository.InsertAsync(message);
            if (result != null)
            {
                return message;
            }
            else
            {
                return null;
            }

        }
        public async Task<List<MessageInfo>> GetMessagesAsync(Guid receiverId, DateTime? before, int count = 20, string sort = "asc")
        {
            var currentUserId = _currentUser.GetId();
            var result = await _dbContext.messageInfo.Where(u => (u.ReceiverId == receiverId && u.SenderId == currentUserId)
                || (u.SenderId == receiverId && u.ReceiverId == currentUserId) && (before == null || u.TimeStamp < before))
                .OrderBy(m => m.TimeStamp).ToListAsync();
            if (sort.ToLower() == "desc") result.Reverse();
            if (before != null) result = await _dbContext.messageInfo.Where(m => m.TimeStamp < before).ToListAsync();
            if (result.Count > count) result = result.TakeLast(count).ToList();

            return result;
        }
        public async Task<MessageInfo> Update(Guid id, updateDto Msg)
        {
            var currentUserId = _currentUser.GetId();
            var userMessage = await _dbContext.messageInfo.FirstOrDefaultAsync(u => u.Id == id);
            if (currentUserId != userMessage.SenderId) return null;
            userMessage.MsgBody = Msg.content;
            await _dbContext.SaveChangesAsync();
            return userMessage;
        }

        public async Task<bool> Delete(Guid id)
        {
            var currentUserId = _currentUser.GetId();
            var Message = await _dbContext.messageInfo.Where(a => a.Id == id).FirstOrDefaultAsync();
            if(currentUserId!=Message.SenderId) return false;
            if (Message != null)
            {
                _dbContext.messageInfo.Remove(Message);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<MessageInfo>> GetSearch(string query)
        {
            var currentUserId = _currentUser.GetId();
            var normalizedQuery = query.ToLower();
            var SearchedMessages = await _dbContext.messageInfo.Where(m => (m.SenderId == currentUserId || m.ReceiverId == currentUserId) && m.MsgBody
            .ToLower().Contains(normalizedQuery)).ToListAsync();
            return SearchedMessages;
        }
        
    }
}
