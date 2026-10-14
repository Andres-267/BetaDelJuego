
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Jugador jugador = collision.gameObject.GetComponent<Jugador>();

        if (jugador != null)
        {
            jugador.Morir();
        }
    }
}
