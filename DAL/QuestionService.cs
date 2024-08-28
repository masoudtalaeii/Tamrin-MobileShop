using BE;
using BLL;

namespace DAL
{
    public class QuestionService : IQuestionService
    {
        private readonly DB _db;

        public QuestionService(DB db)
        {
            _db = db;
        }

        public void Add(Question model)
        {

            _db.Questions.Add(model);
            _db.SaveChanges();
        }

        public void Edit(Question model)
        {
            _db.Questions.Update(model);
            _db.SaveChanges();
        }

        public List<Question> GetAll()
        {
            return _db.Questions.ToList();
        }

        public List<Question> GetAllForSite()
        {
            return _db.Questions.Where(x=>x.IsActive).ToList();
        }

        public Question GetById(int id)
        {
            return _db.Questions.FirstOrDefault(u => u.QuestionId == id);
        }
    }
}
