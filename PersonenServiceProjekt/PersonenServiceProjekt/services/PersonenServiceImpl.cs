using PersonenServiceProjekt.persistence;

namespace PersonenServiceProjekt.services;

public class PersonenServiceImpl: IPersonenService
{
    private readonly IPersonenRepository _personenRepository;

    public PersonenServiceImpl(IPersonenRepository personenRepository)
    {
        _personenRepository = personenRepository;
    }


    /*
     * 1.) Parameter null -> PSE (nicht ArgumentNullException!!!)
     * 2.) Vorname null -> PSE
     * 3.) Vorname < 2 -> PSE
     * 4.) Nachname null -> PSE
     * 5.) Nachname < 2 -> PSE
     * 6.) Vorname Attila -> PSE
     * 7.) Any Exception -> PSE
     * HappyPath -> person an repo uebergeben
     */
    public void Speichern(Person? person)
    {
        if(person == null)
             throw new PersonenServiceException("Person darf nicht null sein!");
        throw new PersonenServiceException("Vorname zu kurz!");
    }
}