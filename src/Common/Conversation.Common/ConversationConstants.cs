using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversation.Common
{
    public class ConversationConstants
    {
        public const string RabbitMQHost = "localhost";
        public const string DefaultExchangeType = "direct";
        public const string UserExchangeName = "UserExchange";
        public const string UserEmailExchangedQueueName = "UserEmailExchangedQueue";



        public const string FavExchangeName = "FavExchangeName";
        public const string CreateEntryCommentFavQueueName = "CreateEntryCommentFavQueueName";
        public const string CreateEntryFavQueueName = "CreateEntryFavQueueName";

        public const string VoteExchangeName = "VoteExchangeName";
        public const string CreateEntryVoteQueueName = "CreateEntryVoteQueueName";
    }
}
