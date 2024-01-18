using Ada.GerenciadorTarefas.Funcionarios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Ada.GerenciadorTarefas.JsonParser
{
    public abstract class JsonParse
    {

        public static List<Funcionario> ReceberJsonFuncionarios()
        {
             // Recebe o nome da classe

            // Recebe os paths
            string absolutePath = $@"C:\Users\igord\Downloads\Ada.GerenciadorTarefas\Ada.GerenciadorTarefas\JsonParser\Funcionarios.json";
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.GetRelativePath(baseDirectory, absolutePath);

            try
            {
                string jsonString = File.ReadAllText(absolutePath);
                List<Funcionario> itemList = JsonSerializer.Deserialize<List<Funcionario>>(jsonString);
                return itemList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
        public static List<Tarefa> ReceberJsonTarefa()
        {
             // Recebe o nome da classe

            // Recebe os paths
            string absolutePath = $@"C:\Users\igord\Downloads\Ada.GerenciadorTarefas\Ada.GerenciadorTarefas\JsonParser\Tarefas.json";          
            
                
            string jsonString = File.ReadAllText(absolutePath);
            if (!string.IsNullOrEmpty(jsonString))
            {
                List<Tarefa> itemList = JsonSerializer.Deserialize<List<Tarefa>>(jsonString);
                return itemList;
            }
            else
            {
                Console.WriteLine("O conteúdo do arquivo JSON é nulo ou vazio.");
                return null;
            }
        }
        public static void SalvarTarefas(List<Tarefa> list)
        {
            string absolutePath = $@"C:\Users\igord\Downloads\Ada.GerenciadorTarefas\Ada.GerenciadorTarefas\JsonParser\Tarefas.json";
            try
            {               
                string json = System.Text.Json.JsonSerializer.Serialize(list);
                File.WriteAllText(absolutePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void SalvarFuncionarios(List<Funcionario> list)
        {
            string absolutePath = $@"C:\Users\igord\Downloads\Ada.GerenciadorTarefas\Ada.GerenciadorTarefas\JsonParser\Funcionarios.json";
            try
            {
                string json = System.Text.Json.JsonSerializer.Serialize(list);
                

                File.WriteAllText(absolutePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
