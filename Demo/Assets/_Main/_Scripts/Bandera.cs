using UnityEngine;

public class Bandera : Objetos
{
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(" Has llegado al final :D");
        }
    }
}
