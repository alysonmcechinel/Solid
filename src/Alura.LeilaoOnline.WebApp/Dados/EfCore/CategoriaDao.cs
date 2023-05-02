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

		public IEnumerable<Categoria> BuscarCategorias()
		{
			return _context.Categorias.OrderBy(a => a.Id).ToList();
		}

		public IEnumerable<Categoria> BuscarCategoriasDetalhado()
		{
			return _context.Categorias
				.Include(c => c.Leiloes)
				.Select(c => new CategoriaComInfoLeilao
				{
					Id = c.Id,
					Descricao = c.Descricao,
					Imagem = c.Imagem,
					EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
					EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
					Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
				});
		}

		public Categoria BuscarPorId(int categoria)
		{			
			return _context.Categorias
				.Include(c => c.Leiloes)
				.First(c => c.Id == categoria);
		}

		
		
	}
}
