using UnityEngine;

public class Player2BehaviourControl : MonoBehaviour
{
    public GameObject playerDie;
    void Start()
    {

    }

    void Update()
    {

    }

    public void Dead()
    {
        gameObject.SetActive(false);
        Instantiate(playerDie, transform.position, Quaternion.identity);
    }
}
