using UnityEngine;
using UnityEngine.AI;

public class Enemigo : Personaje
{
    public float distanciaPatrulla = 5f;
    public int daño = 10;

    [Header("Detección de Jugador")]
    public float rangoVision = 6f; 
    private Transform transformJugador; 

    private NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.speed = velocidad;

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        
        GameObject jugadorObject = GameObject.FindWithTag("Player");
        if (jugadorObject != null)
        {
            transformJugador = jugadorObject.transform;
        }

        MoverAUnPuntoAleatorio();
    }

    private void Update()
    {
        
        if (transformJugador != null && Vector3.Distance(transform.position, transformJugador.position) <= rangoVision)
        {
            
            agente.SetDestination(transformJugador.position);
        }
        else
        {
            
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


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoVision);
    }
}