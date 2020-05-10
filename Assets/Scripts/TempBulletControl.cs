using UnityEngine;

public class TempBulletControl : MonoBehaviour
{
    private float bulletSpeed = 10.0f;
    private Animator robotAnimator;
    void Start()
    {
        robotAnimator = GameObject.FindWithTag("Player").transform.GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player2HealthControl player2HealthControl = other.GetComponent<Player2HealthControl>();
        if (other.tag == "Trap")
        {

        }
        else
        {
            if (player2HealthControl != null)
            {
                AnimatorStateInfo nowAnimatorStateInfo = robotAnimator.GetCurrentAnimatorStateInfo(0);
                if (nowAnimatorStateInfo.IsName("closed_Roll_Loop"))
                    player2HealthControl.CreateDamage(1, 500);
                else
                    player2HealthControl.CreateDamage(1, 1000);
            }
            Destroy(gameObject);
        }
    }
}
