
using UnityEngine;

public class EnemigoDos : Personaje, IDanable
{
    [Header("Configuración")]
    public float rangoMovimiento = 15f;
    public int dano = 2;

    [Header("Orientación del modelo")]
    [SerializeField] private float anguloDerecha = 90f;
    [SerializeField] private float anguloIzquierda = -90f;

    private Rigidbody rb;
    private Vector3 posicionInicial;
    private int direccion = 1;
    private bool estaMuerto = false;


private void CambiarDireccion()
{
    direccion *= -1;
    posicionInicial = transform.position;
    OrientarModelo();
}

private void OrientarModelo()
{
    float angulo = direccion > 0 ? anguloDerecha : anguloIzquierda;
    transform.rotation = Quaternion.Euler(0f, angulo, 0f);
}


    protected override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;
        OrientarModelo();
    }

    private void FixedUpdate()
    {
        if (estaMuerto || rb == null) return;

        float distancia = transform.position.x - posicionInicial.x;

        if (Mathf.Abs(distancia) >= rangoMovimiento)
        {
            CambiarDireccion();
        }


        rb.linearVelocity = new Vector3(
            velocidad * direccion,
            rb.linearVelocity.y,
            0f
        );
    }

    private void OnCollisionEnter(Collision col)
    {
        if (estaMuerto) return;

        // Cambiar de dirección al chocar lateralmente
        foreach (ContactPoint c in col.contacts)
        {
            if (Mathf.Abs(c.normal.x) > 0.5f)
            {

                if (col.gameObject.CompareTag("Pared"))
                {
                    CambiarDireccion();
                }

                break;
            }
        }

        // Comprobar si chocó con el jugador
        if (!col.gameObject.CompareTag("Player")) return;

        Jugador jugador = col.gameObject.GetComponent<Jugador>();

        if (jugador == null) return;

        bool saltoEncima =
            col.transform.position.y > transform.position.y + 0.5f;

        if (saltoEncima)
        {
            RecibirDAnio(1);

            Rigidbody rbJugador = col.gameObject.GetComponent<Rigidbody>();

            if (rbJugador != null)
            {
                rbJugador.AddForce(
                    Vector3.up * 2f,
                    ForceMode.Impulse
                );
            }
        }
        else
        {
            jugador.RecibirDAnio(dano);
        }
    }

    public override void Morir()
    {
        if (estaMuerto) return;

        estaMuerto = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
        }

        Destroy(gameObject);
    }

    public void RecibirDAnio(int cant)
    {
        if (estaMuerto || cant <= 0) return;

        vida -= cant;

        if (vida <= 0)
        {
            Morir();
        }
    }
}
