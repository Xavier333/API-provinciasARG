using System;
using System.Net;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using IDGCoreWebAPI.Controllers;
using WebAPIEFSample.Models;

namespace IDGCoreWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class provinciasARGController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<string> Get()
        {
            string[] salida = new string[] { "Envie el ID de la provincia (De 0 a 23):" };

            return salida;

        }

        [HttpGet("{id}")]
        public IEnumerable<provincialatlon> Get(int id)
        {
                        
                string url = "https://apis.datos.gob.ar/georef/api/provincias";
                var json = new WebClient().DownloadString(url);
                dynamic m = JsonConvert.DeserializeObject(json);

                var nombprov = m.provincias[id].nombre;
                var lat = m.provincias[id].centroide.lat;
                var lon = m.provincias[id].centroide.lon;

                //dynamic nombprov = JsonConvert.SerializeObject(vss);

                List<provincialatlon> authors = new List<provincialatlon>();
                authors.Add(new provincialatlon()
                {
                    Id = id,
                    Provincia = nombprov,
                    Lat = lat,
                    Lon = lon
                });
            return authors;

            /*
            var lat = m.provincias[id].centroide.lat;
            dynamic latjson = JsonConvert.SerializeObject(lat);

            var lon = m.provincias[id].centroide.lon;
            dynamic lonjson = JsonConvert.SerializeObject(lon);

            string[] resultado = new string[] { nombprov, latjson, lonjson };
            */

        }
    }

}