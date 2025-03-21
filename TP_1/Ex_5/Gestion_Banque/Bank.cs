using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Ex_5.Gestion_Banque;

public class Bank
{
    private static Dictionary<string,BankAccount> accounts;
    private static readonly string? CurrentDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
    private static readonly string FilePath = Path.Combine(CurrentDirectory ?? string.Empty,"Gestion_Banque","accounts.json");
    public Bank()
    {
        accounts = LoadAccounts();
    }

    private static Dictionary<string,BankAccount> LoadAccounts()
    {
        if (!File.Exists(FilePath)) return new Dictionary<string, BankAccount>();
        var json = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<Dictionary<string,BankAccount>>(json) ?? new Dictionary<string, BankAccount>();
    }

    public static void SaveAccounts()
    {
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(accounts));
    }

    public void CreateAccount(string owner_name, double balance)
    {
        string account_number = new Random().Next(100000,999999).ToString();
        BankAccount account = new BankAccount(account_number, owner_name, balance);
        accounts.Add(account_number, account);
        SaveAccounts();
    }

    public BankAccount GetAccount(string account_number)
    {
        if (!accounts.ContainsKey(account_number))
        {
            Console.WriteLine($"Account {account_number} does not exist");
            return null;
        }
        return accounts[account_number];
    }

    public void ListAccounts()
    {
        Console.WriteLine("Listing accounts\n");
        foreach (var account in accounts)
        {
            Console.WriteLine(account.Value);
        }
    }

    public void DeleteAccount(string account_number)
    {
        if(!accounts.ContainsKey(account_number)) Console.WriteLine($"Account {account_number} does not exist");
        accounts.Remove(account_number);
        SaveAccounts();
    }
}