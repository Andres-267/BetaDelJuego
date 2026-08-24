using UnityEngine;

public class Jugador : Personaje
{
    public int fuerzaSalto;
    public bool enSuelo;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x * velocidad * Time.deltaTime, 0, 0);

        if ((Input.GetKeyDown(KeyCode.Space)) && enSuelo)
        {
            GetComponent<Rigidbody>().AddForce(
                Vector3.up * fuerzaSalto,
                ForceMode.Impulse
            );

            enSuelo = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }

        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Enemigo enemigo = collision.gameObject.GetComponent<Enemigo>();

            if (enemigo != null)
            {
                RecibirDano(enemigo.daño);
            }
        }
    }

    public override void Morir()
    {
        Debug.Log("El jugador ha muerto.");
    }

    public void RecibirDano(int danio)
    {
        vida -= danio;

        Debug.Log(
            "El jugador ha recibido " + danio +
            " de daño. Vida restante: " + vida
        );

        if (vida <= 0)
        {
            Morir();
        }
    }
}