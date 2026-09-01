using UnityEngine;

public class Obstaculo : ObjetoMundo
{
    private int danio = 1;


    public override void AlContacto(Jugador jugador)
    {
        jugador.RecibirDano(danio);

        Debug.Log("vida restante: " + jugador.GetVida());
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
        } 
    }

}
