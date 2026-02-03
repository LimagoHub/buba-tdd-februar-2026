using PersonenServiceProjekt.persistence;

namespace PersonenServiceProjekt.services
{
    public interface IBlacklistService
    {
        /// <summary>
        /// Prüft, ob eine Person auf der Verbotsliste steht.
        /// </summary>
        bool IsBlacklisted(Person possibleBlacklistedPerson);
    }
}