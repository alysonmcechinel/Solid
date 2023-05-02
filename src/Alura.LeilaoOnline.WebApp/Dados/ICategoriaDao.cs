using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ICategoriaDao
	{
		IEnumerable<Categoria> BuscarCategorias();
		IEnumerable<Categoria> BuscarCategoriasDetalhado();
		Categoria BuscarPorId(int categoria);
	}
}
