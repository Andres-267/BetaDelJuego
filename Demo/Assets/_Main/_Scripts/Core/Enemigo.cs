
using UnityEngine;

public class Enemigo : Personaje
{
    [Header("Movimiento")]
    public Vector3 direccion = Vector3.left;

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {
        transform.Translate(
            direccion * velocidad * Time.deltaTime,
            Space.World
        );
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Cambiar de dirección al chocar con una pared
        if (collision.gameObject.CompareTag("Pared"))
        {
            direccion = -direccion;
        }

        // Hacer daño al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();

            if (jugador != null)
            {
                jugador.RecibirDAnio(1);
            }
        }
    }

    public override void Morir()
    {
        base.Morir();
        Destroy(gameObject);
    }
}
