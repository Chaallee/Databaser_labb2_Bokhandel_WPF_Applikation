namespace Bokhandel_WPF_Applikation.Models;

public partial class Böcker
{
    public string FörfattareFulltNamn =>
        Författare == null
            ? string.Empty
            : $"{Författare.Förnamn} {Författare.Efternamn}";
}