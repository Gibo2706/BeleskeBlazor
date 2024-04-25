using BeleskeBlazor.Server.Data;
using BeleskeBlazor.Shared;

namespace BeleskeBlazor.Server.Repositoriums
{
    public class StudentRepo
    {
        private readonly DataContext _context;

        public StudentRepo(DataContext context)
        {
            _context = context;
        }

        public Student? getByUsername(string username)
        {
            Student s;
            try
            {
                s = _context.Student.Where(s => s.Username.Equals(username)).First();
            } catch (Exception ex)
            {
                return null;
            }
            return s;
        }
    }
}
