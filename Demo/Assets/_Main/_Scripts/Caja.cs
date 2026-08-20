using UnityEngine;

public class Caja : Objetos
{   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 1f);
        }
    }
}