using UnityEngine;

public class Jugador : Personaje
{
    [SerializeField] private int fuerzaSalto;
    private int puntos = 0;

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
        if (cantPuntos > 0)  puntos += cantPuntos;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x*velocidad*Time.deltaTime,0,0);

        if (Input.GetKeyDown(KeyCode.Space)) { 
            GetComponent<Rigidbody>().AddForce(Vector3.up*fuerzaSalto,ForceMode.Impulse);
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
        Debug.Log("Jake fue herido");
    }
}
