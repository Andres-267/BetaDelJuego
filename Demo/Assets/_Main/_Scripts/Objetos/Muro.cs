using UnityEngine;

public class Muro : MonoBehaviour
{
    //Single responsibility Principle (SRP): This class is responsible for managing the wall's behavior, specifically its collision interactions with the player.
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
