using UnityEngine;

public class VidaPersonaje
{
    private int vidaMaxima;               ///
    private int vida;                     /// Single responsability: Se encargan solo de gestionar la salud y respetar los limites de a vida

    public VidaPersonaje(int vidaMaxima)  /// Open / closed: el maximo entra al constructor lo que permite que cada personaje tenga su vida sin modificar la clase
    {
        this.vidaMaxima = vidaMaxima;
        this.vida = vidaMaxima;
    }

    public int GetVida()
    {
        return vida;
    }


    public bool RecibirDano(int cantidad)
    {
        if (cantidad <= 0) return false;

        vida -= cantidad;
        if (vida <= 0)
        {
            vida = 0;
            return true;
        }
        return false;
    } 

    public void curar(int cantidad)
    {
        if (cantidad <= 0) return;
        vida += cantidad;

        if (vida >= vidaMaxima)
        {
            vida = vidaMaxima;
        } 
    }
}
