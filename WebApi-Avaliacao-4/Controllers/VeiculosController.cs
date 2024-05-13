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

        // GET: api/Veiculos?nome=
        public IHttpActionResult Get(string nome)
        {

            return Ok(repoVeiculos.Select(nome));

        }




        // POST: api/Veiculos
        public IHttpActionResult Post([FromBody] Models.Veiculo veiculo)
        {

          if(!repoVeiculos.Insert(veiculo))
                return InternalServerError();


            return Ok();

        }






        // PUT: api/Veiculos/5
        public IHttpActionResult Put(int id, [FromBody] Models.Veiculo veiculo)
        {
            
            if(id != veiculo.Id)
                return BadRequest("id da requisição é diferente do id do body");



            bool returnBank = repoVeiculos.Update(veiculo);

            if(!returnBank)
                return NotFound();


            return Ok();
        }





        // DELETE: api/Veiculos/5
        public void Delete(int id)
        {
        }
    }
}
