using Ada.GerenciadorTarefas.Funcionarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.GerenciadorTarefas.JsonParser
{
    public class Gerenciamento
    {

        public List<Tarefa> tarefas = new List<Tarefa>();
        public void AdicionarTarefa(int idNovaTarefa, Funcionario usuarioLogado, string nomeNovaTarefa, string descricaoNovaTarefa)
        {           
            Tarefa tarefaNova = new(idNovaTarefa, usuarioLogado, nomeNovaTarefa, descricaoNovaTarefa);
            tarefas.Add(tarefaNova);
            Console.WriteLine("Tarefa adicionada com sucesso!");
        }
        
        public void VerTarefas()
        {
            Console.WriteLine("=== Lista de Tarefas ===");

            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhuma tarefa encontrada.");
            }
            else
            {
                foreach (Tarefa tarefa in tarefas)
                {                    
                    Console.WriteLine($"Id: {tarefa.id} - Responsável: {tarefa.Responsavel} - Titulo: {tarefa.Titulo} - Descrição: {tarefa.Descricao} - Inicio: {tarefa.DataInicio} - Prazo: {tarefa.Prazo}");
                    

                }
            }
        }

        public static Tarefa? BuscarTarefaPorId(int id)
        {
            var tarefas = File.ReadAllText("funcionarios.json");
            var json = JsonConvert.DeserializeObject<List<Tarefa>>(tarefas);
            var tarefa = json?.FirstOrDefault(f => f.id == id);

            return tarefa;
        }

        public void RemoverTarefa()
        {
            Console.WriteLine("=== Remover Tarefa ===");
            VerTarefas();
            Console.WriteLine("Digite o número da tarefa que deseja remover: ");
            bool verificacao = int.TryParse(Console.ReadLine(), out int numeroTarefa);
            do
            {
                if (verificacao)
                {
                    Console.WriteLine("Tarefa removida com sucesso!");
                    tarefas.RemoveAt(numeroTarefa - 1);
                    break;
                }
                else
                {
                    Console.WriteLine("Número de tarefa inválido!");
                }
            } while (true);

        }

        public void DefinirPrazo()
        {
            Console.WriteLine("=== Definir Prazo ===");
            VerTarefas();

            Tarefa tarefaSelecionada;
            do
            {
                Console.WriteLine("Digite o número da tarefa que deseja definir o prazo: ");
                bool verificacao = int.TryParse(Console.ReadLine(), out int numeroTarefa);
                if (verificacao)
                {
                    tarefaSelecionada = BuscarTarefaPorId(numeroTarefa);
                    break;
                }
                else
                {
                    Console.WriteLine("Número de tarefa inválido!");
                }
            } while (true);
            do
            {
                Console.WriteLine("Digite o prazo da tarefa em dias: ");
                bool verificacao = int.TryParse(Console.ReadLine(), out int prazoDefinido);
                if (verificacao)
                {
                    tarefaSelecionada.Prazo.AddDays(prazoDefinido);
                    break;
                }
                else
                {
                    Console.WriteLine("Número de tarefa inválido!");
                }
            } while (true);
            Console.WriteLine("Prazo definido com sucesso!");
        }
        public void SalvarTudo()
        {
            JsonParse.SalvarTarefas(tarefas);
        }

        public void InicializarTudo()
        {
            tarefas = JsonParse.ReceberJsonTarefa();
        }
    }
}
