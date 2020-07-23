using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Crud_NODB.Models;

namespace Crud_NODB.DAO
{
	public class UsuariosDAO : IUsuarioDAO
	{
		public void Add(Usuario obj)
		{
			var usuarios = GetUsuariosFromFile();
			obj.UsuarioID = usuarios.Count() + 1;
			usuarios.Add(obj);

			SalvarArquivoUsuarios(JsonConvert.SerializeObject(usuarios));
		}

		public void Delete(int id)
		{
			var usuarios = GetUsuariosFromFile();
			usuarios.RemoveAll( u => u.UsuarioID == id);
			SalvarArquivoUsuarios(JsonConvert.SerializeObject(usuarios));
		}

		public IEnumerable<Usuario> GetAll()
		{
			return GetUsuariosFromFile();
		}

		public Usuario GetByID(int id)
		{
			return GetUsuariosFromFile().Where( u => u.UsuarioID == id).SingleOrDefault();
		}


		public void Update(int id, Usuario obj)
		{
			var usuarios = GetUsuariosFromFile();
			usuarios.RemoveAll(u => u.UsuarioID == id);
			obj.UsuarioID = id;
			usuarios.Add(obj);

			SalvarArquivoUsuarios(JsonConvert.SerializeObject(usuarios));
		}		

		private void SalvarArquivoUsuarios(string jsonUsers)
		{
			string arquivo = Path.Combine(Directory.GetCurrentDirectory(), "usuarios.json");

			if (!File.Exists(arquivo))
				File.Delete(arquivo);

			File.Create(arquivo).Dispose();
			File.WriteAllText(arquivo, jsonUsers);
		}


		private List<Usuario> GetUsuariosFromFile()
		{
			string arquivo = Path.Combine(Directory.GetCurrentDirectory(), "usuarios.json");
			List<Usuario> items = new List<Usuario>();

			if (File.Exists(arquivo))
				using (StreamReader r = new StreamReader(arquivo))
				{
					string json = r.ReadToEnd();
					if (json.Length > 0)
						items.AddRange(JsonConvert.DeserializeObject<List<Usuario>>(json));
				}

			return items;
		}

		
	}
}
