using Data;
using Data.Entities;


namespace Labolatorium_3_App.Models
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;
        public EFContactService(AppDbContext context)
        {
            _context = context;
        }



        public int Add(Contact contact)
        {
            var e = _context.Contacts.Add(ContactMapper.ToEntity(contact));
            _context.SaveChanges();
            int id = e.Entity.Id;

            return id;
        }

        public void Delete(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);
            if (find != null)
            {
                _context.Contacts.Remove(find);
                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts.Select(e => ContactMapper.FromEntity(e)).ToList();
        }

        public List<OrganizationEntity> FindAllOrganizations()
        {
            return _context.Organizations.ToList();
        }

        public Contact? FindById(int id)
        {
            ContactEntity? find = _context.Contacts.Find(id);

            return find != null ? ContactMapper.FromEntity(find) : null;


        }

        public void Update(Contact contact)
        {
            _context.Contacts.Update(ContactMapper.ToEntity(contact));

            _context.SaveChanges();
        }

    }
}