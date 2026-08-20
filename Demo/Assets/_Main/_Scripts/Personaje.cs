using UnityEngine;

public class Personaje : MonoBehaviour
{
    public string nombre;
    public int vida;
    public int velocidad;


    public virtual void Morir()
    {
        Debug.Log(nombre + " ha muerto.");
    }
}
