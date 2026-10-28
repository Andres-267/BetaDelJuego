
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesVictoria : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    public void SalirDelJuego()
    {
        Time.timeScale = 1f;

        Debug.Log("Saliendo del juego...");

        Application.Quit();
    }
}
