using BE;

namespace BLL
{
    public interface ISilderService
    {
        public List<Silder> GetAllSilders();
        public void AddSilder(Silder model);
        public Silder GetSilderById(int Id);

        public void EditSilder(Silder silder);
    }
}
