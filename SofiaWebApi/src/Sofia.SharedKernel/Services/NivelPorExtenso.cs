using Sofia.SharedKernel.Globalization;
using Sofia.SharedKernel.ValueObjects;
using System;

namespace Sofia.SharedKernel.Services
{
    public static class NivelPorExtenso
    {
        public static string ConverterParaTerceiraPessoa(byte nivel)
        {
            switch (nivel)
            {
                case 1:
                    return Messages.NivelTesteiTerceiraPessoa;
                case 2:
                    return Messages.NivelConhecoTerceiraPessoa;
                case 3:
                    return Messages.NivelDominoTerceiraPessoa;
                case 4:
                    return Messages.NivelMitoTerceiraPessoa;
                default:
                    throw new InvalidCastException(nameof(nivel));
            }
        }

        public static string Converter(byte nivel)
        {
            switch (nivel)
            {
                case 1:
                    return Messages.NivelTestei;
                case 2:
                    return Messages.NivelConheco;
                case 3:
                    return Messages.NivelDomino;
                case 4:
                    return Messages.NivelMito;
                default:
                    throw new InvalidCastException(nameof(nivel));
            }
        }

        public static string Converter(Nivel nivel)
        {
            return Converter((byte)nivel);
        }
    }
}
