using System.Reflection;

namespace Ex_1.GestionAbsences;

public static class Utils
{
    public static Dictionary<string, object> ToDictionary(this object obj)
    {
        Dictionary<string, object?> dictionary = new Dictionary<string, object?>();
        foreach (PropertyInfo p in obj.GetType().GetProperties())
        {
            dictionary.Add(p.Name, p.GetValue(obj));
        }
        return dictionary;
    }
}