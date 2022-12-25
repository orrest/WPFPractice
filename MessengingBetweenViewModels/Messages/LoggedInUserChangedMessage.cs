// Create a message
using CommunityToolkit.Mvvm.Messaging.Messages;

public class LoggedInUserChangedMessage : ValueChangedMessage<string>
{
    public LoggedInUserChangedMessage(string user) : base(user)
    {
    }
}

