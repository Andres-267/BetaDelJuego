using UnityEngine;

public class Caja : MonoBehaviour ,IDanable ///Interface Segregation: implementa una unica interfaz con un solo metodo 
{
    ///cumple interface segregation principle porque quien la daña depende de IDanable
    [SerializeField] private bool tieneMonedas = true;
    [SerializeReference] private int cantidadMonedas = 5;
    
    public void RecibirDAnio(int cantidad)  /// Single responsability: Solo se ocupa de una cosa
    {
        Romperse();
    }
    private void Romperse() /// Single responsability: Solo se ocupa de una cosa
    {
        if (tieneMonedas)
        {
            Debug.Log ("La caja se rompio y solto " + cantidadMonedas + " monedas");

        }
        Destroy(gameObject);        
    }
}