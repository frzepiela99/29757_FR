using static AlaMaKota;

namespace TestProject1
{
    public class UnitTest1
    {
        //Sprawdzenie podzielnoœci przez 2
        [Fact]
        public void GetOutput_WhenInputIsDivisibleOnlyBy2_ShouldReturnAla()
        {
            var alamakota2 = new AlaMaKota();

            var result = alamakota2.GetOutput(2);

            Assert.Contains(result, "Ala");
        }

        [Fact]
        public void GetOutput_WhenInputIsDivisibleOnlyBy6_ShouldReturnMaKota()
        {
            var alamakota6 = new AlaMaKota();

            var result = alamakota6.GetOutput(6);

            Assert.Contains(result, "AlaMaKota");
        }

        [Fact]
        public void GetOutput_WhenInputIsDivisibleBy2And6_ShouldReturnAlaMaKota()
        {
            var alamakota12 = new AlaMaKota();

            var result = alamakota12.GetOutput(12);

            Assert.Contains(result, "AlaMaKota");
        }

        //Test sprawdzaj¹cy niepoprawnoœæ adresu mail
        [Fact]
        public void IwalidateNiepoprawny()
        {
            var walidacjaMaila = new WalidacjaMaila();

            bool result = walidacjaMaila.IsValidate("filip");

            Assert.False(result);
        }

        [Fact]
        public void IwalidatePoprawny()
        {
            var walidacjaMailaPopr = new WalidacjaMaila();

            bool result = walidacjaMailaPopr.IsValidate("filip@interia.pl");

            Assert.True(result);
        }
    }
}
