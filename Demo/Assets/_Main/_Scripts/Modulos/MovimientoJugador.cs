using UnityEngine;

public class MovimientoJugador
{
    private int velocidad;
    private float fuerzaSalto;
    private Transform transform;
    private Rigidbody rb;
    private bool enSuelo;

    public MovimientoJugador(int _velocidad, float _fuerzaSalto, Transform _transform, Rigidbody _rb) /// Open / closed: los valores de velocidad y salto entran al constructor y ayuda a modficar distintos valores sin modificar la clase 
    {
        this.velocidad = _velocidad;
        this.fuerzaSalto = _fuerzaSalto;
        this.transform = _transform;
        this.rb = _rb;
    }

    public void Mover()  /// Single responsability: Solamente se encarga de recibir los inputs y realizar sus operaciones para ejecutarlas
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
