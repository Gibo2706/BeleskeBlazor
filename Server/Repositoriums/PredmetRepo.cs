using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;

namespace BeleskeBlazor.Server.Repositoriums
{
    public class PredmetRepo
    {
        private readonly DataContext _context;

        public PredmetRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Predmet>> GetAllPredmeti()
        {
            List<Predmet> list = _context.Predmet.ToList<Predmet>();
            return list;
        }
    }
}
