using PetShop.Data.Contexts;
using PetShop.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PetShopDataContext _context;
        public CommentRepository(PetShopDataContext petShopContext)
        {
            _context = petShopContext;
        }

        public Comment Add(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Comment AddComment(string context, int id)
        {
            var commententity = new Comment { AnimalId = id, Content = context};
            _context.Comments.Add(commententity);
            _context.SaveChanges();
            return commententity;
        }
        public Comment Delete(int id)
        {
            var comments = Get(id);
            if (comments != null)
            {
                _context.Comments.Remove(comments);
                return comments;
            }
            else return null;
            _context.SaveChanges();
        }

        public Comment Get(int? id)
        {
            var comments = _context.Comments.FirstOrDefault(comments => comments.CommentId == id);
            return comments;
        }

        public IEnumerable<Comment> GetAnimalComments(int? id)
        {
            return _context.Comments.Where(comment => comment.AnimalId == id);
        }

        public IQueryable<Comment> GetAll()
        {
            return _context.Comments;
        }
    }
}
