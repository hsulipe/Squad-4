using System;
using System.Collections.Generic;
using CadastroCashbackConsole.Data;
using CadastroCashbackConsole.Models;

class Program
{   
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1. Gerenciar Usuarios");
            Console.WriteLine("2. Gerenciar Transacoes");
            Console.WriteLine("3. Gerenciar Cashback");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    GerenciarUsuarios();
                    break;
                case "2":
                    GerenciarTransacoes();
                    break;
                case "3":
                    GerenciarCashbacks();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    // CRUD para Usuarios
    static void GerenciarUsuarios()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nMenu Usuario:");
            Console.WriteLine("1. Criar Usuario");
            Console.WriteLine("2. Listar Usuarios");
            Console.WriteLine("3. Atualizar Usuario");
            Console.WriteLine("4. Deletar Usuario");
            Console.WriteLine("5. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine()  ?? "";

            switch (opcao)
            {
                case "1":
                    CriarUsuario();
                    break;
                case "2":
                    ListarUsuarios();
                    break;
                case "3":
                    AtualizarUsuario();
                    break;
                case "4":
                    DeletarUsuario();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void CriarUsuario()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o nome do usuario: ");
            string nome = Console.ReadLine() ?? "";

            Console.Write("Digite o email do usuario: ");
            string email = Console.ReadLine() ?? "";

            Usuario novoUsuario = new Usuario
            {
                Nome = nome,
                Email = email
            };

            db.Usuarios.Add(novoUsuario);
            db.SaveChanges();  // Salva as alterações no banco de dados
            Console.WriteLine("Usuario criado com sucesso!");
        }
    }

    static void ListarUsuarios()
    {
        using (var db = new CampanhaDbContext())
        {
            var usuarios = db.Usuarios.ToList();

            Console.WriteLine("\nLista de Usuarios:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"Id: {usuario.Id}, Nome: {usuario.Nome}, Email: {usuario.Email}");
            }
        }
    }

    static void AtualizarUsuario()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o Id do usuario que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                Console.Write("Digite o novo nome do usuario: ");
                usuario.Nome = Console.ReadLine();

                Console.Write("Digite o novo email do usuario: ");
                usuario.Email = Console.ReadLine();

                db.SaveChanges();  // Salva as alterações no banco de dados
                Console.WriteLine("Usuario atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
    }

    static void DeletarUsuario()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o Id do usuario que deseja deletar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            var usuario = db.Usuarios.Find(id);
            if (usuario != null)
            {
                db.Usuarios.Remove(usuario);
                db.SaveChanges();  // Remove o usuario e salva no banco de dados
                Console.WriteLine("Usuario deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
    }
    // CRUD para Transacoes
    static void GerenciarTransacoes()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nMenu Transacao:");
            Console.WriteLine("1. Criar Transacao");
            Console.WriteLine("2. Listar Transacoes");
            Console.WriteLine("3. Atualizar Transacao");
            Console.WriteLine("4. Deletar Transacao");
            Console.WriteLine("5. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    CriarTransacao();
                    break;
                case "2":
                    ListarTransacoes();
                    break;
                case "3":
                    AtualizarTransacao();
                    break;
                case "4":
                    DeletarTransacao();
                    break;
                case "5":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    static void CriarTransacao()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o valor da transacao: ");
            int valor = int.Parse(Console.ReadLine() ?? "");

            Console.Write("Digite o Id do usuario relacionado: ");
            int usuarioId = int.Parse(Console.ReadLine() ?? "");

            // Verifica se o usuário existe
            var usuario = db.Usuarios.Find(usuarioId);
            if (usuario != null)
            {
                Transacao novaTransacao = new Transacao
                {
                    Valor = valor,
                    DataTransacao = DateTime.Now,
                    UsuarioId = usuarioId
                };

                db.Transacoes.Add(novaTransacao);
                db.SaveChanges();  // Salva a transação no banco de dados
                Console.WriteLine("Transacao criada com sucesso!");
            }
            else
            {
                Console.WriteLine("Usuario não encontrado.");
            }
        }
    }

    static void ListarTransacoes()
    {
        using (var db = new CampanhaDbContext())
        {
            var transacoes = db.Transacoes.ToList();

            Console.WriteLine("\nLista de Transacoes:");
            foreach (var transacao in transacoes)
            {
                Console.WriteLine($"Id: {transacao.Id}, Valor: {transacao.Valor}, Data: {transacao.DataTransacao}, UsuarioId: {transacao.UsuarioId}");
            }
        }
    }

    static void AtualizarTransacao()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o Id da transacao que deseja atualizar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            var transacao = db.Transacoes.Find(id);
            if (transacao != null)
            {
                Console.Write("Digite o novo valor da transacao: ");
                transacao.Valor = int.Parse(Console.ReadLine() ?? "");

                db.SaveChanges();  // Salva as alterações no banco de dados
                Console.WriteLine("Transacao atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("Transacao não encontrada.");
            }
        }
    }

    static void DeletarTransacao()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o Id da transacao que deseja deletar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            var transacao = db.Transacoes.Find(id);
            if (transacao != null)
            {
                db.Transacoes.Remove(transacao);
                db.SaveChanges();  // Remove a transação do banco de dados
                Console.WriteLine("Transacao deletada com sucesso!");
            }
            else
            {
                Console.WriteLine("Transacao não encontrada.");
            }
        }
    }

    // CRUD para Cashback
    static void GerenciarCashbacks()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\nMenu Cashback:");
            Console.WriteLine("1. Criar Cashback");
            Console.WriteLine("2. Listar Cashbacks");
            Console.WriteLine("3. Atualizar Cashback");
            Console.WriteLine("4. Deletar Cashback");
            Console.WriteLine("5. Voltar ao Menu Principal");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    CriarCashback();
                    break;
                case "2":
                    ListarCashbacks();
                    break;
                case "3":
                    DeletarCashback();
                    break;
                case "4":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }
    
    static void CriarCashback()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o percentual do cashback: ");
            int ValorCashback = int.Parse(Console.ReadLine() ?? "");

            Console.Write("Digite o Id da transacao relacionada: ");
            int transacaoId = int.Parse(Console.ReadLine() ?? "");

            // Verifica se a transação existe
            var transacao = db.Transacoes.Find(transacaoId);
            if (transacao != null)
            {
                Cashback novoCashback = new Cashback
                {
                    ValorCashback = ValorCashback,
                    TransacaoId = transacaoId
                };

                db.Cashbacks.Add(novoCashback);
                db.SaveChanges();  // Salva o cashback no banco de dados
                Console.WriteLine("Cashback criado com sucesso!");
            }
            else
            {
                Console.WriteLine("Transacao não encontrada.");
            }
        }
    }

    static void ListarCashbacks()
    {
        using (var db = new CampanhaDbContext())
        {
            var cashbacks = db.Cashbacks.ToList();

            Console.WriteLine("\nLista de Cashbacks:");
            foreach (var cashback in cashbacks)
            {
                Console.WriteLine($"Id: {cashback.Id}, Valor Cashback: {cashback.ValorCashback}%, TransacaoId: {cashback.TransacaoId}");
            }
        }
    }

    static void DeletarCashback()
    {
        using (var db = new CampanhaDbContext())
        {
            Console.Write("Digite o Id do cashback que deseja deletar: ");
            int id = int.Parse(Console.ReadLine() ?? "");

            var cashback = db.Cashbacks.Find(id);
            if (cashback != null)
            {
                db.Cashbacks.Remove(cashback);
                db.SaveChanges();  // Remove o cashback do banco de dados
                Console.WriteLine("Cashback deletado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cashback não encontrado.");
            }
        }
    }
}
