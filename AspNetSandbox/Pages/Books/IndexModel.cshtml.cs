using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Model for main dashboard of books.</summary>
    public class IndexModel : PageModel
    {
        private readonly AspNetSandbox.Data.ApplicationDbContext context;

        public IndexModel(AspNetSandbox.Data.ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await this.context.Book.ToListAsync();
        }
    }
}
