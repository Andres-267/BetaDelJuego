
using UnityEngine;

public class Victoria : MonoBehaviour
{
    [Header("Mensaje de victoria")]
    [SerializeField] private GameObject mensajeVictoria;

    private bool victoriaActivada = false;

    private void Start()
    {
        if (mensajeVictoria != null)
        {
            mensajeVictoria.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (victoriaActivada) return;

        if (other.CompareTag("Player"))
        {
            victoriaActivada = true;

            if (mensajeVictoria != null)
            {
                mensajeVictoria.SetActive(true);
            }

            Debug.Log("¡VICTORIA!");
            Time.timeScale = 0f;
        }
    }
}
