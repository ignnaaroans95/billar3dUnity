using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SonidoChoqueBola : MonoBehaviour
{
    public AudioClip sonidoChoque;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sonidoChoque;
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // Sonido 3D
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.1f && collision.collider.CompareTag("Bola"))
        {
            audioSource.Play();
        }
    }
}
