using Ada.GerenciadorTarefas.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Ada.GerenciadorTarefas.JsonParser
{
    internal class Autenticacao
    {
        public static bool AutenticarUsuario(int id, string senha)
        {
            Funcionario funcionario = BuscarFuncionarioPorId(id);

            if (funcionario == null || !ValidaSenha(senha))
            {
                Console.WriteLine("Usuário ou senha inválidos!");
                return false;
            }

            byte[] hashSenhaFornecida = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(senha));
            byte[] hashSenhaArmazenada = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(funcionario.senha));


            return hashSenhaFornecida.SequenceEqual(hashSenhaArmazenada);

        }
        public static Funcionario BuscarFuncionarioPorId(int id)
        {
            var funcionarios = File.ReadAllText($@"C:\Users\igord\Downloads\Ada.GerenciadorTarefas\Ada.GerenciadorTarefas\JsonParser\Funcionarios.json");
            var json = JsonConvert.DeserializeObject<List<Funcionario>>(funcionarios);
            var funcionario = json?.FirstOrDefault(f => f.id == id);
            if (funcionario == null)
            {
                throw new ArgumentException("Funcionário não encontrado");
            }
            return funcionario;
        }


        public static bool ValidaSenha(string senha)
        {
            if (senha.Length < 8)
            {
                return false;
            }

            int contadorLetraMaius = 0;
            int contadorLetraMinus = 0;
            int contadorNum = 0;

            for (int i = 0; i < senha.Length; i++)
            {
                char caractere = senha[i];

                if (char.IsUpper(caractere))
                {
                    contadorLetraMaius++;
                }
                else if (char.IsLower(caractere))
                {
                    contadorLetraMinus++;
                }
                else if (char.IsDigit(caractere))
                {
                    contadorNum++;
                }
            }
            return contadorLetraMaius >= 1 && contadorLetraMinus >= 1 && contadorNum >= 1;
        }
    }
}
