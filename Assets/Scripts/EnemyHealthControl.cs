using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthControl : MonoBehaviour
{
    public int totalHP = 1000;
    private int nowHP;

    private UIControl uiControl;

    private Image healthCircle;
    private EnemyBehaviourControl behaviourControl;

    private Color color1 = new Color(255 / 255.0f, 100 / 255.0f, 110 / 255.0f);
    private Color color2 = new Color(125 / 255.0f, 255 / 255.0f, 100 / 255.0f);

    void Start()
    {
        nowHP = totalHP;

        uiControl = GameObject.Find("/Canvas").GetComponent<UIControl>();

        healthCircle = transform.Find("Canvas1").Find("healthCircle").GetComponent<Image>();
        behaviourControl = transform.GetComponent<EnemyBehaviourControl>();

        healthCircle.color = color2;
    }

    public void CreateDamage(int kind, int damage)
    {
        switch (kind)
        {
            case 1:
                nowHP -= (nowHP > damage ? damage : nowHP);
                break;
            default: break;
        }
        setHealthCircleAndBar();
        setHelthBehaviour();
    }

    private void setHealthCircleAndBar()
    {
        float healthRate = (float)nowHP / (float)totalHP;
        healthCircle.fillAmount = healthRate;
        healthCircle.color = color1 * (1.0f - healthRate) + color2 * healthRate;

        uiControl.healthBarEnemyControl.Value = healthRate;
    }

    private void setHelthBehaviour()
    {
        if (nowHP == 0)
        {
            behaviourControl.Dead();
            MusicLevelControl.EnemyDeadMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            UIControl.instance.countPanelControl.EnemyNumUpdate();
            uiControl.hintTextControl.ShowHintText("击杀!!!");
        }
    }
}
