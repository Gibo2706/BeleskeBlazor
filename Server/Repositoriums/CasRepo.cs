using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;

namespace BeleskeBlazor.Server.Repositoriums
{
    public class CasRepo
    {
        private readonly DataContext _context;

        public CasRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Cas>> GetCasoviPredmetaUSemestru(int semId, int predId)
        {
            List<Cas> list = _context.Cas
                            .Where(c => c.IdDrziNavigation.IdPredmet == predId &&
                                        c.IdDrziNavigation.IdSemestar == semId)
                            .ToList<Cas>();
            list.ForEach(c => c = _context.GetCasWithRelatedEntities(c.IdCas));
            return list;
        }
    }
}
