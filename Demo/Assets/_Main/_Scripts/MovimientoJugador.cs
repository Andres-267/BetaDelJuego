using UnityEngine;

public class MovimientoJugador
{
    private int velocidad;
    private float fuerzaSalto;
    private Transform transform;
    private Rigidbody rb;
    private bool enSuelo;

    public MovimientoJugador(int _velocidad, float _fuerzaSalto, Transform _transform, Rigidbody _rb)
    {
        this.velocidad = _velocidad;
        this.fuerzaSalto = _fuerzaSalto;
        this.transform = _transform;
        this.rb = _rb;
    }

    public void Mover()
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
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
            Debug.Log("Jugador en suelo");
        }
    }

}
