using UnityEngine;

public class Player2Bullet1Control : MonoBehaviour
{
    public float bulletSpeed = 20.0f;

    public GameObject explosion1Prefab;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyHealthControl enemyHealthControl = other.GetComponent<EnemyHealthControl>();
        if (other.tag == "Trap")
        {

        }
        else
        {
            if (enemyHealthControl != null)
                enemyHealthControl.CreateDamage(1, 400);
            Instantiate(explosion1Prefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
