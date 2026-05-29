using CmlLib.Core.Auth;
using CmlLib.Core.Auth.Microsoft;

class MinecraftAuth
{

  private readonly JELoginHandler loginHandler = JELoginHandlerBuilder.BuildDefault();

  public async Task<MSession> FazerLogin()
  {
    return await loginHandler.Authenticate();
  }
}