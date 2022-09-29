using PetShop.Client.Repositories;
using PetShop.Data.Model;
namespace PetShop.Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IEnumerable<Comment> GetAnimalComments(int? id);
        Comment AddComment(string context, int id);

    }

}
