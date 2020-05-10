using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour
{
    private UIControl uiControl;
    public GameObject portalPerfab;
    private Player2SkillControl player2SkillControl;
    private SenceCreator sc;
    private Animator trailAnimator;
    void Start()
    {
        uiControl = GameObject.Find("/Canvas").GetComponent<UIControl>();
        sc = GameObject.Find("/Scripts").GetComponent<SenceCreator>();
        player2SkillControl = SenceCreator.player.GetComponent<Player2SkillControl>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            Destroy(this.gameObject);
            player2SkillControl.Rise();
            UIControl.instance.countPanelControl.DiamondoNumUpdate();
            if (sc.DiamondoNumber != 0)
            {
                sc.DiamondoNumber--;
                MusicLevelControl.CollectMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            }
            if (sc.DiamondoNumber == 0)
            {
                uiControl.hintTextControl.ShowHintText("收集完毕，请尽快逃走！！！");
                if (!sc.portalexist)
                {
                    Instantiate(portalPerfab);
                    sc.portalexist = true;
                }
            }
        }
    }
}
