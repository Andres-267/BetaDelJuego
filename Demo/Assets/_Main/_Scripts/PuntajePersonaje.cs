using UnityEngine;

public class PuntajePersonaje 
{
    private int puntaje;

    public void AgregarPuntos(int cantidad)
    {
        if (cantidad > 0) puntaje += cantidad;
    }
    
    public int ObtenerPuntaje()
    {
        return puntaje;
    }
}
