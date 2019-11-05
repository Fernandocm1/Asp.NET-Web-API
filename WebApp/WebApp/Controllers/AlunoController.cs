using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApp.Models;

namespace WebApp.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/Aluno")]
    public class AlunoController : ApiController
    {
        // GET: api/Aluno
        [HttpGet]
        [Route("Recuperar")]
        public IHttpActionResult Recuperar()
        {
            try
            {
                AlunoModel aluno = new AlunoModel();
                return Ok(aluno.listarAlunos());
            }
            catch (Exception ex){
                return InternalServerError(ex);
            }
        }

        // GET: api/Aluno/5
        [HttpGet]
        [Route("Recuperar/{id:int}/{nome?}/{sobrenome?}")]
        public AlunoDTO Get(int id, string nome = null, string sobrenome = null)
        {
            AlunoModel aluno = new AlunoModel();

            return aluno.listarAlunos(id).Where(x=> x.id== id).FirstOrDefault();
        }

        [HttpGet]
        [Route(@"RecuperarPorDataNome/{data:regex([0-9]{4}\-[0-9]{2})}/{nome:minlength(5)}")]
        public IHttpActionResult Recuperar2(string data, string nome)
        {
            try
            {
                AlunoModel aluno = new AlunoModel();


                return Ok(aluno.listarAlunos().Where(a => a.data == data || a.nome == nome));
            }
            catch (Exception ex)
            {  
                return BadRequest("deu zica: " + ex);
            }
        }

        // POST: api/Aluno
        [HttpPost]
        public IHttpActionResult Post(AlunoDTO aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  
            }
            try
            {
                AlunoModel _aluno = new AlunoModel();

                _aluno.Inserir(aluno);

                return Ok(_aluno.listarAlunos());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Aluno/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]AlunoDTO aluno)
        {
            try
            {

                AlunoModel _aluno = new AlunoModel();
                aluno.id = id;
                _aluno.Atualizar(aluno);

                return Ok(_aluno.listarAlunos(id).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Aluno/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {

                AlunoModel _aluno = new AlunoModel();
                _aluno.Deletar(id);
                return Ok("Deletado com Sucesso!");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
