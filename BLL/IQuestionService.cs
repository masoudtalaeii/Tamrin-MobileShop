using BE;

namespace BLL
{
    public interface IQuestionService
    {
        public void Add(Question model);
        public List<Question> GetAll();

        public Question GetById(int id);

        public void Edit(Question model);
        public List<Question> GetAllForSite();
    }
}
