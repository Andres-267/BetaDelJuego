using UnityEngine;

public class Bandera : ObjetoMundo
{
public override void Alcontacto(Jugador jugador)
    {
        Debug.Log(" Ganaste ");      
    }
}
