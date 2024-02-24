//using Labolatorium_3_App.Models;

//public class MemoryBookService : IBookService
//{

//    IDateTimeProvider _timeProvider;

//    public MemoryBookService(IDateTimeProvider timeProvider)
//    {
//        _timeProvider = timeProvider;
//        _items = new Dictionary<int, Book>();
//    }
//    private Dictionary<int, Book> _items = new Dictionary<int, Book>();
//    public int Add(Book item)
//    {
//        int id = _items.Keys.Count != 0 ? _items.Keys.Max() : 0;
//        item.id = id + 1;
//        item.Created = _timeProvider.GetCurrentDateTime();
//        _items.Add(item.id, item);
//        return item.id;
//    }

//    public void Delete(int id)
//    {
//        _items.Remove(id);
//    }

//    public List<Book> FindAll()
//    {
//        return _items.Values.ToList();
//    }

//    public Book? FindById(int id)
//    {
//        return _items[id];
//    }

//    public void Update(Book item)
//    {
//        _items[item.id] = item;
//    }


//}