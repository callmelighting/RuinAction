using UnityEngine;

public class EnemyGun1Control : MonoBehaviour
{
    public GameObject bulletPrefab;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Fire(Vector3 direction)
    {
        float fireBirthRadius = 1.0f;
        Vector3 birthCenter = transform.position + Vector3.up * 1.85f; ;
        Vector3 birthPosition = birthCenter + direction * fireBirthRadius;
        GameObject tempBullet = Instantiate(bulletPrefab, birthPosition, Quaternion.identity);
        tempBullet.transform.LookAt(tempBullet.transform.position + direction);
    }
}
