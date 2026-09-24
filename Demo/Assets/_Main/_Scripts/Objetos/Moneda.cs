using UnityEngine;
/// Open / closed: moneda se crea como una subclase de objeto mundo
public class Moneda : ObjetoMundo
{
    private int puntos = 5;  /// Open / closed: 

    public override void Alcontacto(Jugador jugador) /// Single responsability: La clase tiene como proposito dar puntos y destruirse
    {                                                /// Liskov: igual que bandera es una firma que no pide nada
        jugador.AgregarPuntos(puntos);
        Debug.Log("Moneda recogida puntos: " + jugador.ObtenerPuntaje());
        Destroy(gameObject);
    }
}
