using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TMP_Text textoMonedas;

    private int monedas = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AgregarMoneda()
    {
        monedas++;
        textoMonedas.text = "Monedas: " + monedas;
    }
}