using UnityEngine;
using UnityEngine.UI;

public class UISkillsControl : MonoBehaviour
{
    public UIControl uiControl;

    private Image defenceMask;
    private Image perfectMask;
    private Image turnMask;
    private Player2SkillControl player2SkillControl;

    private Animator robotAnimator;


    void Start()
    {
        robotAnimator = GameObject.FindWithTag("Player").transform.GetComponent<Animator>();

        defenceMask = transform.Find("Defence/Mask").GetComponent<Image>();
        perfectMask = transform.Find("Perfect/Mask").GetComponent<Image>();
        player2SkillControl = SenceCreator.player.GetComponent<Player2SkillControl>();
    }

    void Update()
    {

    }

    public void SkillTurnOnClick()
    {
        turnMask = transform.Find("Turn/Mask").GetComponent<Image>();
        if (IsInvoking("updateTurnMask"))
        {
            uiControl.hintTextControl.ShowHintText("变身冷却中!");
            return;
        }
        AnimatorStateInfo nowAnimatorStateInfo = robotAnimator.GetCurrentAnimatorStateInfo(0);
        if (nowAnimatorStateInfo.IsName("anim_Idle_Loop_S") ||
            nowAnimatorStateInfo.IsName("closed_Roll_Loop"))
        {
            MusicLevelControl.AlterMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            uiControl.hintTextControl.ShowHintText("变身!");
            player2SkillControl.Turning();

            turnMask.fillAmount = 1.0f;
            InvokeRepeating("updateTurnMask", 0.0f, 0.1f);
        }
        else
            uiControl.hintTextControl.ShowHintText("请停止移动进行变身!");
    }
    private void updateTurnMask()
    {
        if (turnMask.fillAmount > 0.0f)
            turnMask.fillAmount -= 0.05f;
        else
            CancelInvoke("updateTurnMask");
    }

    public void SkillDefenceOnClick()
    {    
        if (IsInvoking("updateDefenceMask"))
        {
            uiControl.hintTextControl.ShowHintText("防御罩冷却中!");
            return;
        }
        AnimatorStateInfo nowAnimatorStateInfo = robotAnimator.GetCurrentAnimatorStateInfo(0);
        if (nowAnimatorStateInfo.IsName("anim_Idle_Loop_S") ||
            nowAnimatorStateInfo.IsName("anim_Walk_Loop"))
        {
            MusicLevelControl.DefenceMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            uiControl.hintTextControl.ShowHintText("防御罩已开启!");
            player2SkillControl.Defence();

            defenceMask.fillAmount = 1.0f;
            InvokeRepeating("updateDefenceMask", 0.0f, 0.1f);
        }
        else
            uiControl.hintTextControl.ShowHintText("此状态无法释放技能!");
    }

    private void updateDefenceMask()
    {
        if (defenceMask.fillAmount > 0.0f)
            defenceMask.fillAmount -= 0.005f;
        else
            CancelInvoke("updateDefenceMask");
    }

    public void SkillPerfectOnClick()
    {
        if (IsInvoking("updatePerfectMask"))
        {
            uiControl.hintTextControl.ShowHintText("完美之蓝冷却中!");
            return;
        }
        AnimatorStateInfo nowAnimatorStateInfo = robotAnimator.GetCurrentAnimatorStateInfo(0);
        if (nowAnimatorStateInfo.IsName("anim_Idle_Loop_S") ||
            nowAnimatorStateInfo.IsName("anim_Walk_Loop"))
        {
            MusicLevelControl.PerfectblueMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            uiControl.hintTextControl.ShowHintText("完美之蓝已开启!");
            player2SkillControl.Perfect();

            perfectMask.fillAmount = 1.0f;
            InvokeRepeating("updatePerfectMask", 0.0f, 0.1f);
        }
        else
            uiControl.hintTextControl.ShowHintText("此状态无法释放技能!");
    }


    private void updatePerfectMask()
    {
        if (perfectMask.fillAmount > 0.0f)
            perfectMask.fillAmount -= 0.001f;
        else
            CancelInvoke("updatePerfectMask");
    }
}
