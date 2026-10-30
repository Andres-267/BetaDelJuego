
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;

    [Header("Música de fondo")]
    [SerializeField] private AudioClip musicaFondo;
    [SerializeField] private float volumen = 0.5f;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = musicaFondo;
        audioSource.loop = true;
        audioSource.volume = volumen;
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        if (musicaFondo != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
