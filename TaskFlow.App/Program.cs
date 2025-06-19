using TaskFlow.App.Services;
using TaskFlow.App.Models;

var taskService = new TaskService();

while (true)
{
    Console.WriteLine("\n📋 TaskFlow - Gerenciador de Tarefas");
    Console.WriteLine("1. Adicionar nova tarefa");
    Console.WriteLine("2. Listar tarefas");
    Console.WriteLine("3. Concluir tarefa");
    Console.WriteLine("4. Remover tarefa");
    Console.WriteLine("5. Editar tarefa");
    Console.WriteLine("6. Ver relatório de produtividade");


    Console.WriteLine("0. Sair");
    Console.Write("Escolha uma opção: ");

    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Título: ");
            var titulo = Console.ReadLine() ?? "";
            Console.Write("Descrição: ");
            var descricao = Console.ReadLine() ?? "";
            taskService.AdicionarTarefa(titulo, descricao);
            break;

        case "2":
            var tarefas = taskService.ListarTarefas();
            Console.WriteLine("\n🔽 Tarefas:");
            foreach (var t in tarefas)
            {
                var status = t.Concluida ? "[✔]" : "[ ]";
                Console.WriteLine($"{status} {t.Id} - {t.Titulo} ({t.DataCriacao:dd/MM/yyyy})");
            }
            break;
        case "3":
            Console.Write("Informe o ID da tarefa a concluir: ");
            if (int.TryParse(Console.ReadLine(), out var id))
            {
                taskService.ConcluirTarefa(id);
            }
            else
            {
                Console.WriteLine("❌ ID inválido.");
            }
            break;
        case "4":
            Console.Write("Informe o ID da tarefa a remover: ");
            if (int.TryParse(Console.ReadLine(), out int idRemover))
            {
                taskService.RemoverTarefa(idRemover);
            }
            else
            {
                Console.WriteLine("❌ ID inválido.");
            }
            break;
        case "5":
            Console.Write("Informe o ID da tarefa a editar: ");
            if (int.TryParse(Console.ReadLine(), out int idEditar))
            {
                taskService.EditarTarefa(idEditar);
            }
            else
            {
                Console.WriteLine("❌ ID inválido.");
            }
            break;
        case "6":
            taskService.ExibirRelatorio();
            break;



        case "0":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("❌ Opção inválida.");
            break;
    }
}
