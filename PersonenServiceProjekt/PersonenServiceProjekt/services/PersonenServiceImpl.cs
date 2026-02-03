using PersonenServiceProjekt.persistence;

namespace PersonenServiceProjekt.services;

public class PersonenServiceImpl: IPersonenService
{
    private readonly IPersonenRepository _personenRepository;
    private readonly IBlacklistService _blacklistService;

    public PersonenServiceImpl(IPersonenRepository personenRepository, IBlacklistService blacklistService)
    {
        _personenRepository = personenRepository;
        _blacklistService = blacklistService;
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
        try
        {
            SpeichernImpl(person);
        } 
        catch (PersonenServiceException) { throw; }
        catch (Exception ex)
        {
            throw new PersonenServiceException("Ein Fehler ist aufgetreten!", ex);
        }

       
        
    }

    private void SpeichernImpl(Person? person)
    {
        CheckPerson(person);
        _personenRepository.SaveOrUpdate(person);
    }

    private void CheckPerson(Person? person)
    {
        ValidatePerson(person);
        BusinessCheck(person);
    }

    private void BusinessCheck(Person? person)
    {
        if (_blacklistService.IsBlacklisted(person))
            throw new PersonenServiceException("Unerwuenschte Person");
    }

    private static void ValidatePerson(Person? person)
    {
        if (person == null)
            throw new PersonenServiceException("Person darf nicht null sein!");
        if (person.Vorname == null || person.Vorname.Length < 2)
            throw new PersonenServiceException("Vorname zu kurz!");
        if (person.Nachname == null || person.Nachname.Length < 2)
            throw new PersonenServiceException("Nachname zu kurz!");
    }

    public void Speichern(string vorname, string nachname)
    {
        Person person = new Person(vorname, nachname);
        person.Id = Guid.NewGuid().ToString();
        Speichern(person);
    }
}