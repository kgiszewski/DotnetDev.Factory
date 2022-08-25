namespace DotnetDev.Factory.Api.CreditCard;

public interface ICreditCardProvider
{
    void Charge(int amount);
    void Refund(int amount);
}

public class StripeProvider : ICreditCardProvider
{
    public void Charge(int amount)
    {
        
    }

    public void Refund(int amount)
    {
        
    }
}

public class CloverProvider : ICreditCardProvider
{
    public void Charge(int amount)
    {
        
    }

    public void Refund(int amount)
    {
        
    }
}

public interface ICreditCardFactory
{
    ICreditCardProvider GetProvider(int providerId);
}

public class CreditCardFactory : ICreditCardFactory
{
    private readonly Func<int, ICreditCardProvider> _func;

    public CreditCardFactory(Func<int, ICreditCardProvider> func)
    {
        _func = func;
    }
    
    public ICreditCardProvider GetProvider(int providerId)
    {
        return _func.Invoke(providerId);
    }
}