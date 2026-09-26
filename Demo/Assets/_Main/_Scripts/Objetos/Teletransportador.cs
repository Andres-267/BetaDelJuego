using UnityEngine;

public class Teletransportador : ObjetoMundo
{
    [Header("Configuración de teletransporte")]
    [SerializeField] private Transform destino;
    [SerializeField] private float retrasoSegundos = 0f;
    [SerializeField] private GameObject efectoTeletransporte;

    public override void Alcontacto(Jugador jugador)
    {
        if (destino == null)
        {
            Debug.LogWarning($"{name}: no se asignó un destino para el teletransportador.");
            return;
        }

        if (retrasoSegundos > 0f)
            StartCoroutine(TeletransportarConRetraso(jugador));
        else
            Teletransportar(jugador);
    }

    private System.Collections.IEnumerator TeletransportarConRetraso(Jugador jugador)
    {
        yield return new WaitForSeconds(retrasoSegundos);
        Teletransportar(jugador);
    }

    private void Teletransportar(Jugador jugador)
    {
        if (efectoTeletransporte != null)
            Instantiate(efectoTeletransporte, transform.position, Quaternion.identity);

        CharacterController cc = jugador.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        jugador.transform.position = destino.position;

        if (cc != null) cc.enabled = true;
    }
}
