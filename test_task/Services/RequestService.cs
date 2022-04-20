using System;
using System.Linq;
using System.Threading.Tasks;
using test_task.Data.Entities;
using test_task.Repository;

namespace test_task.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<Incident> _incidentRepository;

        public RequestService(
            IRepository<Account> accountRepository,
            IRepository<Contact> contactRepository,
            IRepository<Incident> incidentRepository
            )
        {
            _accountRepository = accountRepository;
            _contactRepository = contactRepository;
            _incidentRepository = incidentRepository;
        }

        public async Task<string> AddNewIncident(RequestParameter parameters)
        {
            var curentAccount =  _accountRepository.GetByKeyAsync(parameters.accountName).Result;

            if (curentAccount == null)
            {
                return string.Empty;
            }

            var curentContact = _contactRepository.GetByKeyAsync(parameters.contactEmail).Result;

            if (curentContact != null)
            {
                curentContact.FirstName = parameters.contactFirstName;
                curentContact.LastName = parameters.contactLastName;
                
                if (curentContact.AccountName == null)
                {
                    curentContact.Account = curentAccount;
                }

                await _contactRepository.UpdateAsync(curentContact);
                await _contactRepository.SaveChangesAsync();

                return "it was updated contact";
            }
            else
            {
                var newContact = new Contact()
                {
                    Email = parameters.contactEmail,
                    FirstName = parameters.contactFirstName,
                    LastName = parameters.contactLastName,
                    Account = curentAccount,
                };

                await _contactRepository.AddAsync(newContact);
                await _contactRepository.SaveChangesAsync();

                curentAccount.Incident = await CreateIncident(parameters.incidentDescription);
                await _accountRepository.UpdateAsync(curentAccount);
                await _accountRepository.SaveChangesAsync();

                return "it was created new contact with new incident";
            }
        }

        public async Task<Incident> CreateIncident(string incidentDescription)
        {
            var newIncident = new Incident() { Name = Guid.NewGuid().ToString(), Description = incidentDescription};
            await _incidentRepository.AddAsync(newIncident);
            await _incidentRepository.SaveChangesAsync();

            return newIncident;
        }

        public async Task<string> CreateAccount(RequestParameter parameters)
        {
            var curentAccount = _accountRepository.GetByKeyAsync(parameters.accountName).Result;

            if (curentAccount == null)
            {
                var curentContact = _contactRepository.GetByKeyAsync(parameters.contactEmail).Result;

                if (curentContact == null)
                {
                    return "account cannot be created without contact";
                }
                
                var incident = await CreateIncident(parameters.incidentDescription);
                curentAccount = new Account() { Name = parameters.accountName, Incident = incident };

                await _accountRepository.AddAsync(curentAccount);
                await _accountRepository.SaveChangesAsync();

                curentContact.Account = curentAccount;
                await _contactRepository.UpdateAsync(curentContact);
                await _contactRepository.SaveChangesAsync();

                return "it was created new account";
            }

            return "such an account already exists";
        }

        public async Task<string> CreateContact(Contact contact)
        {
            var curentContact = _contactRepository.GetByKeyAsync(contact.Email).Result;

            if (curentContact == null)
            {
                await _contactRepository.AddAsync(contact);
                await _contactRepository.SaveChangesAsync();

                return "it was created new contact";
            }

            return "such an contact already exists";
        }
    }
}