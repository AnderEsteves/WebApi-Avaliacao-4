using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Avaliacao_4.Configuration;
using System.IO;

using System.Configuration;
using System.Threading.Tasks;


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
        public async Task<IHttpActionResult> Get()
        {

            try
            {
                return Ok(await repoVeiculos.Select());
            }
            catch (Exception e)
            {
                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();
            }
        }

     


    
        // GET: api/Veiculos/5  
        public async Task<IHttpActionResult> Get(int id)
        {

            try
            {
                Models.Veiculo veiculo = await repoVeiculos.Select(id);

                if (veiculo is null)
                    return NotFound();


                return Ok(veiculo);

            }
            catch (Exception e)
            {
                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();
            }

        }





        // GET: api/Veiculos?nome=
        public async Task<IHttpActionResult> Get(string nome)
        {

            try
            {
                return Ok(await repoVeiculos.Select(nome));
            }
            catch (Exception e)
            {
                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();
            }

        }





        // POST: api/Veiculos
        public async Task<IHttpActionResult> Post([FromBody] Models.Veiculo veiculo)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                if (!await repoVeiculos.Insert(veiculo))
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
        public async Task<IHttpActionResult> Put(int id, [FromBody] Models.Veiculo veiculo)
        {

            if (id != veiculo.Id)
                return BadRequest("id da requisição é diferente do id do body");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                bool returnDB = await repoVeiculos.Update(veiculo);

                if (!returnDB)
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
        public async Task<IHttpActionResult> Delete(int id)
        {

        
            try
            {
                bool returnDB = await repoVeiculos.Delete(id);

                if (!returnDB)
                    return NotFound();

                return Ok();

            }
            catch (Exception e) 
            {


                Utils.Logger.WriteExpection(Logger.GetFullPath(), e);
                return InternalServerError();
            }

        }
    }
}
