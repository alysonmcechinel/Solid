using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
	public class CategoriaDao : ICategoriaDao
	{
		AppDbContext _context;

		public CategoriaDao()
		{
			_context = new AppDbContext();
		}

		public IEnumerable<Categoria> BuscarTodos()
		{
			return _context.Categorias;
		}

		public Categoria BuscarPorId(int categoria)
		{
			return _context.Categorias
				.Include(c => c.Leiloes)
				.First(c => c.Id == categoria);
		}

		public IEnumerable<Categoria> ConsultaCategorias()
		{
			return _context.Categorias.Include(c => c.Leiloes).OrderBy(a => a.Id).ToList();
		}

		

		
		
	}
}
