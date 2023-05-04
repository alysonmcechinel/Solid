using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
	public interface ICommand<T>
	{
		
		void Add(T obj);
		void Edit(T obj);
		void Remove(T obj);
	}
}
