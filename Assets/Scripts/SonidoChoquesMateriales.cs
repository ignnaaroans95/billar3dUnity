using UnityEngine;

public class SonidoChoqueSeparado : MonoBehaviour
{
    public AudioClip sonidoChoqueBola;
    public AudioClip sonidoChoqueBorde;

    private AudioSource audioBola;
    private AudioSource audioBorde;

    void Awake()
    {
        // Creamos dos fuentes de audio separadas
        audioBola = gameObject.AddComponent<AudioSource>();
        audioBola.playOnAwake = false;
        audioBola.spatialBlend = 1f;

        audioBorde = gameObject.AddComponent<AudioSource>();
        audioBorde.playOnAwake = false;
        audioBorde.spatialBlend = 1f;
    }

    void OnCollisionEnter(Collision collision)
    {
        float fuerza = collision.relativeVelocity.magnitude;
        if (fuerza < 0.1f) return;

        if (collision.collider.CompareTag("Bola") && sonidoChoqueBola != null)
        {
            audioBola.clip = sonidoChoqueBola;
            audioBola.volume = Mathf.Clamp(fuerza / 5f, 0.1f, 1f);
            audioBola.Play();
        }
        else if (collision.collider.CompareTag("Borde") && sonidoChoqueBorde != null)
        {
            audioBorde.clip = sonidoChoqueBorde;
            audioBorde.volume = Mathf.Clamp(fuerza / 5f, 0.1f, 1f);
            audioBorde.Play();
        }
    }
}
