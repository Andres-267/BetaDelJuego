using UnityEngine;

public class VidaPersonaje
{
    private int vidaMaxima;
    private int vida;

    public VidaPersonaje(int vidaMaxima)
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
        if(vida <= 0)
        {
            vida = 0;
            return true;
        }
        return false;
    }
}
