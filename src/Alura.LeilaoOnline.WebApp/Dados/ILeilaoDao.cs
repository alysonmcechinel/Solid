using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ILeilaoDao : ICommand<Leilao>, IQuerys<Leilao>
	{
	}
}
