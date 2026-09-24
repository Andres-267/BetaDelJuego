using UnityEngine;

public class PuntajePersonaje 
{
    private int puntaje;   /// Single responsability: La clase se encarga solo de una cosa 

    public void AgregarPuntos(int cantidad)
    {
        if (cantidad > 0) puntaje += cantidad;  /// Single responsability: La clase se encarga solo de una cosa 

    }
    
    public int ObtenerPuntaje()  /// Single responsability: La clase se encarga solo de una cosa 

    {
        return puntaje;
    }
}
