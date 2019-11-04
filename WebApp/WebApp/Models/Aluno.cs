using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApp.Models
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string telefone { get; set; }
        public int ra { get; set; }

        public List<Aluno> listarAlunos() 
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = File.ReadAllText(caminhoArquivo);

            var listaAlunos = JsonConvert.DeserializeObject<List<Aluno>>(json);

            return listaAlunos;
            /*
            Alunos aluno = new Alunos();
            aluno.id = 1;
            aluno.nome = "Marta";
            aluno.sobrenome = "Will";
            aluno.telefone = "123456";
            aluno.ra = 00001;

            Alunos aluno1 = new Alunos();
            aluno1.id = 2;
            aluno1.nome = "Fernando";
            aluno1.sobrenome = "Marques";
            aluno1.telefone = "123456";
            aluno1.ra = 00002;

            List<Alunos> listaAlunos = new List<Alunos>();

            listaAlunos.Add(aluno);
            listaAlunos.Add(aluno1);

            return listaAlunos;
            */
        }
        public List<Aluno> RescreverArquivo(List<Aluno>listaAlunos)
        {
            var caminhoArquivo = HostingEnvironment.MapPath(@"~/App_Data/Base.json");

            var json = JsonConvert.SerializeObject(listaAlunos, Formatting.Indented);
            File.WriteAllText(caminhoArquivo, json);
            
            return listaAlunos;
        }
        public Aluno Inserir(Aluno Aluno)
        {
            var listaAlunos = this.listarAlunos();

            var maxId = listaAlunos.Max(aluno => aluno.id);
            Aluno.id = maxId + 1;
            listaAlunos.Add(Aluno);
            Console.WriteLine("este é o valor de id" + Aluno.id);
            RescreverArquivo(listaAlunos);
            return Aluno;
        }
        
        public Aluno Atualizar(int id, Aluno Aluno)
        {
            var listaAlunos = this.listarAlunos();

            var itemIndex = listaAlunos.FindIndex(p => p.id == Aluno.id);

            if (itemIndex >= 0)
            {
                Aluno.id = id;
                listaAlunos[itemIndex] = Aluno;
            }
            else 
            {
                return null;
            }

            RescreverArquivo(listaAlunos);
            return Aluno;

        }
        public bool Deletar(int id)
        {
            var listaAlunos = this.listarAlunos();
            var itemIdex = listaAlunos.FindIndex(p => p.id == id);
            if (itemIdex >= 0)
            {
                listaAlunos.RemoveAt(itemIdex);
            }
            else 
            {
                return false;
            }

            RescreverArquivo(listaAlunos);
            return true;
        }
        }
}