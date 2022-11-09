namespace IntroBankChallenge;

public class PhysicalPerson : Client
{
    public PhysicalPerson(string code, string name) : base(code, name)
    {
    }
    
    public override decimal DiscountFee(decimal amount)
    {
        return amount - 1;
    }
}