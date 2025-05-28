using AssetManager.Data;
using AssetManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssetManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Add()
        {
            return View();
        }
    

        [HttpPost]
        public async Task<IActionResult> Add(Hostdetail host)
        {
            var connStr = _context.Database.GetDbConnection().ConnectionString;
            Console.WriteLine("Connected to DB: " + connStr);
            int count = await _context.Hostdetails.CountAsync();
            host.DeviceId = "DVC" + (count + 1).ToString("D3");

            _context.Hostdetails.Add(host);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Host added successfully!";
            //TempData["Success"] = "Host added successfully to: " + connStr;

            return RedirectToAction("Add");
        }

        
        public async Task<IActionResult> Hostview(string search, string group)
        {
            var query = _context.Hostdetails
        .Where(h => h.HostStatus == "Active") 
        .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(h =>
                    h.HostName.Contains(search) ||
                    h.MacAddress.Contains(search) ||
                    h.IpAddress.Contains(search) ||
                    h.HostUser.Contains(search));
            }

            if (!string.IsNullOrEmpty(group))
            {
                query = query.Where(h => h.HostGroup == group);
            }


            ViewBag.Groups = await _context.Hostdetails
                .Select(h => h.HostGroup)
                .Distinct()
                .ToListAsync();

            ViewBag.CurrentSearch = search;
            ViewBag.CurrentGroup = group;

            var results = await query.ToListAsync();
            return View(results);
        }

    }
}