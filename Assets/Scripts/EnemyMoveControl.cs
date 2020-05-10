using UnityEngine;

public class EnemyMoveControl : MonoBehaviour
{
    public float speed = 2.0f;

    private float directionDegree;
    private Vector3 direction;

    private EnemyDetectControl enemyDetectControl;

    void Start()
    {
        enemyDetectControl = GetComponent<EnemyDetectControl>();

        direction = Vector3.zero;
        //InvokeRepeating("ChangeDirectionDegree", 4.0f, 2.0f);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed, Space.World);
        transform.LookAt(transform.position + direction);
    }

    private void ChangeDirectionDegree()
    {
        if (!enemyDetectControl.canSeePlayer)
        {
            directionDegree = Random.Range(0.0f, 360.0f);
            direction = new Vector3(Mathf.Sin(directionDegree), 0.0f, Mathf.Cos(directionDegree));
        }
        else
        {
            direction = new Vector3(
                    SenceCreator.player.transform.position.x - transform.position.x,
                    0.0f,
                    SenceCreator.player.transform.position.z - transform.position.z
            ).normalized;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        directionDegree = (directionDegree + 180.0f) % 360.0f;
        direction = new Vector3(Mathf.Sin(directionDegree), 0.0f, Mathf.Cos(directionDegree));
    }

    public void beginChangeDirectionDegree(float beginTime)
    {
        InvokeRepeating("ChangeDirectionDegree", beginTime, 2.0f);
    }
}
