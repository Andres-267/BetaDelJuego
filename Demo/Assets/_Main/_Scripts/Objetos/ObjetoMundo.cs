using UnityEngine;

public abstract class ObjetoMundo : MonoBehaviour
{
    public string nombreObjeto;     
    public abstract void Alcontacto(Jugador jugador);  /// Single responsability: la clase tiene el proposiro unico de detectar ek trigger
                                                       /// Liskov: al ser abstracta no hay implementacion de la base
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