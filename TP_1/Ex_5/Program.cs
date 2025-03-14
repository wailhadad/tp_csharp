// See https://aka.ms/new-console-template for more information

using Ex_5.Gestion_Banque;

internal class Program
{
    // Voir "users.json" pour te connecter, NB: les comptes bancaires sont stockés permanently dans "accounts.json"
    static void Main(string[] args)
    {
        Bank bank = new Bank();
        List<User> users = User.GetUsers();
        
        Console.WriteLine("===== AUTHENTIFICATION =====");
        Console.Write("Entrez votre identifiant : \n");
        var username = Console.ReadLine();
        Console.Write("Entrez votre mot de passe : \n");
        var password = Console.ReadLine();
        
        var LoggedInUser = users.Find(u=> u.Username == username && u.Password == password);

        if (LoggedInUser == null)
        {
            Console.WriteLine("username or password is incorrect.");
            return;
        }
        Console.WriteLine($"\nBienvenue, {LoggedInUser.Username}\n");

        while (true)
        {
            Console.WriteLine("\n========================");
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("========================");
            Console.WriteLine("1 - Créer un compte bancaire");
            Console.WriteLine("2 - Effectuer une opération sur un compte");
            Console.WriteLine("3 - Afficher tous les comptes");
            Console.WriteLine("4 - Rechercher un compte");
            Console.WriteLine("5 - Supprimer un compte");
            Console.WriteLine("6 - Quitter");
            Console.Write("Choisissez une option : ");
            
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("\nEntrez le nom du propriétaire : ");
                    var owner = Console.ReadLine();
                    Console.Write("Entrez le solde initial : ");
                    if (double.TryParse(Console.ReadLine(), out var solde))
                    {
                        bank.CreateAccount(owner, solde);
                        Console.WriteLine("\nCompte bien créé : ");
                    }
                    else
                    {
                        Console.WriteLine("Erreur de creation\n");
                    }
                    break;
                case "2":
                        Console.Write("\nEntrez le numéro de compte : ");
                        BankAccount account = bank.GetAccount(Console.ReadLine() ?? string.Empty);
                        if (account == null) break;

                        Console.WriteLine("\n========================");
                        Console.WriteLine("SOUS-MENU DES OPÉRATIONS");
                        Console.WriteLine("========================");
                        Console.WriteLine("1 - Créditer un montant");
                        Console.WriteLine("2 - Débiter un montant");
                        Console.WriteLine("3 - Afficher l'historique des transactions");
                        Console.WriteLine("4 - Effectuer un transfert");
                        Console.WriteLine("5 - Retour au menu principal");
                        Console.Write("Choisissez une option : ");

                        string subChoice = Console.ReadLine();
                        switch (subChoice)
                        {
                            case "1":
                                Console.Write("Montant à créditer : ");
                                if (double.TryParse(Console.ReadLine(), out double creditAmount))
                                    account.Credit(creditAmount);
                                else Console.WriteLine("Montant invalide !");
                                break;
                            
                            case "2":
                                Console.Write("Montant à débiter : ");
                                if (double.TryParse(Console.ReadLine(), out double debitAmount))
                                    account.Debit(debitAmount);
                                else Console.WriteLine("Montant invalide !");
                                break;
                            
                            case "3":
                                account.PrintTransactionHistory();
                                break;
                            
                            case "4":
                                Console.Write("Numéro de compte destinataire : ");
                                BankAccount receiver = bank.GetAccount(Console.ReadLine() ?? string.Empty);
                                if (receiver == null) break;

                                Console.Write("Montant à transférer : ");
                                if (double.TryParse(Console.ReadLine(), out double transferAmount))
                                    account.Transfer(receiver, transferAmount);
                                else Console.WriteLine("Montant invalide !");
                                break;

                            case "5":
                                break;
                            
                            default:
                                Console.WriteLine("Choix invalide !");
                                break;
                        }
                        break;
                    
                    case "3":
                        bank.ListAccounts();
                        break;

                    case "4":
                        Console.Write("Entrez le numéro de compte : ");
                        BankAccount searchedAccount = bank.GetAccount(Console.ReadLine() ?? string.Empty);
                        if (searchedAccount != null)
                            Console.WriteLine(searchedAccount);
                        break;

                    case "5":
                        Console.Write("Entrez le numéro de compte à supprimer : ");
                        bank.DeleteAccount(Console.ReadLine() ?? string.Empty);
                        break;

                    case "6":
                        Console.WriteLine("Merci d'utiliser notre service bancaire !");
                        return;

                    default:
                        Console.WriteLine("Option invalide !");
                        break;
            }
        }
    }
}