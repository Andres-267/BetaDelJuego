using UnityEngine;
using UnityEngine.SceneManagement;

public class Trampas : MonoBehaviour
{
            private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Diseño de nivel");
        }
    }
}
