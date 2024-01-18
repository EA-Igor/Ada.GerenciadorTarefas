using Ada.GerenciadorTarefas.Funcionarios;
using Ada.GerenciadorTarefas.JsonParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ada.GerenciadorTarefas.Ui
{
    public class MenuDesenvolvedor
    {
        
        static public void Menu(Funcionario Dev)
        {
            Console.WriteLine("=== Menu Desenvolvedor ===");
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Adicionar tarefa");
            Console.WriteLine("2 - Ver tarefas");
            Console.WriteLine("3 - Voltar");
            string opcao = Console.ReadLine();
            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome da nova tarefa: ");
                    string nomeNovaTarefa = Console.ReadLine();
                    Console.WriteLine("Digite a descrição da nova tarefa: ");
                    string descricaoNovaTarefa = Console.ReadLine();
                    int idNovaTarefa;
                    do
                    {
                        Console.WriteLine("Digite o id da nova tarefa: ");
                        bool verificacao = int.TryParse(Console.ReadLine(), out idNovaTarefa);
                        if (verificacao)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Número de tarefa inválido!");
                        }
                    } while (true);
                    Dev.AdicionarTarefa(idNovaTarefa, Dev, nomeNovaTarefa, descricaoNovaTarefa);
                    break;
                case "2":
                    Gerenciamento g1 = new Gerenciamento();
                    g1.VerTarefas();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}
