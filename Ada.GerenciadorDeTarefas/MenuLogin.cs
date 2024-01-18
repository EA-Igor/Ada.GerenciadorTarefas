using Ada.GerenciadorTarefas.Funcionarios;
using Ada.GerenciadorTarefas.JsonParser;
namespace Ada.GerenciadorTarefas.Ui
{
    internal class InterfaceUsuario
    {
        static void Main(string[] args)
        {
            do
            {                            
                int login = 0;
                bool verificacao;
                Gerenciamento g1 = new Gerenciamento();
                string senha;        
                g1.InicializarTudo();
                Console.WriteLine("Bem-vindo(a) à biblioteca do nosso campus!");
                Console.WriteLine("Informe seu Usuário e senha para fazer login no sistema.");

                do
                {
                    Console.Write("Id: ");
                    verificacao = int.TryParse(Console.ReadLine(), out login);
                    if (verificacao)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Id inválido!");
                    }
                } while (true);
                do
                {
                    Console.Write("Senha: ");
                    senha = Console.ReadLine();
                    verificacao = Autenticacao.ValidaSenha(senha);
                    if (verificacao)
                    {
                        break;
                    }
                    Console.WriteLine("Senha inválida!");
                } while (!verificacao);
                verificacao = Autenticacao.AutenticarUsuario(login, senha);
                if (verificacao)
                {
                    Funcionario user = Autenticacao.BuscarFuncionarioPorId(login);
                    if (user.nivelAcesso == NivelAcesso.Dev)
                    {
                        MenuDesenvolvedor.Menu(user);
                    }
                    if (user.nivelAcesso == NivelAcesso.TechL)
                    {
                        MenuTechLeader.Menu(user);
                    }
                }
                else
                {
                    Console.WriteLine("Usuario ou senha invalidos");
                }
                Console.WriteLine("Deseja usar o programa novamente? (s/n)");
                string resposta = Console.ReadLine();
                if (resposta == "n")
                {
                    Console.WriteLine("Muito obrigado e volte sempre!");                   
                    g1.SalvarTudo();
                    break;
                }
            } while (true);
        }
    }
}
