using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext _context;

        public PieRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _context.Pies.Include(p => p.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
               return _context.Pies.Include(p => p.Category).Where(p => p.IsPieOfTheWeek == true);
            }
        }

        public Pie GetPieById(int pieId)
        {
            return _context.Pies.Find(pieId);
        }
    }
}
