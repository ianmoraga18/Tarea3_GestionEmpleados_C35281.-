using Microsoft.AspNetCore.Mvc;
using GestionE.BL;
using GestionE.Models;

namespace Gestion_de_Empleados.web.Controllers
{
    public class EmpleadosController : Controller
    {

        private readonly IEmpleadoRepository _repo;
        public EmpleadosController(IEmpleadoRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index(string busqueda = "", int pagina = 1, int tamano = 5)
        {
            var empleados = _repo.ObtenerPaginado(pagina, tamano, busqueda);
            var total = _repo.ContarTotal(busqueda);
            var toalPaginas = (int)Math.Ceiling((double)total / tamano);
            ViewBag.Busqueda = busqueda;
            ViewBag.Pagina = pagina;
            ViewBag.TotalPaginas = toalPaginas;
            ViewBag.TotalRegistros = total;
            return View(empleados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Agregar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction(nameof(Index));
            }
            return View(empleado);
        }


        [HttpPost]
        public IActionResult ToggleActivo(int id)
        {
            _repo.Eliminar(id);
            return RedirectToAction(nameof(Index));

        }
    }
}