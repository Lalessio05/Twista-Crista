public class CartaManager : MonoBehaviour
{
    public TextMeshProUGUI nomeCartaText;
    public TextMeshProUGUI descrizioneText;
    public TextMeshProUGUI puntiVitaText;
    public TextMeshProUGUI puntiAttaccoText;
    public int PuntiVita => Convert.ToInt32(carta.puntiVita);

    private Carta carta;

    public void ImpostaCarta(Carta nuovaCarta)
    {
        carta = nuovaCarta;
        AggiornaUI();
    }

    private void AggiornaUI()
    {
        nomeCartaText.text = carta.nome;
        descrizioneText.text = carta.descrizione;
        puntiVitaText.text = "Vita: " + carta.puntiVita;
        puntiAttaccoText.text = "Attacco: " + carta.puntiAttacco;
    }

    public void Attacca(CartaManager bersaglio)
    {
        Debug.Log("Attacco con " + PuntiVita);
        bersaglio.AggiornaUI();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left) // Controlla se è stato cliccato con il tasto sinistro
        {
            // Seleziona questa carta come bersaglio
            SelezionaCarta();
        }
    }

    private void SelezionaCarta()
    {
        // Qui puoi gestire la logica di selezione della carta
        Debug.Log("Carta selezionata: " + carta.nome);
        // Puoi anche invocare un metodo nel tuo manager di gioco per tenere traccia della carta selezionata
        GameManager.Instance.SelezionaBersaglio(this);
    }
}
}
