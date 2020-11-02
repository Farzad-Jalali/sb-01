using sb.ConsoleApp1.Domain;

namespace sb.ConsoleApp1.Services
{
    public interface IEngineQuoteService
    {
        Quote[] GetQuotes(CustomerRequestType req, InsurerConfigurationType config);

    }
}