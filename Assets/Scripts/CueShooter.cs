using UnityEngine;

public class CueShooter : MonoBehaviour
{
    public Rigidbody bolaBlanca;
    public float fuerza = 15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bolaBlanca.velocity = Vector3.zero;
            bolaBlanca.angularVelocity = Vector3.zero;

            bolaBlanca.AddForce(Vector3.forward * fuerza, ForceMode.Impulse);
        }
    }
}
