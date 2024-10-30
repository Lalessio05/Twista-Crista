using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController Instance; // Singleton

    private Carta attackingCard; // Riferimento alla carta che sta attaccando
    private bool isSelectingTarget = false; // Flag per attivare la selezione del bersaglio

    private void Awake()
    {
        // Inizializza il singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void StartAttack(Carta attacker)
    {
        attackingCard = attacker; // Memorizza la carta che attacca
        isSelectingTarget = true; // Attiva la selezione del bersaglio
        Debug.Log("Modalità attacco attivata! Seleziona una carta da attaccare.");
    }

    private void Update()
    {
        // Controlla se è attiva la selezione del bersaglio
        if (isSelectingTarget && Input.GetMouseButtonDown(0))
        {
            // Lista per i risultati del raycast
            List<RaycastResult> results = new List<RaycastResult>();

            // Esegue un raycast dal punto del mouse sull'interfaccia UI
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            EventSystem.current.RaycastAll(eventData, results);

            // Controlla i risultati del raycast
            foreach (RaycastResult result in results)
            {
                Carta targetCard = result.gameObject.GetComponent<Carta>();

                // Controlla se il bersaglio è una carta e non la stessa carta che attacca
                if (targetCard != null && targetCard != attackingCard)
                {
                    Debug.Log($"Carta bersaglio selezionata: {targetCard.Nome.text}");
                    ExecuteAttack(targetCard);
                    isSelectingTarget = false; // Disattiva la selezione
                    break;
                }
            }
        }
    }


    private void ExecuteAttack(Carta targetCard)
    {
        // Calcola i nuovi punti vita del bersaglio
        targetCard.Vita -= attackingCard.Attacco;
        Debug.Log($"{attackingCard.Nome.text} ha attaccato {targetCard.Nome.text}!");

        // Controlla se il bersaglio è stato sconfitto
        if (targetCard.Vita <= 0)
        {
            Debug.Log($"{targetCard.Nome.text} è stato sconfitto!");
            Destroy(targetCard.gameObject); // Distruggi l'oggetto bersaglio se sconfitto
        }
    }
}
