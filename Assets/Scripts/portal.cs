using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    private GameObject player;
    public GameObject transfer;
    // Start is called before the first frame update
    void Start()
    {
        player = SenceCreator.player;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Time.timeScale = 1;
        //}
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            MusicLevelControl.VictoryMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            player.SetActive(false);
            //Instantiate(transfer, player.transform.position, Quaternion.identity);
            UIControl.instance.gameEnd.OnGameEnd(true);
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
}
