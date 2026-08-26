using UnityEngine;
using UnityEngine.AI;

public class Enemigo : Personaje
{
    public float distanciaPatrulla = 5f;
    public int daño = 10;

    [Header("Detección de Jugador")]
    public float rangoVision = 6f; // Distancia a la que el enemigo te ve
    private Transform transformJugador; // Guardará la referencia del jugador

    private NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.speed = velocidad;

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        // Busca automáticamente al jugador por su Tag al iniciar la escena
        GameObject jugadorObject = GameObject.FindWithTag("Player");
        if (jugadorObject != null)
        {
            transformJugador = jugadorObject.transform;
        }

        MoverAUnPuntoAleatorio();
    }

    private void Update()
    {
        // 1. Verificamos si encontramos al jugador en la escena y calculamos la distancia
        if (transformJugador != null && Vector3.Distance(transform.position, transformJugador.position) <= rangoVision)
        {
            // COMPORTAMIENTO PERSEGUIR: Va directo a la posición actual del jugador
            agente.SetDestination(transformJugador.position);
        }
        else
        {
            // COMPORTAMIENTO PATRULLA: Si no hay jugador cerca, sigue con tu lógica original
            if (!agente.pathPending && agente.remainingDistance <= 0.5f)
            {
                MoverAUnPuntoAleatorio();
            }
        }
    }

    private void MoverAUnPuntoAleatorio()
    {
        Vector3 puntoAleatorio = transform.position +
                                 Random.insideUnitSphere * distanciaPatrulla;

        NavMeshHit puntoNavMesh;

        if (NavMesh.SamplePosition(
            puntoAleatorio,
            out puntoNavMesh,
            distanciaPatrulla,
            NavMesh.AllAreas))
        {
            agente.SetDestination(puntoNavMesh.position);
        }
    }

    public override void Morir()
    {
        base.Morir();
        Destroy(gameObject);
    }

    // Dibuja un círculo en el editor para que puedas calibrar visualmente el rango de visión
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoVision);
    }
}