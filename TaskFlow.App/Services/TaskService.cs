using TaskFlow.App.Data;
using TaskFlow.App.Models;

namespace TaskFlow.App.Services;

public class TaskService
{
    private readonly AppDbContext _context;
    public TaskService()
    {
        _context = new AppDbContext();
    }
    public void AdicionarTarefa(string titulo, string Descricao)
    {
        var tarefa = new TaskItem
        {
            Titulo = titulo,
            Descricao = Descricao
        };
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
        System.Console.WriteLine($"Tarefa {tarefa.Titulo} criada com sucesso!");
    }
    public List<TaskItem> ListarTarefas()
    {
        return _context.Tarefas
        .OrderBy(t => t.Concluida)
        .ThenBy(t => t.DataCriacao)
        .ToList();
    }
    public void ConcluirTarefa(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

        if (tarefa == null)
        {
            Console.WriteLine("❌ Tarefa não encontrada.");
            return;
        }

        if (tarefa.Concluida)
        {
            Console.WriteLine("⚠️ Tarefa já está concluída.");
            return;
        }

        tarefa.Concluida = true;
        tarefa.DataConclusao = DateTime.Now;

        _context.SaveChanges();
        Console.WriteLine($"✅ Tarefa '{tarefa.Titulo}' marcada como concluída.");
    }
    public void RemoverTarefa(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
        {
            Console.WriteLine("❌ Tarefa nao encontrada.");
            return;
        }
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
        Console.WriteLine($"🗑️ Tarefa '{tarefa.Titulo}' removida.");
    }
    public void EditarTarefa(int id)
    {
        var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
        if (tarefa == null)
        {
            Console.WriteLine("❌ Tarefa nao encontrada.");
            return;
        }
        Console.WriteLine($"✏️ Editando tarefa: {tarefa.Titulo}");

        Console.Write("Novo título (pressione Enter para manter o atual): ");
        var novoTitulo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoTitulo))
        {
            tarefa.Titulo = novoTitulo;
        }

        Console.Write("Nova descrição (pressione Enter para manter a atual): ");
        var novaDescricao = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novaDescricao))
        {
            tarefa.Descricao = novaDescricao;
        }

        _context.SaveChanges();
        Console.WriteLine("✅ Tarefa atualizada com sucesso.");
    }
    public void ExibirRelatorio()
    {
        var total = _context.Tarefas.Count();
        var concluidas = _context.Tarefas.Count(t => t.Concluida);
        var pendentes = total - concluidas;

        Console.WriteLine("\n📊 Relatório de Produtividade");
        Console.WriteLine($"Total de tarefas:     {total}");
        Console.WriteLine($"Tarefas concluídas:   {concluidas}");
        Console.WriteLine($"Tarefas pendentes:    {pendentes}");

        if (total > 0)
        {
            var percentual = (concluidas * 100.0) / total;
            Console.WriteLine($"Progresso geral:      {percentual:F1}%\n");
        }
    }

}
