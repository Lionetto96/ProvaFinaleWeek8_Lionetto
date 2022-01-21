using RepositoryEF.RepositoriEf;
using Rubrica_Core.BusinessLayer;
using Rubrica_Core.Models;
using Rubrica_RepositoryMock.RepositoryMock;
using Xunit;

namespace Rubrica_Test
{
    public class UnitTest1
    {
        //IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattoEF(), new RepositoryIndirizzoEF());
        IBusinessLayer bl = new MainBusinessLayer(new RepositoryContatto(), new RepositoryIndirizzo());
        [Fact]
        public void AddContatto1()
        {
            var lunghezza = bl.GetAllContatti().Count;
            string nome = "paola";
            string cognome = "rossi";

            Contatto c = new Contatto()
            {
                Nome = nome,
                Cognome = cognome
            };
            bl.AddNuovoContatto(c);
            var lunghezza2=bl.GetAllContatti().Count;
            Assert.True(lunghezza+1==lunghezza2);
        }
    }
}