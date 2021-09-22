using System.Threading.Tasks;
using AspNetSandbox.Hubs;
using AspNetSandbox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox.Pages.Shared
{
    /// <summary>Deletes books.</summary>
    public class DeleteModel : PageModel
    {
        private readonly IHubContext<MessageHub> hubContext;
        private readonly AspNetSandbox.Data.ApplicationDbContext context;

        public DeleteModel(AspNetSandbox.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await this.context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
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

            Book = await this.context.Book.FindAsync(id);

            if (Book != null)
            {
                this.context.Book.Remove(Book);
                await this.context.SaveChangesAsync();
                await hubContext.Clients.All.SendAsync("BookDeleted", Book);
            }

            return RedirectToPage("./Index");
        }
    }
}
