using UnityEngine;
using TMPro;
using System;

public class Carta : MonoBehaviour
{
    public TextMeshProUGUI Nome;
    public TextMeshProUGUI Descrizione;
    public TextMeshProUGUI PuntiVita;
    public TextMeshProUGUI PuntiAttacco;

    public GameObject targetIndicator;
    public int Attacco => Convert.ToInt32(PuntiAttacco.text);
    public int Vita
    {
        get => Convert.ToInt32(PuntiVita.text);
        set => PuntiVita.text = value.ToString();
    }

    public void OnAttackButtonPressed()
    {
        GameController.Instance.StartAttack(this); // Avvia l'attacco tramite il GameController
    }
}