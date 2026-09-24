using System.Collections;
using UnityEngine;

public class PowerUp : ObjetoMundo
{
    [SerializeField] private int sanacion = 2;
    [SerializeField] private float invulnerabilidad = 5f;

    public override void Alcontacto(Jugador jugador)  /// Single responsability: se encarga unicamente de la deteccion
    {                                                 /// Liskov. es abastracta no modifica la base
        jugador.Curar(sanacion);

        jugador.StartCoroutine(ActivarInvulnerabilidad(jugador));

        Destroy(this.gameObject);
    }

    private IEnumerator ActivarInvulnerabilidad (Jugador jugador) /// Single responsability: se encarga de activar los efectos del power up
    {                                                             /// Open / closed: combina dos metodos ya existentes para crear uno nuevo pero sin modificarlos
        jugador.SetInvulnerable(true);
        Debug.Log("Jugador es invulnerable por " + invulnerabilidad + " segundos.");

        yield return new WaitForSeconds(invulnerabilidad);

        jugador.SetInvulnerable(false);
    }
}
