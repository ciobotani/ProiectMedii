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
    public class IndexModel : PageModel
    {
        private readonly ProiectMedii.Data.ProiectMediiContext _context;

        public IndexModel(ProiectMedii.Data.ProiectMediiContext context)
        {
            _context = context;
        }

        public IList<Inrolare> Inrolare { get;set; }

        public async Task OnGetAsync()
        {
            Inrolare = await _context.Inrolare
                .Include(i => i.Curs)
                .Include(i => i.Student).ToListAsync();
        }
    }
}
