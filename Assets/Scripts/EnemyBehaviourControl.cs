using UnityEngine;

public class EnemyBehaviourControl : MonoBehaviour
{
    public GameObject EnemyDie;
    private GameObject EnemyDieClone;
    void Start()
    {
    }

    void Update()
    {

    }

    public void Dead()
    {
        EnemyDieClone = Instantiate(EnemyDie, transform.position, Quaternion.identity);
        Invoke("EnemyDestroy", 1.0f);
        Destroy(gameObject);
    }

    public void EnemyDestroy()
    {
        Destroy(EnemyDieClone);
    }
}
