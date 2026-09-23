using UnityEngine;

public class Obstaculo : ObjetoMundo
{
    private int danio = 1;

    //detecta la colision con el jugador y le quita vida
    public override void Alcontacto(Jugador jugador)
    {
        jugador.RecibirDAnio(danio);

        Debug.Log("vida restante: " + jugador.GetVida());
        Destroy(this.gameObject);
    }


}
