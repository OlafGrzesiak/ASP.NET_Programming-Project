using Data;
using Data.Entities;


namespace Labolatorium_3_App.Models
{
    public class EFPostService : IPostService
    {
        private readonly AppDbContext _context;
        public EFPostService(AppDbContext context)
        {
            _context = context;
        }



        public int Add(Post post)
        {
            var e = _context.Posts.Add(PostMapper.ToEntity(post));
            _context.SaveChanges();
            int id = e.Entity.Id;

            return id;
        }

        public void Delete(int id)
        {
            PostEntity? find = _context.Posts.Find(id);
            if (find != null)
            {
                _context.Posts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Post> FindAll(int page, int pageSize)
        {
            return _context.Posts
                           .Skip((page - 1) * pageSize)
                           .Take(pageSize)
                           .Select(e => PostMapper.FromEntity(e))
                           .ToList();
        }

        public List<GroupEntity> FindAllOrganizations()
        {
            return _context.Groups.ToList();
        }

        public Post? FindById(int id)
        {
            PostEntity? find = _context.Posts.Find(id);

            return find != null ? PostMapper.FromEntity(find) : null;


        }

        public void Update(Post post)
        {
            var existingEntity = _context.Posts.Find(post.id);

            if (existingEntity != null)
            {
                var updatedEntity = PostMapper.ToEntity(post);

                _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Post not found");
            }
        }
        public int CountBooks()
        {
            return _context.Posts.Count(); // zwraca całkowitą liczbę książek
        }

        public List<Post> GetBooksByLibraryId(int groupId)
        {
            var bookEntities = _context.Posts
                                       .Where(book => book.GroupId == groupId)
                                       .ToList();

            var books = bookEntities.Select(be => PostMapper.FromEntity(be)).ToList();
            return books;
        }

        public IEnumerable<Post> GetBooks()
        {
            return _context.Posts
                .Select(post => new Post
                {
                    id = post.Id,
                    Content = post.Content,
                    // ... przypisz pozostałe właściwości
                })
                .ToList();
        }
    }
}