using UnityEngine;

public class PlayerEnergyBallControl : MonoBehaviour
{
    public float rotateSpeed = 50.0f;
    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
    }
}
