using Throw;

namespace WebProject.Domains;

public abstract class Enumeration : IComparable
{
    #region Properties
    public string Name { get; }

    public int Id { get; }
    #endregion

    #region Constructors
    protected Enumeration(int id, string name) => (Id, Name) = (id, name);
    #endregion

    #region Public
    public override string ToString() => Name;

    public static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T)
            .GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.DeclaredOnly)
            .Select(x => x.GetValue(null))
            .Cast<T>();

    public override bool Equals(object? obj)
    {
        obj.ThrowIfNull();

        if (obj is not Enumeration other) return false;

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(other.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() =>
        Id.GetHashCode();

    public static int AbsoluteDifference(Enumeration left, Enumeration right) =>
        Math.Abs(left.Id - right.Id);

    public static T FromValue<T>(int value) where T : Enumeration =>
        Parse<T, int>(value, "value", item => item.Id == value);

    public static T FromDisplayName<T>(string displayName) where T : Enumeration =>
        Parse<T, string>(displayName, "display name", item => item.Name == displayName);

    public static T Parse<T, TK>(TK value, string description, Func<T, bool> expression) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(expression);

        matchingItem.ThrowIfNull();

        return matchingItem;
    }

    public int CompareTo(object? obj)
    {
        obj.ThrowIfNull();

        return Id.CompareTo(((Enumeration)obj).Id);
    }
    #endregion
}
