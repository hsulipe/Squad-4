using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashback.Models;

public class Transacao
{
  [Key]
  public int Id { get; set; }
  public int UsuarioId { get; set; }
  public int Valor { get; set; }
  public DateTime DataTransacao { get; set; }
  public string? Status { get; set; }
  
  [ForeignKey("TransacaoId")]
  public Usuario? Usuario { get; set; }

  public ICollection<Cashback>? Cashbacks { get; set; }
}
