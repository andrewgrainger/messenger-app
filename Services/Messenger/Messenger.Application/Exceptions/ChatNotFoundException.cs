namespace Messenger.Application.Exceptions;

public class ChatNotFoundException(string name, Object key) : ApplicationException($"Chat {name} - {key} not found.")
{
}
