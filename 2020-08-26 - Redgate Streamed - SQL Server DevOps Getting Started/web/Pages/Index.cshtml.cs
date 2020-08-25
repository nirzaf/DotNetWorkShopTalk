using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ASiteToOrderStuff.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ASiteToOrderStuffDbContext _dbContext;

        public IndexModel(ASiteToOrderStuffDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public async Task OnGetAsync()
        {
            Products = await _dbContext.Products.ToListAsync();
        }
    }
}
