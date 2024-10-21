using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroCashbackConsole.Models;

public class Usuario
{
  [Key]
  public int Id { get; set; }
  public string? Nome { get; set; }
  public string? Email { get; set; }
  public DateTime DataCadastro { get; set; }

  public ICollection<Transacao>? Transacoes { get; set; }
}
