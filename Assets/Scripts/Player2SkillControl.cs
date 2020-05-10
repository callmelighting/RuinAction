using UnityEngine;

public class Player2SkillControl : MonoBehaviour
{
    private GameObject energyBall;
    private GameObject defenceCover;
    public GameObject perfectBlue;
    private GameObject perfectBlueClone;
    private GameObject riseParticle;
    private GameObject trail;
    //private Animator trailanimator;
    private Animator robotAnimator;
    private bool isTurn = false;
    void Start()
    {
        energyBall = transform.Find("EnergyBall").gameObject;
        defenceCover = transform.Find("DefenceCover").gameObject;
        defenceCover.SetActive(false);
        //perfectBlue = transform.Find("PerfectBlue").gameObject;
        //perfectBlue.SetActive(false);
        riseParticle = transform.Find("RiseParticle").gameObject;
        riseParticle.SetActive(false);
        trail = transform.Find("Trail").gameObject;
        trail.SetActive(false);
        //trailanimator = transform.Find("Trail").GetComponent<Animator>();
        robotAnimator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    //变身技能
    public void Turning()
    {
        robotAnimator.SetBool("Roll_Anim", (isTurn = !isTurn));
        if (!isTurn)
        {
            energyBall.SetActive(true);
            trail.SetActive(false);
        }
        else
        {
            trail.SetActive(true);
            energyBall.SetActive(false);
        }
    }

    //保护罩技能逻辑
    public void Defence()
    {
        if (IsInvoking("UpdateDefenceCover"))
            return;
        defenceCover.SetActive(true);
        Invoke("UpdateDefenceCover", 5.0f);
    }

    private void UpdateDefenceCover()
    {
        defenceCover.SetActive(false);
    }

    //完美之蓝技能逻辑
    public void Perfect()
    {
        if (IsInvoking("UpdatePerfectBlue"))
            return;
        //perfectBlue.SetActive(true);
        perfectBlueClone = Instantiate(perfectBlue, transform.position, Quaternion.identity);
        Invoke("UpdatePerfectBlue", 3.0f);
    }

    private void UpdatePerfectBlue()
    {
        Destroy(perfectBlueClone);
    }

    //收集Rise特效
    public void Rise()
    {
        if (IsInvoking("UpdateRise"))
            return;
        riseParticle.SetActive(true);
        //trail.SetActive(true);
        //trailanimator.SetTrigger("ShowTrail");
        Invoke("UpdateRise", 1.5f);
    }

    private void UpdateRise()
    {
        riseParticle.SetActive(false);
        //trail.SetActive(false);
    }
}
