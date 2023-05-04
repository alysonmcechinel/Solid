using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface IQuerys<T>
	{
		IEnumerable<T> BuscarTodos();
		T BuscarPorId(int id);
	}
}
