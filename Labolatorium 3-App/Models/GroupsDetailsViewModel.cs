namespace Labolatorium_3_App.Models
{
    public class GroupsDetailViewModel
    {
        public Group Group { get; set; }
        public IEnumerable<Post> Posts { get; set; }

        // Możesz dodać tutaj inne właściwości, jeśli będą potrzebne
    }
}
