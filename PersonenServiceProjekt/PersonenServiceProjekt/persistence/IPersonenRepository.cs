namespace PersonenServiceProjekt.persistence;

public interface IPersonenRepository
{
    void SaveOrUpdate(Person person);
    Person? FindById(string id);
    IEnumerable<Person> FindAll();
    bool DeleteById(string id);
}