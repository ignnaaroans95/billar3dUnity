using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SonidoChoqueConBorde : MonoBehaviour
{
    public AudioClip sonidoChoqueBorde;

    private AudioSource audioSource;
    private float tiempoDeEspera = 0.5f; // medio segundo de gracia al iniciar
    private float tiempoInicio;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f;

        tiempoInicio = Time.time;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ignorar sonidos durante los primeros 0.5 segundos
        if (Time.time - tiempoInicio < tiempoDeEspera) return;

        if (collision.collider.CompareTag("Borde"))
        {
            float fuerza = collision.relativeVelocity.magnitude;

            if (fuerza > 0.1f && sonidoChoqueBorde != null)
            {
                audioSource.volume = Mathf.Clamp(fuerza / 5f, 0.1f, 1f);
                audioSource.clip = sonidoChoqueBorde;
                audioSource.Play();
            }
        }
    }
}
