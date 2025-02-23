namespace Ex_5.Gestion_Banque;

public class BankAccount
{
    public string AccountNumber;
    public string OwnerName;
    public double Balance;
    public List<string> TransactionHistory;

    public BankAccount(string accountNumber, string ownerName, double balance)
    {
        AccountNumber = accountNumber;
        OwnerName = ownerName;
        Balance = balance;
        TransactionHistory = new List<string>
        {
            $"{DateTime.Now} : Account \"{accountNumber}\" has been created with balance : {balance} $"
        };
    }

    public void Credit(double amount)
    {
        if (amount < 0) Console.WriteLine("Account balance cannot be negative");
        Balance += amount;
        TransactionHistory.Add($"{DateTime.Now} : {amount} is credited, new Account balance is : {Balance} ");
        Bank.SaveAccounts();
    }

    public bool Debit(double amount)
    {
        if (amount < 0 || amount > Balance)
        {
            Console.WriteLine("Account balance cannot be negative");
            return false;
        }
        Balance -= amount;
        TransactionHistory.Add($"{DateTime.Now} : {amount} is debited, new Account amount is : {Balance}");
        Bank.SaveAccounts();
        return true;
    }

    public void Transfer(BankAccount recipient,double amount)
    {
        if (!Debit(amount)) return;
        recipient.Credit(amount);
        TransactionHistory.Add($"{DateTime.Now} : {amount} is transfered to from the account No : \"{AccountNumber}\" " +
                               $"to the account No : \"{recipient.AccountNumber}\"");
        Bank.SaveAccounts();
    }

    public void PrintTransactionHistory()
    {
        Console.WriteLine($"Transaction history for the account No: {AccountNumber} and Owner Name: {OwnerName}\n");
        foreach (var transaction in TransactionHistory)
        {
            Console.WriteLine(transaction+"\n");
        }
    }

    public override string ToString()
    {
        return $"Account Number: {AccountNumber}, Owner Name: {OwnerName}, Balance: {Balance}\n";
    }
}