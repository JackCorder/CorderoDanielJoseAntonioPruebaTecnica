using CorderoDanielJoseAntonioPruebaTecnica.Helpers;
using Xunit;

namespace CorderoDanielJoseAntonioPruebaTecnica.Tests.Helpers
{
    public class DescuentoHelperTests
    {
        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(200, 50, 100)]
        [InlineData(150, 0, 150)]
        [InlineData(150, 100, 0)]
        public void AplicarDescuento_ValidInputs_ReturnsCorrectResult(decimal precioOriginal, decimal porcentaje, decimal esperado)
        {
            var resultado = DescuentoHelper.AplicarDescuento(precioOriginal, porcentaje);
            Assert.Equal(esperado, resultado);
        }

        [Theory]
        [InlineData(-5)]
        [InlineData(101)]
        public void AplicarDescuento_InvalidPercentage_ThrowsArgumentException(decimal porcentaje)
        {
            Assert.Throws<ArgumentException>(() => DescuentoHelper.AplicarDescuento(100, porcentaje));
        }
    }
}
