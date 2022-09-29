using PetShop.Client.Repositories;
using PetShop.Data.Model;
using PetShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Service
{
    public class CommentService : ICommentService
    {
        public ICommentRepository MyCommentRepository { get; }
        public CommentService( ICommentRepository repository)
        {
            MyCommentRepository = repository;
        }
        public Comment Add(Comment entity)
        {
            return MyCommentRepository.Add(entity);
        }
        public void AddComment(string context, int id)
        {
            MyCommentRepository.AddComment(context,id);
        }

        public Comment Delete(int id)
        {
            return MyCommentRepository.Delete(id);
        }

        public Comment Get(int? id)
        {
            return (Comment)MyCommentRepository.Get(id);
        }

        public IQueryable<Comment> GetAll()
        {
            return MyCommentRepository.GetAll();
        }
        public IEnumerable<Comment> GetAnimalComments(int? id)
        {
            return MyCommentRepository.GetAnimalComments(id);
        }
    }
}
