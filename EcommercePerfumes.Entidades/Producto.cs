using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommercePerfumes.Entidades
{
	public class Producto
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public decimal Precio { get; set; }
		public int Stock { get; set; }
		public string ImagenUrl { get; set; }
		public int MarcaId { get; set; }
		public Marca Marca { get; set; }
		public string Genero { get; set; }
		public string Concentracion { get; set; }
		public int Mililitros { get; set; }
		public string Notas { get; set; }
		public bool Activo { get; set; }
	}
}
