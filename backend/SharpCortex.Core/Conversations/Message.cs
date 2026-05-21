namespace SharpCortex.Core.Conversations;

public class Message
{
    public Guid Id { get; private set; }

    public Guid ConversationId { get; private set; }

    public MessageRole Role { get; private set; }

    public string Content { get; private set; } = string.Empty;

    public DateTime CreatedUtc { get; private set; }

    private Message()
    {
        // EF Core
    }

    public Message(Guid conversationId, MessageRole role, string content)
    {
        Id = Guid.NewGuid();
        ConversationId = conversationId;
        Role = role;
        Content = content ?? throw new ArgumentNullException(nameof(content));
        CreatedUtc = DateTime.UtcNow;
    }
}