using System.Collections;
using UnityEngine;

public class PowerUp : ObjetoMundo
{
    [SerializeField] private int sanacion = 2;
    [SerializeField] private float invulnerabilidad = 5f;

    public override void Alcontacto(Jugador jugador)
    {
        jugador.Curar(sanacion);

        jugador.StartCoroutine(ActivarInvulnerabilidad(jugador));

        Destroy(this.gameObject);
    }

    private IEnumerator ActivarInvulnerabilidad (Jugador jugador)
    {
        jugador.SetInvulnerable(true);
        Debug.Log("Jugador es invulnerable por " + invulnerabilidad + " segundos.");

        yield return new WaitForSeconds(invulnerabilidad);

        jugador.SetInvulnerable(false);
    }
}
