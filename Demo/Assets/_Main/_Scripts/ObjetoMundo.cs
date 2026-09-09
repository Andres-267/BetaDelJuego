using UnityEngine;

public abstract class ObjetoMundo : MonoBehaviour
{
    public string nombreObjeto;
    public abstract void Alcontacto(Jugador jugador);

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Jugador jugador = other.GetComponent<Jugador>();
        if(jugador != null)
        {
            Alcontacto(jugador);
        }
    }
}