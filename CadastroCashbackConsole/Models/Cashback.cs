using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroCashbackConsole.Models;

public class Cashback
{
  [Key]
  public int Id { get; set; }
  public int TransacaoId { get; set; }
  public int ValorCashback { get; set; }
  public DateTime DataCredito { get; set; }

  [ForeignKey("TransacaoId")]
  public Transacao? Transacao { get; set; }
}
