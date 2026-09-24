using UnityEngine;

public class Obstaculo : ObjetoMundo
{
    private int danio = 1;  /// Open / closed: se añade un objeto nuevo sin tocar el resto del sistema de danio 

    /// Single responsability: se encarga unicamente de dañar al player
    public override void Alcontacto(Jugador jugador)  /// Liskov: es abstracta por lo tanto la base no se cambia
    {
        jugador.RecibirDAnio(danio);

        Debug.Log("vida restante: " + jugador.GetVida());
        Destroy(this.gameObject);
    }


}
