namespace SchweinDemoProjekt.tiere;

public class Schwein
{
    
    private string _name;
    public string Name
    {
        get { return _name;}
        set
        {
            if (value == "Elsa") throw new ArgumentException("Elsa ist nicht erlaubt!");
            _name = value;
        }
    }

    public int Gewicht{get; private set;}
    
    public Schwein(string name = "Nobody")
    {
        Name = name;
        Gewicht = 10;
    }

    public void Fuettern()
    {
        Gewicht++;
    }

    // _________________ generatetd _____________________________
    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, {nameof(Gewicht)}: {Gewicht}";
    }

    private sealed class NameGewichtEqualityComparer : IEqualityComparer<Schwein>
    {
        public bool Equals(Schwein? x, Schwein? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null) return false;
            if (y is null) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && x.Gewicht == y.Gewicht;
        }

        public int GetHashCode(Schwein obj)
        {
            return HashCode.Combine(obj.Name, obj.Gewicht);
        }
    }

    public static IEqualityComparer<Schwein> NameGewichtComparer { get; } = new NameGewichtEqualityComparer();
}