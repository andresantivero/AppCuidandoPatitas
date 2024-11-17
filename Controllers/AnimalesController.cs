using Microsoft.AspNetCore.Mvc;
using AppCuidandoPatitas.Datos;
using AppCuidandoPatitas.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppCuidandoPatitas.Controllers
{
    public class AnimalesController : Controller
    {
        readonly DatosAnimales DatosAnimales = new();
        readonly DatosDocumento DatosDocumento = new();

        public enum TipoDocumento
        {
            DocumentoAnimal = 2
        }
        [Authorize(Roles = "cp_admin, cp_rescatista, cp_adoptante")]
        public IActionResult traerMascotas()
        {
            var listaAnimales = DatosAnimales.Listar();
            return View("ListarAnimales", listaAnimales);
        }
        [Authorize(Roles = "cp_admin, cp_rescatista")]
        public IActionResult vistaIngresarMascota()
        {
            return View(); 
        }

        [Authorize(Roles = "cp_admin, cp_rescatista")]
        [HttpPost]
        public IActionResult ingresarMascota(ModelAnimales objMascota, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                // Verificar si se ha enviado una foto y tiene contenido
                // Si hay una foto, la guardamos en la carpeta raíz
                objMascota.UserAlta = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                var respuesta = DatosAnimales.Guardar(objMascota, imagen);
                if (respuesta == true)
                {
                    TempData["SuccessMessage"] = "La mascota se ingresó correctamente.";
                    return RedirectToAction("traerMascotas");

                }
                else
                {
                    TempData["ErrorMessage"] = "No se pudo ingresar la mascota. Intenta nuevamente.";
                    TempData["ModelErrors"] = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

                    return RedirectToAction("vistaIngresarMascota");

                }
            }
            else
            {
                return RedirectToAction("vistaIngresarMascota", objMascota);
            }   
        }

        [Authorize(Roles = "cp_admin, cp_rescatista, cp_adoptante")]
        [HttpPost]
        public IActionResult adoptarMascota(int animalId)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var respuesta = DatosAnimales.adoptarAnimal(animalId, userId);

            if (respuesta != 0)
            {
                return traerMascotas();
            }
            else
            {
                 return traerMascotas(); //ENTRA AL ELSE POR EL USER ID
            }                 
        }

        [Authorize(Roles = "cp_admin, cp_rescatista")]
        [HttpPost]
        public IActionResult eliminarMascota(int animalId) 
        {
            var respuesta = DatosAnimales.eliminarAnimal(animalId);

             if (respuesta != 0)
            {
                return traerMascotas();
            }
            else
            {
                return View();
            }                 
        }
        [Authorize(Roles = "cp_admin, cp_rescatista")]
        [HttpPost]
        public IActionResult actualizarMascota(ModelAnimales objAnimal)
        {
            var respuesta = DatosAnimales.Editar(objAnimal);

             if (respuesta != true)
            {
                return RedirectToAction("traerMascotas");
            }
            else
            {
                return traerMascotas();
            }                 
        }
        [Authorize(Roles = "cp_admin, cp_rescatista")]
        public IActionResult modificarAnimalVista(int animalId)
        {
            var mascota = DatosAnimales.TraerUno(animalId);

            if(mascota != null)
            {
                var listaDocumentos = DatosDocumento.ListarDocumento((int)TipoDocumento.DocumentoAnimal);
                ViewBag.ListaDocumentos = listaDocumentos;
                return View(mascota);
            }
            else
            {
                return RedirectToAction("traerMascotas");
            }
        }
    }
}