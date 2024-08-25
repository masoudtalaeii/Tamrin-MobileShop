using BE;

namespace BLL
{
    public interface IProductCommentService
    {
        public List<ProductComment> GetAll(int id);

        public ProductComment GetById(int id);
        public void ActiveDeActiveComment(int id);

    }
}
