using UnityEngine;

public class CueController : MonoBehaviour
{
    public Transform bolaBlanca;       // La bola blanca
    public Transform tacoPivot;        // El GameObject vacío que contiene el taco

    public float distanciaDetras = 1f;
    public float retroceso = 0.5f;
    public float fuerzaDisparo = 5f;
    public float velocidadAnimacion = 10f;
    public float velocidadRotacion = 100f;

    private bool estaDisparando = false;
    private float angulo = 0f; // Ángulo de rotación alrededor de la bola (grados)

    void Awake()
    {
        // Colocar el taco correctamente desde el primer frame
        angulo = 0f;
        ActualizarPosicionTaco();
    }

    void Update()
    {
        if (estaDisparando) return;

        // Rotar el taco con flechas ← →
        angulo += Input.GetAxis("Horizontal") * velocidadRotacion * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direccion = CalcularDireccion();
            StartCoroutine(Disparar(direccion));
        }
    }

    void LateUpdate()
    {
        // Asegurar colocación precisa del taco detrás de la bola
        if (!estaDisparando)
        {
            ActualizarPosicionTaco();
        }
    }

    void ActualizarPosicionTaco()
    {
        Vector3 direccion = CalcularDireccion();
        Vector3 posicionTaco = bolaBlanca.position - direccion * distanciaDetras;

        tacoPivot.position = posicionTaco;
        tacoPivot.LookAt(bolaBlanca.position);
    }

    Vector3 CalcularDireccion()
    {
        float rad = angulo * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(rad), 0f, Mathf.Sin(rad)).normalized;
    }

    System.Collections.IEnumerator Disparar(Vector3 direccion)
    {
        estaDisparando = true;

        Vector3 posicionInicial = tacoPivot.position;
        Vector3 posicionAtras = posicionInicial - direccion * retroceso;

        float t = 0f;
        while (t < 1f)
        {
            tacoPivot.position = Vector3.Lerp(posicionInicial, posicionAtras, t);
            t += Time.deltaTime * velocidadAnimacion;
            yield return null;
        }

        Rigidbody rb = bolaBlanca.GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.AddForce(direccion * fuerzaDisparo, ForceMode.Impulse);

        t = 0f;
        while (t < 1f)
        {
            tacoPivot.position = Vector3.Lerp(posicionAtras, posicionInicial, t);
            t += Time.deltaTime * velocidadAnimacion;
            yield return null;
        }

        estaDisparando = false;
    }
}
