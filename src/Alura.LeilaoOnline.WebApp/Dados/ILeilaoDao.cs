using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ILeilaoDao
	{
		Leilao BuscarPorId(int id);
		IEnumerable<Leilao> BuscarTodosLeiloes();
		void Update(Leilao leilao);
		void Remove(Leilao leilao);
		void Add(Leilao leilao);
	}
}
