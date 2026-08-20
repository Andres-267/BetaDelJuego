using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : Personaje
{
    public Vector3 direccion = Vector3.right;

    private void Update()
    {
        transform.Translate(direccion * velocidad*Time.deltaTime);
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
            if (jugador != null) {jugador.Morir(); }
        }
    }

    public override void Morir()
    {
        base.Morir();
        Destroy(gameObject);
    }
}
