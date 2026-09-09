using UnityEngine;

public class Caja : ObjetoMundo
{   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.8f);
        }
    }

    public override void Alcontacto(Jugador jugador)
    {
        jugador.AgregarPuntos(10);
        Debug.Log("Caja recogida puntos: " + jugador.ObtenerPuntaje());
        Destroy(gameObject);
    }
}