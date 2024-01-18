using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ada.GerenciadorTarefas.JsonParser;

namespace Ada.GerenciadorTarefas.Funcionarios
{
    public class Funcionario
    {
        public string nome { get; set; }           
        public string senha { get; set; }
        public int id { get; set; }
        public NivelAcesso nivelAcesso { get; set; }

        public Funcionario(string nome, string senha, int id, NivelAcesso nivelAcesso)
        {
            this.nome = nome;                    
            this.senha = senha;
            this.id = id;
            this.nivelAcesso = nivelAcesso;
        }
        public void AdicionarTarefa(int idNovaTarefa, Funcionario usuarioLogado, string nomeNovaTarefa, string descricaoNovaTarefa)
        {
            Gerenciamento g1 = new Gerenciamento();
            g1.AdicionarTarefa(idNovaTarefa, usuarioLogado, nomeNovaTarefa, descricaoNovaTarefa);
        }

        public void VerTarefas()
        {
            Gerenciamento g1 = new Gerenciamento();
            g1.VerTarefas();
        }

        public void RemoverTarefa()
        {
            Gerenciamento g1 = new Gerenciamento();
            g1.RemoverTarefa();
        }
    }
}
