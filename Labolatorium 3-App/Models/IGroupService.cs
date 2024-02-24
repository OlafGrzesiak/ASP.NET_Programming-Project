using Labolatorium_3_App.Models;
using System.Collections.Generic;

namespace Labolatorium_3_App.Models
{
    public interface IGroupService
    {
        List<Group> GetAllLibraries();
        Group GetLibraryById(int id);
        void AddLibrary(Group library);
        void UpdateLibrary(Group library);
        void DeleteLibrary(int id);
    }
}
