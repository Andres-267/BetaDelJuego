using UnityEngine;
using UnityEngine.SceneManagement;

public class Jugador : Personaje
{
    [SerializeField] private int fuerzaSalto;
    private int puntos = 0;

    public bool enSuelo;

    private Rigidbody rb;


    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    public int GetPuntos()
    {
        return puntos;
    }

    public void AgregarPuntos(int cantPuntos)
    {
        if (cantPuntos > 0) puntos += cantPuntos;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        transform.Translate(
            x * velocidad * Time.deltaTime,
            0,
            z * velocidad * Time.deltaTime
        );

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
    }

    public void RecibirDano(int cantidad)
    {
        if (cantidad > 0)
        {
            vida -= cantidad;
            Debug.Log(nombre + " vida: " + vida);
            if (vida <= 0) Morir();
        }
    }

    public override void Morir()
    {
        base.Morir();
        //falta logica de juego para el GAME OVER
        SceneManager.LoadScene(2);
    }
}