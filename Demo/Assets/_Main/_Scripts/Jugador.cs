using UnityEngine;

public class Jugador : Personaje
{
    public int fuerzaSalto;

     void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(x*velocidad*Time.deltaTime,0,0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up*fuerzaSalto,ForceMode.Impulse);
        }
    }

    public override void Morir()
    {
       Debug.Log("El jugador ha muerto.");
    }

    public void RecibirDano(int danio)
    {
        vida -= danio;
        Debug.Log("El jugador ha recibido " + danio + " de daño. Vida restante: " + vida);
    }
}
