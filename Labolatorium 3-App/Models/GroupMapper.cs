using Labolatorium_3_App.Models;
using Data.Entities;

namespace Labolatorium_3_App.Models
{
    public static class GroupMapper
    {
        public static GroupEntity ToEntity(Group model)
        {
            return new GroupEntity
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                // Dodaj mapowanie dla innych właściwości
            };
        }

        public static Group FromEntity(GroupEntity entity)
        {
            return new Group
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                // Dodaj mapowanie dla innych właściwości
            };
        }
    }
}
