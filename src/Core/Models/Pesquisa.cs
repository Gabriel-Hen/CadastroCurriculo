namespace Core;

public class Pesquisa
{
    public string Termo { get; set; }
    public int Pagina { get; set; }
    public int Limite { get; set; } = 10;
    public string Ordenacao { get; set; }
    public string OrdenarPor { get; set; }
    public int Offset { get; set; }
}