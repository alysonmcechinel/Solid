using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Dados.EfCore;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
	public class DefaultAdminService : IAdminService
	{
		readonly ILeilaoDao _leilaoDao;
		readonly ICategoriaDao _categoriaDao;

		public DefaultAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
		{
			_leilaoDao = leilaoDao;
			_categoriaDao = categoriaDao;
		}
			

		public IEnumerable<Categoria> ConsultaCategorias()
		{
			return _categoriaDao.BuscarTodasCategorias();
		}

		public Leilao ConsultaLeilaoPorId(int id)
		{
			return _leilaoDao.BuscarPorId(id);
		}

		public IEnumerable<Leilao> ConsultaLeiloes()
		{
			return _leilaoDao.BuscarTodosLeiloes();
		}

		public void CadastraLeilao(Leilao leilao)
		{
			_leilaoDao.Add(leilao);
		}

		public void ModificaLeilao(Leilao leilao)
		{
			_leilaoDao.Update(leilao);
		}

		public void RemoveLeilao(Leilao leilao)
		{
			_leilaoDao.Remove(leilao);
		}

		public void FinalizaPregaoDoLeilaoComId(int id)
		{
			var leilao = _leilaoDao.BuscarPorId(id);
			if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
			{
				leilao.Situacao = SituacaoLeilao.Finalizado;
				leilao.Termino = DateTime.Now;
				_leilaoDao.Update(leilao);
			}
		}

		public void IniciaPregaoDoLeilaoComId(int id)
		{
			var leilao = _leilaoDao.BuscarPorId(id);
			if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
			{
				leilao.Situacao = SituacaoLeilao.Pregao;
				leilao.Inicio = DateTime.Now;
				_leilaoDao.Update(leilao);
			}
		}
	}
}
