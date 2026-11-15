using Microsoft.AspNetCore.Mvc;
using MYAcademi_PortfolioProject.Context;

namespace MYAcademi_PortfolioProject.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultAboutComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Abouts.FirstOrDefault();
            if (value == null)
            {
                return View();
            }
            ViewBag.title = value.Title;
            ViewBag.description2 = value.Description2;  
            ViewBag.description = value.Description;
            ViewBag.mainImageUrl = value.ImageUrl;
            ViewBag.experience = value.Experience;
            ViewBag.educationCount = value.EducationCount;
            ViewBag.studentCount = value.StudentCount;
            ViewBag.profileInfo = value.ProfileInfo;
            ViewBag.positionTitle = value.PositionTitle;
            ViewBag.resumeUrl = value.ResumeUrl;
            return View();
        }
    }
}

