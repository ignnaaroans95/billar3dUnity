using System.Collections;
using UnityEngine;

public class AgujeroBillar : MonoBehaviour
{
    [Header("Punto donde reaparece la bola blanca")]
    public Transform posicionReinicio;

    [Header("Contador de bolas embocadas")]
    public ContadorBolas contador;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bola"))
        {
            if (contador != null)
            {
                contador.IncrementarContador();
            }

            Destroy(other.gameObject); // Destruir bola normal
        }
        else if (other.CompareTag("BolaBlanca"))
        {
            StartCoroutine(RecolocarBolaBlanca(other.gameObject));
        }
    }

    private IEnumerator RecolocarBolaBlanca(GameObject bola)
    {
        Rigidbody rb = bola.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        yield return new WaitForSeconds(0.1f);

        if (posicionReinicio != null)
        {
            bola.transform.position = posicionReinicio.position + Vector3.up * 0.2f;
        }
        else
        {
            Debug.LogWarning("⚠️ Posición de reinicio no asignada.");
        }
    }
}
