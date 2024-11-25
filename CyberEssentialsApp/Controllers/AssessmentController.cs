using CyberEssentialsApp.Data;
using CyberEssentialsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CyberEssentialsApp.Controllers
{
    public class AssessmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssessmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Assessment
        public async Task<IActionResult> Index()
        {
            var totalWorkstations = await _context.Workstations.CountAsync();
            var totalServers = await _context.Servers.CountAsync();
            var totalMobiles = await _context.Mobiles.CountAsync();
            var totalFirewalls = await _context.Firewalls.CountAsync();

            var model = new AssessmentViewModel
            {
                Workstations = await _context.Workstations.ToListAsync(),
                Servers = await _context.Servers.ToListAsync(),
                Mobiles = await _context.Mobiles.ToListAsync(),
                Firewalls = await _context.Firewalls.ToListAsync(),
                TotalWorkstations = totalWorkstations,
                TotalServers = totalServers,
                TotalMobiles = totalMobiles,
                TotalFirewalls = totalFirewalls,
                RequiredSampleSize = CalculateSampleSize(totalWorkstations, totalServers, totalMobiles, totalFirewalls)
            };

            return View(model);
        }

        private Dictionary<string, int> CalculateSampleSize(int workstations, int servers, int mobiles, int firewalls)
        {
            return new Dictionary<string, int>
            {
                { "Workstations", GetSampleSize(workstations) },
                { "Servers", GetSampleSize(servers) },
                { "Mobiles", GetSampleSize(mobiles) },
                { "Firewalls", firewalls } // 1:1 ratio for firewalls
            };
        }

        private int GetSampleSize(int deviceCount)
        {
            if (deviceCount <= 0) return 0; // No devices
            if (deviceCount >= 2 || deviceCount <= 5) return 2;
            if (deviceCount >= 6 || deviceCount <= 19) return 3;
            if (deviceCount >= 20 || deviceCount <= 60) return 4;
            return 5; // 61+ devices
        }
    }
}
