// See https://aka.ms/new-console-template for more information
using RepositoryEF.RepositoriEf;
using Rubrica_ConsoleApp;
using Rubrica_Core.BusinessLayer;
using Rubrica_Core.Models;
using Rubrica_RepositoryMock.RepositoryMock;

Console.WriteLine("Hello, World!");
//IBusinessLayer bl = new MainBusinessLayer(new RepositoryContatto(), new RepositoryIndirizzo());
//se invece utilizzo le EF
IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattoEF(),new RepositoryIndirizzoEF());
bool continua = true;
while (continua)
{
    int scelta = Menu();
    continua = AnalizzaScelta(scelta);

}

int Menu()
{
    Console.WriteLine("**********************");
    Console.WriteLine("Menù");
    Console.WriteLine("\n Funzionalità contatti");
    Console.WriteLine("\n[1] visualizza contatti" +
        "\n[2] inserire nuovo contatto" +
        "\n[3] eliminare contatto");

    Console.WriteLine("\n Funzionalità Indirizzi");
    Console.WriteLine("\n[4] visualizza elenco completo Indirizzi" +
        "\n[5] inserire nuovo indirizzo");

    Console.WriteLine("\n [0] esci");
    Console.WriteLine("**********************");

    int scelta;
    Console.WriteLine("inserisci la tua scelta");
    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 5))
    {
        Console.WriteLine("scelta errata!! Inserisci un numero compreso tra 0 e 5 ");
    }
    return scelta;


}

bool AnalizzaScelta(int scelta)
{
    switch (scelta)
    {
        case 1:
            VisualizzaContatti();
            break;
        case 2:
            InserisciNuovoContatto();
            break;
        case 3:
            EliminaContatto();
            break;
        case 4:
            VisualizzaIndirizzi();
            break;
        case 5:
            InserisciNuovoIndirizzo();
            break;
        case 0:
            return false;
            //default:
            //    Console.WriteLine("scelta non valida");
            //    break;
    }
    return true;
}

void InserisciNuovoIndirizzo()
{
    string tipologia;
    do
    {
        Console.WriteLine("inserisci tipologia: Residenza o Domicilio");
        tipologia = Console.ReadLine();
    } while (!(tipologia == "Residenza" || tipologia == "Domicilio"));


    string via = Helper.CheckStringa("via");
    string citta = Helper.CheckStringa("città");
    string cap = Helper.CheckStringa("CAP");
    string provincia = Helper.CheckStringa("provincia");
    string nazione = Helper.CheckStringa("nazione");
    VisualizzaContatti();
    Console.WriteLine("a quale contatto vuoi associare l'indirizzo? inserisci id");
    int idCont = Helper.CheckIntero(" contatto id");
    Indirizzo indirizzoNuovo = new Indirizzo();
    indirizzoNuovo.Tipologia = tipologia;
    indirizzoNuovo.Via = via;
    indirizzoNuovo.Città = citta;
    indirizzoNuovo.Cap = cap;
    indirizzoNuovo.Provincia = provincia;
    indirizzoNuovo.Nazione = nazione;
    indirizzoNuovo.ContattoId = idCont;

    Esito esito = bl.AddNuovoIndirizzo(indirizzoNuovo);
    Console.WriteLine(esito.Messaggio);

}

void VisualizzaIndirizzi()
{
    List<Indirizzo> listaIndirizzi = bl.GetAllIndirizzi();
    if (listaIndirizzi.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var i in listaIndirizzi)
        {
            Console.WriteLine(i);
        }
    }
}

void EliminaContatto()
{
    VisualizzaContatti();
    Console.WriteLine("inserisci id del contatto da eliminare");
    int id = int.Parse(Console.ReadLine());
    

    
    Esito esito = bl.DeleteContatto(id);
    Console.WriteLine(esito.Messaggio);
}

void InserisciNuovoContatto()
{
    string nome = Helper.CheckStringa("nome");
    string cognome = Helper.CheckStringa("cognome");

    Contatto nuovoContatto = new Contatto();
    nuovoContatto.Nome = nome;
    nuovoContatto.Cognome = cognome;

    Esito esito = bl.AddNuovoContatto(nuovoContatto);
    Console.WriteLine(esito.Messaggio);
}

void VisualizzaContatti()
{
    //recupera lista dei contatti
    List<Contatto> listaContatti = bl.GetAllContatti();

    //stampa la lista
    if (listaContatti.Count == 0)
    {
        Console.WriteLine("lista vuota");
    }
    else
    {
        foreach (var item in listaContatti)
        {
            Console.WriteLine(item);
        }
    }
}