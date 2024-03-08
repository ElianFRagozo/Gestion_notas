using Microsoft.AspNetCore.Mvc;
using ProyectoNotas.AplicacionWeb.Models;
using ProyectoNotas.AplicacionWeb.Models.ViewsModels;
using ProyectoNotas.BLL.Service;
using ProyectoNotas.Models;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Globalization;

namespace ProyectoNotas.AplicacionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotasService _NotaService;

        public HomeController(INotasService notaServ)
        {
            _NotaService = notaServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {

            IQueryable<Nota> queryNotaSQL = await _NotaService.ObtenerTodos();

            List<VMNotas> lista = queryNotaSQL
                                                     .Select(c => new VMNotas()
                                                     {
                                                         Idnota = c.Idnota,
                                                         Titulo = c.Titulo,
                                                         Descripcion = c.Descripcion,
                                                         FechaNota = c.FechaNota.Value.ToString("dd/MM/yyyy")
                                                     }).ToList();

            return StatusCode(StatusCodes.Status200OK, lista);

        }


        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMNotas modelo)
        {

            Nota NuevoModelo = new Nota()
            {
                Titulo = modelo.Titulo,
                Descripcion = modelo.Descripcion,
                FechaNota = DateTime.ParseExact(modelo.FechaNota, "dd/MM/yyyy",CultureInfo.CreateSpecificCulture("es-CO"))
            };

            bool respuesta = await _NotaService.Insertar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMNotas modelo)
        {

            Nota NuevoModelo = new Nota()
            {
                Idnota = modelo.Idnota,
                Titulo = modelo.Titulo,
                Descripcion = modelo.Descripcion,
                FechaNota = DateTime.ParseExact(modelo.FechaNota, "dd/MM/yyyy", CultureInfo.CreateSpecificCulture("es-PE"))
            };

            bool respuesta = await _NotaService.Actualizar(NuevoModelo);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {

            bool respuesta = await _NotaService.Eliminar(id);

            return StatusCode(StatusCodes.Status200OK, new { valor = respuesta });

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
