using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMedii.Data;
using ProiectMedii.Models;

namespace ProiectMedii.Pages.Inrolari
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public DeleteModel(ProiectMedii.Data.ProiectMediiContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Inrolare = await _context.Inrolare.FindAsync(id);

            if (Inrolare != null)
            {
                _context.Inrolare.Remove(Inrolare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
