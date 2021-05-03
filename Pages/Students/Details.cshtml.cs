using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coursework.Data;
using Coursework.Models;

namespace Coursework.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly Coursework.Data.SchoolContext _context;

        public DetailsModel(Coursework.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        #region snippet_OnGetAsync
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
        #endregion
    }
}
