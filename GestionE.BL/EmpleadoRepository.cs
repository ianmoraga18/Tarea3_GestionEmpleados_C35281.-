
using System.Collections.Generic;
using System.Linq;
using GestionE.Models;
using GestionE.Data;

namespace GestionE.BL
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly AppDbContext _context;

        public EmpleadoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Actualizar(Empleado empleado)
        {
            _context.Empleados.Update(empleado);
            _context.SaveChanges();
        }

        public void Agregar(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            _context.SaveChanges();
        }


        public void Eliminar(int id)
        {
            var empleado = _context.Empleados.Find(id);
            if (empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                _context.SaveChanges();
            }
        }

        public int ContarTotal(string busqueda)
        {

            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();
                query = query.Where(e => e.Nombre.ToLower().Contains(busqueda) ||
                                         e.Apellidos.ToLower().Contains(busqueda) ||
                                         e.Departamento.ToLower().Contains(busqueda));
            }
            return query.Count();
        }
        public IEnumerable<Empleado> ObtenerPaginado(int pagina, int tamano, string busqueda)
        {
            var query = _context.Empleados.AsQueryable();
            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();
                query = query.Where(e => e.Nombre.ToLower().Contains(busqueda) ||
                                         e.Apellidos.ToLower().Contains(busqueda) ||
                                         e.Departamento.ToLower().Contains(busqueda));
            }
            return query.Skip((pagina - 1) * tamano).Take(tamano).ToList();
        }



        public IEnumerable<Empleado> BuscarPorNombreODepartamento(string termino)
        {
            termino = termino?.ToLower() ?? "";
            return _context.Empleados
                .Where(e => e.Nombre.ToLower().Contains(termino) ||
                            e.Apellidos.ToLower().Contains(termino) ||
                            e.Departamento.ToLower().Contains(termino))
                .ToList();

        }

        public Empleado ObtenerPorId(int id) => _context.Empleados.Find(id);


        public IEnumerable<Empleado> ObtenerTodos() => _context.Empleados.ToList();

    }
}
