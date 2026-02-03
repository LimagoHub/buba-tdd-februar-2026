namespace PersonenServiceProjekt.persistence;

public record Person(string Vorname = "John", string Nachname = "Doe")
{
    public string? Id { get; set; }

    
}