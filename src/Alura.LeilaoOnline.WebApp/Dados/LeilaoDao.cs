using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public class LeilaoDao
	{
		AppDbContext _context;

		public LeilaoDao()
		{
			_context = new AppDbContext();
		}

		public IEnumerable<Categoria> BuscarCategorias()
		{
			return _context.Categorias.OrderBy(a => a.Id).ToList();
		}

		public IEnumerable<Leilao> BuscarLeiloes()
		{
			return _context.Leiloes.Include(l => l.Categoria).ToList();
		}

		public Leilao BuscarPorId(int id)
		{
			return _context.Leiloes.First(a => a.Id == id);
		}
	}
}
