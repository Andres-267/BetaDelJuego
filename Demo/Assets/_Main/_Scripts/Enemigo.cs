using UnityEngine;
using UnityEngine.AI;

public class Enemigo : Personaje
{
    public float distanciaPatrulla = 5f;
    public int daño = 10;

    private NavMeshAgent agente;

    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        agente.speed = velocidad;

        agente.updateRotation = false;
        agente.updateUpAxis = false;

        MoverAUnPuntoAleatorio();
    }

    private void Update()
    {
        if (!agente.pathPending && agente.remainingDistance <= 0.5f)
        {
            MoverAUnPuntoAleatorio();
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
}