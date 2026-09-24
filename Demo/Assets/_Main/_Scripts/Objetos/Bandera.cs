using UnityEngine;

public class Bandera : ObjetoMundo
{
public override void Alcontacto(Jugador jugador) /// Single responsability: solo se encarga de recibir el contacto y dar el debug 
    {                                            /// Liskov: La firma es igual que la base no cambia nada 
        Debug.Log(" Ganaste ");      
    }
}
