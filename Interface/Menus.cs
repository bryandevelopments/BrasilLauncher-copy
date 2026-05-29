using System.Collections.ObjectModel;
using Spectre.Console;

class Menus
{
  public static string Perguntar(string texto)
  {
    return AnsiConsole.Ask<string>(texto);
    
  }

  public static bool Confirmar(string texto)
  {
    return AnsiConsole.Confirm(texto);
    
  }

  public static async Task<string> Escolher(ReadOnlyCollection<string> versoes, string titulo)
  {
    var table = new Table();

    var selecao = new SelectionPrompt<string>().Title(titulo);

    foreach (var versao in versoes)
    {
      
        selecao.AddChoice(versao);
    }

    return AnsiConsole.Prompt(selecao);
  }

}