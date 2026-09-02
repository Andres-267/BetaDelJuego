using UnityEngine;

public class Moneda : ObjetoMundo
{
    private int puntos = 5;

    public override void AlContacto(Jugador jugador)
    {
        jugador.AgregarPuntos(puntos);
        Debug.Log("Moneda recogida puntos: " + jugador.ObtenerPuntaje());
        Destroy(gameObject);
    }
}
