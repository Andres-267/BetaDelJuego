using UnityEngine;

public class CambioPerspectiva : MonoBehaviour
{
    public Camera camara;

    [Header("Rotación normal")]
    public Vector3 rotacionNormal = new Vector3(50f, 0f, 0f);

    [Header("Rotación especial")]
    public Vector3 rotacionEspecial = new Vector3(70f, 0f, 0f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camara.transform.localRotation = Quaternion.Euler(rotacionEspecial);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            camara.transform.localRotation = Quaternion.Euler(rotacionNormal);
        }
    }
}