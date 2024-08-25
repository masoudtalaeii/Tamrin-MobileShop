using BE;

namespace BLL
{
    public interface IProductFeatureService
    {
        public void Add(ProductFeature model);
        public List<ProductFeature> GetAll(int id);

        public ProductFeature GetById(int id);

        public void Edit(ProductFeature model);
    }
}
