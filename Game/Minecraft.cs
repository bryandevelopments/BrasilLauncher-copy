using System.Diagnostics;
using CmlLib.Core;
using CmlLib.Core.Auth;
using CmlLib.Core.ProcessBuilder;
using Spectre.Console;

internal class Minecraft
{
  
  private readonly MinecraftLauncher launcher = new();
  public async Task AbrirMinecraft(
    MSession session,
    string versao,
    bool baixar = true
    )
  {
    Process? game;
     MLaunchOption options = new()
    {
      Session = session,
      MaximumRamMb = 4096
      // IsDemo = true
    };

    if (baixar)
    {
      AnsiConsole.MarkupLine($"[yellow]Downloading minecraft:[/] [white]{versao}[/]");
      game = await launcher.InstallAndBuildProcessAsync(versao, options);
    } else
    {
      AnsiConsole.MarkupLine($"[yellow]Building Process of the versao:[/] [white]{versao}[/]");
      game = await launcher.BuildProcessAsync(versao, options);
    }
    
    AnsiConsole.Status().Start("$Init minecraft {versao}", ctx =>
    {
      Thread.Sleep(2000);
      game.Start();
    });
  }

  public async Task<string> PerguntarVersao()
  {
    var versoes = await launcher.GetAllVersionsAsync();
    var selecao = new SelectionPrompt<string>().Title("[white bold]Selecione a versão[/]: ");

    foreach (var versao in versoes)
    {
      selecao.AddChoice(versao.Name);
    }

    return AnsiConsole.Prompt(selecao);
  }
  
}