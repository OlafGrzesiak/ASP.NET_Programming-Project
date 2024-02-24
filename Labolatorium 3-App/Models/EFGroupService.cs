using Data;
using Labolatorium_3_App.Models;
using System.Collections.Generic;
using System.Linq;

namespace Labolatorium_3_App.Services
{
    public class EFGroupService : IGroupService
    {
        private readonly AppDbContext _context;

        public EFGroupService(AppDbContext context)
        {
            _context = context;
        }

        public List<Group> GetAllLibraries()
        {
            return _context.Groups.Select(le => GroupMapper.FromEntity(le)).ToList();
        }

        public Group GetLibraryById(int id)
        {
            var groupEntity = _context.Groups.Find(id);
            return groupEntity != null ? GroupMapper.FromEntity(groupEntity) : null;
        }

        public void AddLibrary(Group group)
        {
            var groupEntity = GroupMapper.ToEntity(group);
            _context.Groups.Add(groupEntity);
            _context.SaveChanges();
        }

        public void UpdateLibrary(Group group)
        {
            var existingGroup = _context.Groups.Find(group.Id);
            if (existingGroup != null)
            {
                var groupEntity = GroupMapper.ToEntity(group);
                _context.Entry(existingGroup).CurrentValues.SetValues(groupEntity);
                _context.SaveChanges();
            }
        }

        public void DeleteLibrary(int id)
        {
            var group = _context.Groups.Find(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                _context.SaveChanges();
            }
        }
    }
}
