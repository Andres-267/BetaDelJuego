using UnityEngine;

public class ObjetoMundo : MonoBehaviour
{
    public string nombreObjeto;

    // M�todo virtual que cada hijo implementa a su manera
    public virtual void AlContacto(Jugador jugador)
    {
        Debug.Log(jugador.nombre + " toco " + nombreObjeto);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Jugador jugador = other.GetComponent<Jugador>();
        if(jugador != null)
        {
            AlContacto(jugador);
        }
    }
}