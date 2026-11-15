
using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;
using System.Globalization;

namespace MYAcademi_PortfolioProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Mesaj istatistikleri
            ViewBag.v1 = _context.Messages.Count();

            ViewBag.v2 = _context.Messages
                .Count(x => x.IsRead == false);

            ViewBag.v3 = _context.Messages
                .Count(x => x.IsRead == true);


            // Son 7 günlük mesaj grafiği
            DateTime today = DateTime.Today;
            DateTime startDate = today.AddDays(-6);

            var weeklyMessages = _context.Messages
                .Where(x => x.SendDate >= startDate &&
                            x.SendDate < today.AddDays(1))
                .ToList();

            var labels = new List<string>();
            var counts = new List<int>();

            for (int i = 0; i < 7; i++)
            {
                DateTime date = startDate.AddDays(i);

                labels.Add(date.ToString("ddd", new CultureInfo("tr-TR")));

                int dailyCount = weeklyMessages.Count(x =>
                    x.SendDate.Date == date);

                counts.Add(dailyCount);
            }

            ViewBag.Labels = labels;
            ViewBag.Counts = counts;


            // Son 4 mesaj
            ViewBag.LastMessages = _context.Messages
                .OrderByDescending(x => x.SendDate)
                .Take(4)
                .ToList();
            ViewBag.TotalExperience = _context.Experiences.Count();

            ViewBag.TotalProject = _context.Projects.Count();

            ViewBag.TotalSkill = _context.Skills.Count();

            ViewBag.ActiveProject = _context.Projects
                .Count(x => x.IsFeatured == true);

            return View();
        }
    }
}
