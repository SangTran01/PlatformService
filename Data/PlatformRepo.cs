using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo : IPlatformRepo
    {
        private readonly AppDbContext _context;

        public PlatformRepo(AppDbContext appDbContext) 
        {
            _context = appDbContext;
        }

        void IPlatformRepo.CreatePlatform(Platform platform)
        {
            if (platform == null)
            { 
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        IEnumerable<Platform> IPlatformRepo.GetAllPlatforms()
        {
            var res = _context.Platforms.ToList();
            return res;
        }

        Platform IPlatformRepo.GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        bool IPlatformRepo.SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
