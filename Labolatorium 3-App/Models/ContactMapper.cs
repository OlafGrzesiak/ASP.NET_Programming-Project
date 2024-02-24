using Data.Entities;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(Contact model)
    {
        return new ContactEntity()
        {
            Created = model.Created,
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
            Phone = model.Phone,
            Birth = model.Birth,
            Priority = (int)model.Priority,
            OrganizationId = (int)model.OrganizationId,

        };
    }

    public static Contact FromEntity(ContactEntity entity)
    {
        return new Contact()
        {
            Created = entity.Created,
            Id = entity.Id,
            Name = entity.Name,
            Email = entity.Email,
            Phone = entity.Phone,
            Birth = entity.Birth,
            Priority = (Priority)entity.Priority,
            OrganizationId = entity.OrganizationId,
        };
    }
}