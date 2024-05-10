using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Avaliacao_4.Configuration;

namespace WebApi_Avaliacao_4.Controllers
{
    public class VeiculosController : ApiController
    {

        private readonly Repositories.SQL.Veiculos repoVeiculos;

        public VeiculosController()
        {
            repoVeiculos = new Repositories.SQL.Veiculos(Base.GetConnectionString());

        }

        




        // GET: api/Veiculos
        public IHttpActionResult Get()
        
        {
            return Ok(repoVeiculos.Select());
        }


        // GET: api/Veiculos/5
        public IHttpActionResult Get(int id)
        {

            Models.Veiculo veiculo = repoVeiculos.Select(id);

            if(veiculo is null)
                return NotFound();  


            return Ok(veiculo);

        }






        // POST: api/Veiculos
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Veiculos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Veiculos/5
        public void Delete(int id)
        {
        }
    }
}
