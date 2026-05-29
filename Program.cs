using System.Diagnostics.Eventing.Reader;
using CmlLib.Core.Auth;
using Spectre.Console;
class Program
{
  public static async Task Main()
  {
    var minecraft = new Minecraft();
    var minecraftAuth = new MinecraftAuth();
    MSession sessao;

    AnsiConsole.MarkupLine("[white]Bem vindo ao [/][green]Brasil Launcher![/]");

    var fazerLogin = Menus.Confirmar("[white bold]Deseja Logar na[/] [green]Microft?[/]");

    if (fazerLogin)
    {
      sessao = await minecraftAuth.FazerLogin();
    } else
    {
      var nome = Menus.Perguntar("What is your [green]username[/]: ");
      sessao = MSession.CreateOfflineSession(nome);
    }
    AnsiConsole.MarkupLine($"[white bold]Você está logado como[/] [green]{sessao.Username}[/]");
    var versao = await minecraft.PerguntarVersao();
    var baixar = Menus.Confirmar("Do you want to confirm [green]download[/]?");

    await minecraft.AbrirMinecraft(sessao, versao, baixar);
  }
}