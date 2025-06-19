using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Core.Data;
using TaskFlow.Core.Models;

namespace TaskFlow.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly AppDbContext _context;

    public TasksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
    {
        var tarefas = await _context.Tarefas
            .OrderBy(t => t.Concluida)
            .ThenBy(t => t.DataCriacao)
            .ToListAsync();

        return Ok(tarefas);
    }

    [HttpPost]
    public async Task<ActionResult<TaskItem>> Create(TaskItem tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetAll), new { id = tarefa.Id }, tarefa);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarTarefa(int id, [FromBody] TaskItem tarefaAtualizada)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Descricao = tarefaAtualizada.Descricao;

        await _context.SaveChangesAsync();

        return Ok(tarefa);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        _context.Tarefas.Remove(tarefa);
        await _context.SaveChangesAsync();

        return NoContent(); // Retorna 204
    }
    [HttpPatch("{id}/complete")]
    public async Task<IActionResult> ConcluirTarefa(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);

        if (tarefa == null)
        {
            return NotFound("Tarefa não encontrada.");
        }

        if (tarefa.Concluida)
        {
            return BadRequest("Tarefa já está concluída.");
        }

        tarefa.Concluida = true;
        tarefa.DataConclusao = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok($"Tarefa '{tarefa.Titulo}' marcada como concluída.");
    }



}
