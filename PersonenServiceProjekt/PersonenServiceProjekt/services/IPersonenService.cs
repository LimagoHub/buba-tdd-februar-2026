using PersonenServiceProjekt.persistence;

namespace PersonenServiceProjekt.services;

public interface IPersonenService
{
    // Variante 1: Direktes Objekt
    void Speichern(Person? person);
    
    // Variante 2: Erzeugung aus Rohdaten
    void Speichern(string vorname, string nachname);
}