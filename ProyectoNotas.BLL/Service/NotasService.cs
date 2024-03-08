using ProyectoNotas.DAL.Repositorio;
using ProyectoNotas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotas.BLL.Service
{
    public class NotasService : INotasService
    {
        private readonly IGenericRepository<Nota> _NotRepo;

        public NotasService(IGenericRepository<Nota> NotRepo)
        {
            _NotRepo = NotRepo;
        }

        public async Task<bool> Actualizar(Nota modelo)
        {
            return await _NotRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _NotRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Nota modelo)
        {
            return await _NotRepo.Insertar(modelo);
        }

        public async Task<Nota> Obtener(int id)
        {
            return await _NotRepo.Obtener(id);
        }

        public async Task<Nota> ObtenerPorNota(string nombreNota)
        {
            IQueryable<Nota> queryContactoSQL = await _NotRepo.ObtenerTodos();
            Nota nota = queryContactoSQL.Where(c => c.Titulo == nombreNota).FirstOrDefault();
            return nota;
        }

        public async Task<IQueryable<Nota>> ObtenerTodos()
        {
            return await _NotRepo.ObtenerTodos();
        }
    }
}
