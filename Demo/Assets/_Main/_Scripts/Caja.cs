using UnityEngine;

public class Caja : ObjetoMundo
{   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject, 0.8f);
        }
    }
}