using System.Net.Sockets;

namespace IntroBankChallenge;

public class Client
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public decimal Balance { get; private set; }
    public List<CashTransfer> CashTransfers { get; set; }

    public Client()
    {
        CashTransfers = new List<CashTransfer>();
    }
    
    public Client(string code, string name) : this()
    {
        Name = name;
        Code = code;
    }

    public void MakeWithdraw(decimal amount)
    {
        if (Balance > amount)
        {
            decimal amountWithTax = DiscountFee(amount);
            Balance = Balance - amount;
            AddCashTransfer("WITHDRAW", amountWithTax);
            Console.WriteLine($"Withdraw made successfully! Balance: {Balance}");
        }
        else
            Console.WriteLine("Insufficient funds");
    }

    public void MakeDeposit(decimal amount)
    {
        if (amount >= 10)
        {
            decimal amountWithTax = DiscountFee(amount);
            Balance += amountWithTax;
            AddCashTransfer("DEPOSIT", amountWithTax);
            Console.WriteLine($"Deposit made successfully! Balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Amount must be equal or higher than U$ 10.00");
        }
    }

    public void AddCashTransfer(string type, decimal amount)
    {
        CashTransfers.Add(new CashTransfer(type, DiscountFee(amount)));
        
    }
    
    public virtual decimal DiscountFee(decimal amount)
    {
        return amount;
    }
}

