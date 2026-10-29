using UnityEngine;

public class MovimientoJugador
{
    private int velocidad;
    private float fuerzaSalto;
    private Transform transform;
    private float velocidadRotacion;
    private Rigidbody rb;
    private bool enSuelo;

    ///  para animaciones
    public bool EstaMoviendose { get; private set; }
    public bool EnSuelo => enSuelo;

        public MovimientoJugador(int _velocidad, float _fuerzaSalto, Transform _transform, Rigidbody _rb, float _velocidadRotacion = 10f)/// Open / closed: los valores de velocidad y salto entran al constructor y ayuda a modficar distintos valores sin modificar la clase 
    {
        this.velocidad = _velocidad;
        this.fuerzaSalto = _fuerzaSalto;
        this.transform = _transform;
        this.velocidadRotacion = _velocidadRotacion;
        this.rb = _rb;
    }

        public void Mover() /// Single responsability: Solamente se encarga de recibir los inputs y realizar sus operaciones para ejecutarlas
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(x, 0, z);
        EstaMoviendose = direccion.sqrMagnitude > 0.01f;

        if (EstaMoviendose)
        {
            direccion.Normalize();

            // Se mueve en coordenadas del mundo para que W, A, S, D siempre apunten a la misma dirección
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);

            // Rota suavemente el personaje hacia la dirección en la que se mueve
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                rotacionObjetivo,
                velocidadRotacion * Time.deltaTime
            );
        }

        if ((Input.GetKeyDown(KeyCode.Space)) && enSuelo)
        {
            rb.AddForce(
                Vector3.up * fuerzaSalto,
                ForceMode.Impulse
            );

            enSuelo = false;
        }
    }

    
    public void OnCollisionEnter(Collision collision) /// Single responsability: la clase se encarga unicamente del salto
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }

}
