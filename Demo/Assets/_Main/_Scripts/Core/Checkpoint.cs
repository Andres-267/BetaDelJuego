
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public static Vector3 ultimaPosicion;
    public static bool existeCheckpoint = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ultimaPosicion = transform.position;
            existeCheckpoint = true;

            Debug.Log("Checkpoint activado: " + ultimaPosicion);
        }
    }
}
