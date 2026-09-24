using UnityEngine;

public class Enemigo : Personaje
{
    public Vector3 direccion = Vector3.left; /// Open/ close: Permite la configuracion desde el inpector y es publico para continuar con su extension a futuro


    protected override void Start()
    {
        base.Start();
    }
    private void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Pared"))
        {
            direccion = -direccion;
            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (jugador != null) { jugador.RecibirDAnio(1); }
            
        }
    }

    public override void Morir()   /// Open / close: extiende desde personaje "morir" por herencia
    {                              /// Liskov: Se llama a "base.morir" y se le agrega mas comportamientos y ahorrar lineas de codigo
        base.Morir();
        Destroy(gameObject);
    }

}
