using UnityEngine;

public class Obstaculo : ObjetoMundo
{
    private int danio = 1;


    public override void Alcontacto(Jugador jugador)
    {
        jugador.RecibirDAnio(danio);

        Debug.Log("vida restante: " + jugador.GetVida());
        Destroy(this.gameObject);
    }


}
