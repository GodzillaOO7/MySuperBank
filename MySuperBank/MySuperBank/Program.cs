
namespace MySuperBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new Bankaccount("Spidy", 10000);
            Console.WriteLine($"Account Number {account.Number} created for {account.Owner} with balance of {account.Balance}");

            account.MakeWithdrawal(150, DateTime.Now, "Food");

            account.MakeWithdrawal(210, DateTime.Now, "free fire");

            Console.WriteLine(account.getAccountHistory());

        }
    }
}