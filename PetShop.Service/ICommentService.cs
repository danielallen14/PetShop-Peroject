using PetShop.Client.Repositories;
using PetShop.Data.Model;

namespace PetShop.Service
{
    public interface ICommentService : IRepository<Comment>
    {
        IEnumerable<Comment> GetAnimalComments(int? id);
        void AddComment(string context, int id);

    }
}