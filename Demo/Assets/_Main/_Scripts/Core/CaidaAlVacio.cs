
using UnityEngine;

public class CaidaAlVacio : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float alturaLimite = -20f;

    private Rigidbody rb;
    private Vector3 posicionInicial;
    private bool reapareciendo = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    private void Update()
    {
        if (transform.position.y < alturaLimite && !reapareciendo)
        {
            Reaparecer();
        }
    }

    private void Reaparecer()
    {
        reapareciendo = true;

        Vector3 destino = Checkpoint.existeCheckpoint
            ? Checkpoint.ultimaPosicion
            : posicionInicial;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.position = destino;
        }
        else
        {
            transform.position = destino;
        }

        Caja.RestaurarTodasLasCajas();

        reapareciendo = false;
    }
}
