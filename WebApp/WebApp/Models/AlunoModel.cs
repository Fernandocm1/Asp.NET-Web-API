using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class AlunoModel
    {
      

        public List<AlunoDTO> listarAlunos(int? id = null) 
        {
            try
            {
                var alunoDB = new AlunoDAO();
                return alunoDB.listarAlunosDB(id);
            }
            catch (Exception ex){
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
        }
        

        
            public List<AlunoModel> RescreverArquivo(List<AlunoModel>listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            
            return listaAlunos;
        }
        public void Inserir(AlunoDTO aluno)
        {
            /*var listaAlunos = this.listarAlunos();

            var maxId = listaAlunos.Max(aluno => aluno.id);
            Aluno.id = maxId + 1;
            listaAlunos.Add(Aluno);
            Console.WriteLine("este é o valor de id" + Aluno.id);
            RescreverArquivo(listaAlunos);
            return Aluno;*/
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.InserirAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }

        }
        
        public void Atualizar(AlunoDTO aluno)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.AtualizarAlunoDB(aluno);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }

        }
        public void Deletar(int id)
        {
            try
            {
                var alunoBD = new AlunoDAO();
                alunoBD.DeletarAlunoDB(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao listar Alunos: Erro => {ex.Message}");
            }
        }
        }
}