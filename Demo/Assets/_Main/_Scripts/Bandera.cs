using UnityEngine;

public class Bandera : ObjetoMundo
{
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(" Has llegado al final :D");
        }
    }
}
