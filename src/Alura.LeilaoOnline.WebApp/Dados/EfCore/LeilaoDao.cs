using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EfCore
{
	public class LeilaoDao : ILeilaoDao
	{
		AppDbContext _context;

		public LeilaoDao()
		{
			_context = new AppDbContext();
		}		

		public IEnumerable<Leilao> BuscarLeiloes()
		{
			return _context.Leiloes.Include(l => l.Categoria).ToList();
		}

		public Leilao BuscarPorId(int id)
		{
			return _context.Leiloes.First(a => a.Id == id);
		}

		public IEnumerable<Leilao> BuscarLeiloesTermo(string termo)
		{
			return _context.Leiloes.Include(l => l.Categoria)
									.Where(l => string.IsNullOrWhiteSpace(termo) ||
										l.Titulo.ToUpper().Contains(termo.ToUpper()) ||
										l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
										l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
									);
		}		

		public void Update(Leilao leilao)
		{
			_context.Leiloes.Update(leilao);
			_context.SaveChanges();

		}

		public void Remove(Leilao leilao)
		{
			_context.Leiloes.Remove(leilao);
			_context.SaveChanges();
		}

		public void Add(Leilao leilao)
		{
			_context.Leiloes.Add(leilao);
			_context.SaveChanges();

		}
	}
}
