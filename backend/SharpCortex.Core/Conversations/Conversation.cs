using SharpCortex.Core.Conversations;

namespace SharpCortex.Core.Conversations;

public class Conversation
{
    private readonly List<Message> _messages = new();

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public DateTime CreatedUtc { get; private set; }

    public IReadOnlyCollection<Message> Messages => _messages;

    private Conversation()
    {
        // EF Core
    }

    public Conversation(string title)
    {
        Id = Guid.NewGuid();
        CreatedUtc = DateTime.UtcNow;
        Rename(title);
    }

    public void Rename(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be empty.", nameof(title));

        Title = title;
    }

    public void AddMessage(Message message)
    {
        if (message is null)
            throw new ArgumentNullException(nameof(message));

        _messages.Add(message);
    }
}