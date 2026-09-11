using UnityEngine;

public class Muro : MonoBehaviour
{
    private Collider muroCollider;

    private void Start()
    {
        muroCollider = GetComponent<Collider>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            Collider playerCollider = player.GetComponent<Collider>();

            if (playerCollider != null)
            {
                Physics.IgnoreCollision(muroCollider, playerCollider);
            }
        }
    }
}
