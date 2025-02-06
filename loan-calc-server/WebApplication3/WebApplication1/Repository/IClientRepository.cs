using WebApplication1.models;

namespace WebApplication1.Repository
{
    public interface IClientRepository
    {
        Client GetClientById(int id);
    }
}
