using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarJuego : MonoBehaviour

{
    public void Reiniciar()   /// Single responsability: se encarga de una sola funcion y no altera el codigo ya hecho
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(2);
    }
}
