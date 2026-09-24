using UnityEngine;
/// Interface Segregation: no obliga a implementar ninguna interfaz eso depende de los hijos
public class Personaje : MonoBehaviour
{
    public string nombre;         ///
    protected int vida;           /// Single responsability: sirve como base ademas de estar restringida para que solo se modifique dentro y por las clases que la heredan
    protected int velocidad = 8;  ///

    private int vidaInicial = 5;
    protected virtual void Start()  /// Open/ closed: el virtual ayuda a que quien lo hereda añada su comportumaniento y eso es loq ue hace jugador
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
