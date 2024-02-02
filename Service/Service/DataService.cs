namespace Service1.Service;

public class DataService
{
    public static List<string> deltagerListe = new List<string>();
 
    
    public  void tilføjDeltagere()
    {
        deltagerListe.Add("Magnus");
        deltagerListe.Add("Tomas");
        deltagerListe.Add("Kasper");
        deltagerListe.Add("Betina");
        deltagerListe.Add("Laila");
        deltagerListe.Add("Sanne");
        deltagerListe.Add("Tykke Rikke");
        deltagerListe.Add("Frederik");
    }

    public  void tilFøjDeltager(string navn)
    {
        deltagerListe.Add(navn);
    }

    public  void fjernDeltager(string navn)
    {
        deltagerListe.Remove(navn);
    }

    public List<string> sendList()
    {
        return deltagerListe;
    }
    
    
    public  void opdaterDeltager(string tidligereNavn, string nytNavn )
    {
        int index = deltagerListe.IndexOf(tidligereNavn);

        if (index != -1)
        deltagerListe[index] = nytNavn;
    }
    
    public  void sorteretListe(List<string> opdateretListe )
    {
        deltagerListe = opdateretListe;
    }
    
    
    
}