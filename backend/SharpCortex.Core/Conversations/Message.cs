namespace SharpCortex.Core.Conversations
{
    public class Message
    {
        public int Id { get; set; }

        public int ConversationId { get; set; }

        public MessageRole Role { get; set; }
        
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedUtc { get; set; }
    }
}
