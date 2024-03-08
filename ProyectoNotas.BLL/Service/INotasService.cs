using ProyectoNotas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotas.BLL.Service
{
    public interface INotasService
    {
        Task<bool> Insertar(Nota modelo);
        Task<bool> Actualizar(Nota modelo);
        Task<bool> Eliminar(int id);
        Task<Nota> Obtener(int id);
        Task<IQueryable<Nota>> ObtenerTodos();


        Task<Nota> ObtenerPorNota(string nombreNota);
    }
}
