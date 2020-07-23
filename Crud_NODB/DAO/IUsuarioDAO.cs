using System.Collections.Generic;
using Crud_NODB.Models;

namespace Crud_NODB.DAO
{
	public interface IUsuarioDAO
	{
		IEnumerable<Usuario> GetAll();
		void Add(Usuario obj);
		void Update(int id, Usuario obj);
		Usuario GetByID(int id);
		void Delete(int id);
	}
}
