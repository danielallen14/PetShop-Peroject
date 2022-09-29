using PetShop.Data.Model;

namespace PetShop.Client
{
    public class AnimalCommentViewModel
    {
        public Animal? animal { get; set; }
        public IEnumerable <Comment> comment { get; set; }
    }
}
