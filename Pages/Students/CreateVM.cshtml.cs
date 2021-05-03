using Coursework.Models;
using Coursework.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;

namespace Coursework.Pages.Students
{
    public class CreateVMModel : PageModel
    {
        private readonly Coursework.Data.SchoolContext _context;

        public CreateVMModel(Coursework.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            StudentVM = new StudentVM
            {
                EnrollmentDate = DateTime.Now,
                FirstMidName = "Joe VM",
                LastName = "Smith VM"
            };
            return Page();
        }
        #region snippet
        [BindProperty]
        public StudentVM StudentVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Student());
            entry.CurrentValues.SetValues(StudentVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        #endregion
    }
}
