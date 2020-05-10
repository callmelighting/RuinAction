using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up);
    }
    public void OnTriggerEnter(Collider other)
    {
        Player2MoveControl playerMoveControl = other.GetComponent<Player2MoveControl>();
        if (playerMoveControl != null)
        {
            playerMoveControl.playerMoveSpeed = 0.5f;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        Player2MoveControl playerMoveControl = other.GetComponent<Player2MoveControl>();
        if (playerMoveControl != null)
        {
            playerMoveControl.playerMoveSpeed = 1.5f;
        }
    }
}
