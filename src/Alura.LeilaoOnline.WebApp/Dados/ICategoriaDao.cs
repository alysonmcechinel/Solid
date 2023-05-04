using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ICategoriaDao
	{
		IEnumerable<Categoria> ConsultaCategorias();
		IEnumerable<Categoria> BuscarTodasCategorias();
		Categoria ConsultaCategoriaPorId(int id);
	}
}
