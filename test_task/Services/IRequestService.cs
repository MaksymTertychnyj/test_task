using System.Threading.Tasks;
using test_task.Data.Entities;

namespace test_task.Services
{
    public interface IRequestService
    {
        Task<string> AddNewIncident(RequestParameter parameters);

        Task<Incident> CreateIncident(string incidentDescription);

        Task<string> CreateAccount(RequestParameter parameters);

        Task<string> CreateContact(Contact contact);
    }
}
