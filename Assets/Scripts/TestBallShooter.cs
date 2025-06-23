using UnityEngine;

public class TestBallShooter : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * 20f, ForceMode.Impulse);
    }
}
