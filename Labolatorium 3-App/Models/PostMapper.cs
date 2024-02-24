using Data.Entities;
using Labolatorium_3_App.Models;

namespace Labolatorium_3_App.Models;

public class PostMapper
{
    public static PostEntity ToEntity(Post model)
    {
        return new PostEntity()
        {
            Created = model.Created,
            Id = model.id,
            Content = model.Content,
            Author = model.Author,
            PublicationDate = model.PublicationDate,
            Tags = model.Tags,
            Comments = model.Comments,
            GroupId = (int)model.GroupId,

        };
    }

    public static Post FromEntity(PostEntity entity)
    {
        return new Post()
        {
            Created = entity.Created,
            id = entity.Id,
            Content = entity.Content,
            Author = entity.Author,
            PublicationDate = (DateTime)entity.PublicationDate,
            Tags = entity.Tags,
            Comments = entity.Comments,
            GroupId = entity.GroupId,
        };
    }
}