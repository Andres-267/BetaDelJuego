
using UnityEngine;

public class CambioPerspectiva : MonoBehaviour
{
    public Camera camara;

    [Header("Perspectiva normal")]
    public Vector3 posicionNormal = new Vector3(0.4461979f, 9f, -8f);
    public Vector3 rotacionNormal = new Vector3(50f, 0f, 0f);

    [Header("Perspectiva especial")]
    public Vector3 posicionEspecial;
    public Vector3 rotacionEspecial = new Vector3(70f, 0f, 0f);

    [Header("Configuración")]
    public bool restaurarPerspectiva = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (camara == null)
        {
            Debug.LogError("No has asignado la cámara.");
            return;
        }

        if (restaurarPerspectiva)
        {
            AplicarPerspectiva(posicionNormal, rotacionNormal);
        }
        else
        {
            AplicarPerspectiva(posicionEspecial, rotacionEspecial);
        }
    }

    private void AplicarPerspectiva(Vector3 posicion, Vector3 rotacion)
    {
        camara.transform.localPosition = posicion;
        camara.transform.localRotation = Quaternion.Euler(rotacion);
    }
}
