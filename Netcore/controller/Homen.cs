using ClassLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Netcore.controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class Homen : ControllerBase
    {
        [HttpGet]
        [Route("lista")]
        public dynamic lista()
        {
            BL _bl = new BL();
            List<EN> _lista = _bl.mostrar_datos();


            return _lista;


        }


        //[HttpPost]
        //[Route("delete")]
       // public dynamic delete( EN _id)
       // {
           // BL _bl = new BL();
           // int resutado = _bl.eliminar_datos( );

           // return resutado;


       // }
    }
}