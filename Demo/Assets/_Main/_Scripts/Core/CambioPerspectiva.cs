
using UnityEngine;

public class CambioPerspectiva : MonoBehaviour
{
    public Camera camara;

    [Header("Perspectiva normal")]
    public Vector3 posicionNormal;
    public Vector3 rotacionNormal = new Vector3(50f, 0f, 0f);

    [Header("Perspectiva especial")]
    public Vector3 posicionEspecial;
    public Vector3 rotacionEspecial = new Vector3(70f, 0f, 0f);

    private void Start()
    {
        if (camara == null)
        {
            Debug.LogError("No has asignado la cámara.");
            return;
        }

        RestaurarPerspectiva();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AplicarPerspectiva(posicionEspecial, rotacionEspecial);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestaurarPerspectiva();
        }
    }

    private void AplicarPerspectiva(Vector3 posicion, Vector3 rotacion)
    {
        camara.transform.localPosition = posicion;
        camara.transform.localRotation = Quaternion.Euler(rotacion);
    }

    private void RestaurarPerspectiva()
    {
        AplicarPerspectiva(posicionNormal, rotacionNormal);
    }
}
