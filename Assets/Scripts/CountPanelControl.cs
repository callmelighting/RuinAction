using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountPanelControl : MonoBehaviour
{
    public int enemyNum = 0;
    public int diamondoNum = 0;
    private Text enemyText;
    private Text diamondoText;
    private GameObject diamondoOk;

    private SenceCreator sc;

    // Start is called before the first frame update
    void Start()
    {
        enemyText = transform.Find("EnemyText").GetComponent<Text>();
        diamondoText = transform.Find("DiamondoText").GetComponent<Text>();
        diamondoOk = transform.Find("DiamondoOk").gameObject;
        diamondoOk.SetActive(false);

        sc = GameObject.Find("/Scripts").GetComponent<SenceCreator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyNumUpdate()
    {
        enemyNum++;
        enemyText.text = ": " + enemyNum;
    }

    public void DiamondoNumUpdate()
    {
        diamondoNum++;
        diamondoText.text = ": " + diamondoNum;
        if (diamondoNum >= sc.DiamondoNumber)
        {
            diamondoOk.SetActive(true);
        }
    }
}
