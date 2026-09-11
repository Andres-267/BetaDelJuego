using UnityEngine;

public class Caja : MonoBehaviour ,IDanable
/*{   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.8f);
        }
    }

    public override void Alcontacto(Jugador jugador)
    {
        jugador.AgregarPuntos(10);
        Debug.Log("Caja recogida puntos: " + jugador.ObtenerPuntaje());
        Destroy(gameObject);
    }
}*/
{
    [SerializeField] private bool tieneMonedas = true;
    [SerializeReference] private int cantidadMonedas = 5;
    
    public void RecibirDAnio(int cantidad)
    {
        Romperse();
    }
    private void Romperse()
    {
        if (tieneMonedas)
        {
            Debug.Log ("La caja se rompio y solto " + cantidadMonedas + " monedas");

        }
        Destroy(gameObject);        
    }
}