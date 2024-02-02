namespace ws;

public static class ArrayListData
{
    public static List<string> deltagerListe = new List<string>();

    public static void tilføjDeltagere()
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

    public static void tilFøjDeltager(string navn)
    {
        deltagerListe.Add(navn);
    }

    public static void fjernDeltager(string navn)
    {
        deltagerListe.Remove(navn);
    }

    public static List<string> sendList()
    {
        return deltagerListe;
    }
    
}