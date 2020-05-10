using UnityEngine;

public class EnemyDetectControl : MonoBehaviour
{
    public float maxDistance = 20.0f;
    public bool canSeePlayer;

    private Ray detectRay;
    private RaycastHit detectHit;
    private int detectableMask;

    private EnemyGun1Control enemyGun1Control;

    void Start()
    {
        enemyGun1Control = GetComponent<EnemyGun1Control>();


        detectRay = new Ray();
        detectableMask = LayerMask.GetMask("GroundAndPlayer");

    }

    void Update()
    {

    }

    private void FindPlayer()
    {
        // tempLine.SetPosition(0, transform.position + Vector3.up * 1.85f);

        detectRay.origin = transform.position + Vector3.up * 1.85f;
        detectRay.direction = new Vector3(
                    SenceCreator.player.transform.position.x - transform.position.x,
                    0.0f,
                    SenceCreator.player.transform.position.z - transform.position.z
                ).normalized;

        if (Physics.Raycast(detectRay, out detectHit, maxDistance, detectableMask))
        {
            // tempLine.SetPosition(1, detectHit.point);
            canSeePlayer = (detectHit.transform.gameObject == SenceCreator.player);
            if (canSeePlayer)
            {
                enemyGun1Control.Fire(detectRay.direction);
            }
        }

    }

    public void beginFindPlayer(float beginTime)
    {
        InvokeRepeating("FindPlayer", beginTime, 2.0f);
    }
}
