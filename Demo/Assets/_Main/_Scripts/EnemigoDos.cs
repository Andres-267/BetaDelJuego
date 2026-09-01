using UnityEngine;

public class EnemigoDos : Personaje
{
    public float rangoMovimiento = 3f;
    public int dano = 10;

    private Rigidbody rb;
    private Vector3 posicionInicial;
    private int direccion = 1;
    private bool estaMuerto = false;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
    }

    void FixedUpdate()
    {
        if (estaMuerto) return;

        float distancia = transform.position.x - posicionInicial.x;

        if (Mathf.Abs(distancia) >= rangoMovimiento)
        {
            direccion *= -1;
            posicionInicial = transform.position;
        }

        rb.linearVelocity = new Vector3(
            velocidad * direccion,
            rb.linearVelocity.y,
            0f
        );
    }

    void OnCollisionEnter(Collision col)
    {
        if (estaMuerto) return;

        // Choca con una pared — cambia de dirección
        foreach (ContactPoint c in col.contacts)
        {
            if (Mathf.Abs(c.normal.x) > 0.5f)
            {
                direccion *= -1;
                posicionInicial = transform.position;
                break;
            }
        }

        // Choca con el jugador
        if (!col.gameObject.CompareTag("Player")) return;

        bool saltoEncima = col.transform.position.y >
                           transform.position.y + 0.3f;

        if (saltoEncima)
        {
            Morir();
            col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
        else
        {
            col.gameObject.GetComponent<Jugador>().RecibirDano(dano);
        }
    }

    public override void Morir()
    {
        estaMuerto = true;
        Destroy(gameObject);
    }
}
