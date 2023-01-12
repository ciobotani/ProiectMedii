using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Inrolari
{
    public class EditModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public EditModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inrolare Inrolare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inrolare = await _context.Inrolare
                .Include(i => i.Curs)
                .Include(i => i.Student).FirstOrDefaultAsync(m => m.ID == id);

            if (Inrolare == null)
            {
                return NotFound();
            }
           ViewData["CursID"] = new SelectList(_context.Curs, "ID", "Denumire");
           ViewData["StudentID"] = new SelectList(_context.Student, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inrolare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InrolareExists(Inrolare.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InrolareExists(int id)
        {
            return _context.Inrolare.Any(e => e.ID == id);
        }
    }
}
