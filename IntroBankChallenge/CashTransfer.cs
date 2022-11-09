namespace IntroBankChallenge;

public class CashTransfer
{
    public List<CashTransfer> Transfer { get; set; }
    public string Type { get; set; }
    public decimal Amount { get; set; }
    
    public CashTransfer(string type, decimal amount)
    {
        Type = type;
        Amount = amount;
    }
}
    