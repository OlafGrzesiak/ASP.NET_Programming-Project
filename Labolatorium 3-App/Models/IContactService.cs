using Data.Entities;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models;

public interface IContactService
{
    int Add(Contact book);
    void Delete(int id);
    void Update(Contact book);
    List<Contact> FindAll();
    Contact? FindById(int id);

    List<OrganizationEntity> FindAllOrganizations();
}