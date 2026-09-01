using UnityEngine;

public class Personaje : MonoBehaviour
{
    public string nombre;
    protected int vida;
    protected int velocidad = 8;

    private int vidaInicial = 5;
    protected virtual void Start()
    {
        vida = vidaInicial;
        Debug.Log(nombre + " se a creado con " + vida + " vida inicial");
    }

    public virtual void Morir()
    {
        Debug.Log("se murio");
    }

    public int GetVida()
    {
        return vida;
    }
}
