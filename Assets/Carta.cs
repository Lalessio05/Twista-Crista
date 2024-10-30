public class Carta
{
    public string nome;
    public string descrizione;
    public int puntiVita;
    public int puntiAttacco;

    public void InfliggiDanno(int danno)
    {
        puntiVita -= danno;
        if (puntiVita < 0) puntiVita = 0;
    }
}
