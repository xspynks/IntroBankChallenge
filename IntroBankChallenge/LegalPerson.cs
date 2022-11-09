namespace IntroBankChallenge;

public class LegalPerson : Client
{
    public LegalPerson(string code, string name) : base(code, name)
    {
        
    }

    public override decimal DiscountFee(decimal amount)
    {
        return amount - 2;
    }
    
}