using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ILeilaoDao
	{
		IEnumerable<Leilao> BuscarLeiloes();
		Leilao BuscarPorId(int id);
		IEnumerable<Leilao> BuscarLeiloesTermo(string termo);
		void Update(Leilao leilao);
		void Remove(Leilao leilao);
		void Add(Leilao leilao);
	}
}
