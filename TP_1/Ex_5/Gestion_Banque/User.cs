using Newtonsoft.Json;

namespace Ex_5.Gestion_Banque;

public class User
{
    public string Username;
    public string Password;
    
    private static readonly string? CurrentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
    private static readonly string FilePath = Path.Combine(CurrentDirectory ?? string.Empty,"Gestion_Banque","users.json");

    public static List<User> GetUsers()
    {
        Console.WriteLine(FilePath);
        if(!File.Exists(FilePath)) return new List<User>();
        string json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
    }
}