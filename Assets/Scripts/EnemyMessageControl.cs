using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMessageControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.BroadcastMessage("beginChangeDirectionDegree", 4.0f, SendMessageOptions.RequireReceiver);
        //gameObject.BroadcastMessage("beginFindPlayer", 4.0f, SendMessageOptions.RequireReceiver);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySendMessage(float beginTime)
    {
        gameObject.BroadcastMessage("beginChangeDirectionDegree", beginTime, SendMessageOptions.RequireReceiver);
        gameObject.BroadcastMessage("beginFindPlayer", beginTime, SendMessageOptions.RequireReceiver);
    }
}
