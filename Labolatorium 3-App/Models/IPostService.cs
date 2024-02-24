using Data.Entities;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models;

public interface IPostService
{
    int Add(Post book);
    void Delete(int id);
    void Update(Post book);
    List<Post> FindAll(int page, int pageSize);
    Post? FindById(int id);
    List<GroupEntity> FindAllOrganizations();
    int CountBooks();
    List<Post> GetBooksByLibraryId(int libraryId);
    IEnumerable<Post> GetBooks(); // Dodaj tę metodę
}