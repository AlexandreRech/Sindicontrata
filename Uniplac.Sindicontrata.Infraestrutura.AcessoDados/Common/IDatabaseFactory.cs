using System;
using Uniplac.Sindicontrata.Infraestrutura.AcessoDadosContexts;

namespace Uniplac.Sindicontrata.Infraestrutura.AcessoDadosCommon
{
    public interface IDatabaseFactory : IDisposable
    {
        SindicontrataContext Get();
    }
}
