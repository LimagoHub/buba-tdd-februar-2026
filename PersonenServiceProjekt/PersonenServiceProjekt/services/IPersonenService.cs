using PersonenServiceProjekt.persistence;

namespace PersonenServiceProjekt.services;

public interface IPersonenService
{
    // Variante 1: Direktes Objekt
    void Speichern(Person? person);
}