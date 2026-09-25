using UnityEngine;
using UnityEngine.SceneManagement;

/*public class Jugador : Personaje
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
*/

public class Jugador : Personaje, IDanable  /// Interface Segregation: implementa metodos que necesito
{
    [SerializeField] private int fuerzaSalto;
    [SerializeField] private int vidaMaxima;

    private VidaPersonaje vidaPersonaje;              ///

    private MovimientoJugador movimientoJugador;      /// Single responsability: no implmentan codigo, encarga clases separadas cada una con un papel distinto para permitir la escalabilidad a futuro y la deteccion de errores

    private PuntajePersonaje puntajePersonaje;       ///    

    protected override void Start()   /// Liskov: El override llama a "base" y agrega mas comportamientos. 
    {
        base.Start();
        vidaPersonaje = new VidaPersonaje(vidaMaxima);
        puntajePersonaje = new PuntajePersonaje();
        movimientoJugador = new MovimientoJugador(velocidad, fuerzaSalto, this.transform, this.GetComponent<Rigidbody>());
    }

    private void Update()
    {
        movimientoJugador.Mover();
    }

    private void OnCollisionEnter(Collision collision)
    {
        movimientoJugador.OnCollisionEnter(collision);

        IDanable danable = collision.gameObject.GetComponent<IDanable>(); /// Dependency Inversion: Depende de "IDanable" , puede dañar cualquier cosa que implmente la interfaz
        if (danable == null) return;

        // compruebo la direccion de collision
        bool saltoEncima = collision.contacts[0].normal.y > 0.5;

        if (saltoEncima)
        {
            danable.RecibirDAnio(1);
            GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        }
    }

    public void RecibirDAnio(int cantidad)
    {
        if (esInmune)
        {
            Debug.Log("Jugador es inmune y no recibe daño.");
            return;
            
        }

        vidaPersonaje.RecibirDano(cantidad);

        if (!vidaPersonaje.EstaVivo())
        {
            Morir();
        }
    }
    public override void Morir()   /// Open / closed: Extiende la variable de morir en el script de personaje sin modificarlo
    {                              /// Liskov: Igual llaman a base para ahorrar codigo y sobreescibirlo para agregarle metodos nuevos
            base.Morir();
            
            SceneManager.LoadScene(2);
    
    }

    public void AgregarPuntos(int cantidad)
    {
        puntajePersonaje.AgregarPuntos(cantidad);
    }

    public int ObtenerPuntaje()
    {
        return puntajePersonaje.ObtenerPuntaje();
    }

    /* Nuevo metodo Ocp para los power ups */

    private bool esInmune = false;

    public void SetInvulnerable(bool invulnerable)  /// Open / closed: El personaje llama a invulnerable pero no cambia la logica
    {
        esInmune = invulnerable;
    }

    public void Curar(int cantidad)                /// Open / Closed: El personaje llama a curar pero no cambia la logica
    {
        vidaPersonaje.curar(cantidad);
    }

}

