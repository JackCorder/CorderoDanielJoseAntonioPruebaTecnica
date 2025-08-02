namespace CorderoDanielJoseAntonioPruebaTecnica.Helpers
{
    public static class DescuentoHelper
    {
        public static decimal AplicarDescuento(decimal precioOriginal, decimal porcentaje)
        {
            if (porcentaje < 0 || porcentaje > 100)
                throw new ArgumentException("Porcentaje inválido");
            return precioOriginal - (precioOriginal * (porcentaje / 100));
        }
    }
}
