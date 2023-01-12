using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Inrolari
{
    public class CreateModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public CreateModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CursID"] = new SelectList(_context.Curs, "ID", "Denumire");
        ViewData["StudentID"] = new SelectList(_context.Student, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Inrolare Inrolare { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Inrolare.Add(Inrolare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
