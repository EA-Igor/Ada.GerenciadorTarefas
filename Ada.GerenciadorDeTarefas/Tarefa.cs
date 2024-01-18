using Ada.GerenciadorTarefas.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Ada.GerenciadorTarefas
{
    public class Tarefa
    {
        public int id { get; set; }                
        public Funcionario Responsavel { get; set; }
        public string Descricao { get; set; }
        public string Titulo { get; set; }
        public DateTime Prazo { get; set; }
        public DateTime DataInicio { get; set; }

        public Tarefa(int id, Funcionario responsavel, string descricao, string titulo)
        {
            this.id = id;           
            this.Responsavel = responsavel;
            this.Descricao = descricao;
            this.Titulo = titulo;
            DataInicio = DateTime.Now;
            Prazo = DataInicio.AddDays(0);
        }
    }
}
