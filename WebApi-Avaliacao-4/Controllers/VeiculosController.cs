using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Avaliacao_4.Configuration;
using System.IO;

using System.Configuration;


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
           
            try
            {
                return Ok(repoVeiculos.Select());
            }
            catch (Exception e)
            {
                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();
            }
        }

     



// GET: api/Veiculos/5
public IHttpActionResult Get(int id)
        {

            try
            {
                Models.Veiculo veiculo = repoVeiculos.Select(id);

                if (veiculo is null)
                    return NotFound();


                return Ok(veiculo);

            }
            catch (Exception)
            {

                throw;
            }

        }





        // GET: api/Veiculos?nome=
        public IHttpActionResult Get(string nome)
        {

            try
            {
                return Ok(repoVeiculos.Select(nome));

            }
            catch (Exception)
            {

                throw;
            }

        }





        // POST: api/Veiculos
        public IHttpActionResult Post([FromBody] Models.Veiculo veiculo)
        {


            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                if (!repoVeiculos.Insert(veiculo))
                    return InternalServerError();


                return Ok();

            }
            catch (Exception e)
            {
                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();
            }

        }





        // PUT: api/Veiculos/5
        public IHttpActionResult Put(int id, [FromBody] Models.Veiculo veiculo)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);


                if (id != veiculo.Id)
                    return BadRequest("id da requisição é diferente do id do body");


                bool returnBank = repoVeiculos.Update(veiculo);

                if (!returnBank)
                    return NotFound();

                
                return Ok();

            }
            catch (Exception e)
            {

                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();

            }

        }





        // DELETE: api/Veiculos/5
        public IHttpActionResult Delete(int id)
        {

        
            try
            {
                bool returnBank = repoVeiculos.Delete(id);

                if (!returnBank)
                    return NotFound();

                return Ok();

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
