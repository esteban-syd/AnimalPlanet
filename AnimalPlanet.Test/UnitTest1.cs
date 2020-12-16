using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Animal.Negocios;

namespace AnimalPlanet.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLeer()
        {
            string esperado = "176608868";
            string resultado = "";
            Cliente cli = new Cliente()
            {
                Nombre = "esteban varas"
            };
            cli.Read();
            resultado = cli.Nombre;
            Assert.AreEqual(esperado, resultado);

        }

        public void TestLeer1()
        {
            string esperado = "QUILTRO";
            string resultado = "";
            Mascota mas = new Mascota()
            {
                Nombre = "FOCA"
            };
            mas.Read();
            resultado = mas.Nombre;
            Assert.AreEqual(esperado, resultado);

        }
    }
}
