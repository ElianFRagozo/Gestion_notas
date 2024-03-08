using ProyectoNotas.DAL.DataContext;
using ProyectoNotas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNotas.DAL.Repositorio
{
    public class NotasRepository : IGenericRepository<Nota>
    {

        private readonly NotasContext _dbcontext;

        public NotasRepository(NotasContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Nota modelo)
        {
            _dbcontext.Notas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            Nota modelo = _dbcontext.Notas.First(c => c.Idnota == id);
            _dbcontext.Notas.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Nota modelo)
        {
            _dbcontext.Notas.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Nota> Obtener(int id)
        {
            return await _dbcontext.Notas.FindAsync(id);
        }

        public async Task<IQueryable<Nota>> ObtenerTodos()
        {
            IQueryable<Nota> queryContactoSQL = _dbcontext.Notas;
            return queryContactoSQL;
        }
    }
}
