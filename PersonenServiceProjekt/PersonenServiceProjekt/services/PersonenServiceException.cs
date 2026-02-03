namespace PersonenServiceProjekt.services;

public class PersonenServiceException : Exception
{
    public PersonenServiceException(string message) : base(message) { }
    public PersonenServiceException(string message, Exception inner) : base(message, inner) { }
}