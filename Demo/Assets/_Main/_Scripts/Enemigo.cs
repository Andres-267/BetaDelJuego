using UnityEngine;

public class Enemigo : Personaje
{
    public Vector3 direccion = Vector3.left;

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
            Debug.Log("direccion " + direccion);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Jugador jugador = collision.gameObject.GetComponent<Jugador>();
            if (jugador != null) { jugador.RecibirDano(1); }
        }
    }

    public override void Morir()
    {
        base.Morir();
        Destroy(gameObject);
    }

}
