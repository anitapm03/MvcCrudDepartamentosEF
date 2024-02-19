using Microsoft.AspNetCore.Mvc;
using MvcCrudDepartamentosEF.Repositories;
using MvcCrudDepartamentosEF.Models;

namespace MvcCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int iddepartamento)
        {
            Departamento dept = this.repo.FindDepartamento(iddepartamento);
            return View(dept);
        }

        public IActionResult Eliminar(int iddepartamento)
        {
            this.repo.EliminarDepartamento(iddepartamento);
            return RedirectToAction("Index");
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Departamento dept)
        {
            this.repo.InsertarDepartamento
                (dept.IdDepartamento, dept.Nombre, dept.Loc);
            return RedirectToAction("Index");
        }

        public IActionResult Modificar(int iddepartamento)
        {
            Departamento dept = this.repo.FindDepartamento(iddepartamento);
            return View(dept);
        }
        [HttpPost]
        public IActionResult Modificar(Departamento dept)
        {
            this.repo.ModificarDepartamento
                (dept.IdDepartamento, dept.Nombre, dept.Loc);
            return RedirectToAction("Index");
        }
    }
}
