using UnityEngine;
using UnityEngine.UI;

public class Player2HealthControl : MonoBehaviour
{
    public int totalHP = 10000;
    private int nowHP;

    private UIControl uiControl;

    private Image healthCircle;
    private Player2BehaviourControl behaviourControl;

    private Color color1 = new Color(255 / 255.0f, 100 / 255.0f, 110 / 255.0f);
    private Color color2 = new Color(125 / 255.0f, 255 / 255.0f, 255 / 255.0f);

    private GameEnd gameEnd;

    void Start()
    {
        nowHP = totalHP;

        uiControl = GameObject.Find("/Canvas").GetComponent<UIControl>();
        gameEnd = GameObject.Find("Canvas/Dialog").GetComponent<GameEnd>();

        healthCircle = transform.Find("Canvas2").Find("healthCircleImage").GetComponent<Image>();
        behaviourControl = transform.GetComponent<Player2BehaviourControl>();

        healthCircle.color = color2;
    }

    public void CreateDamage(int kind, int damage)
    {
        MusicLevelControl.InjureMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
        if (nowHP == 0)
            return;
        switch (kind)
        {
            case 1:
                nowHP -= (nowHP > damage ? damage : nowHP);
                break;
            default: break;
        }
        uiControl.injuredMaskControl.Show();
        setHealthCircleAndBar();
        setHelthBehaviour();
    }

    private void setHealthCircleAndBar()
    {
        float healthRate = (float)nowHP / (float)totalHP;
        healthCircle.color = color1 * (1.0f - healthRate) + color2 * healthRate;

        uiControl.healthBarPlayerControl.Value = healthRate;
    }

    private void setHelthBehaviour()
    {
        if (nowHP == 0)
        {
            MusicLevelControl.DeadMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
            behaviourControl.Dead();
            gameEnd.OnGameEnd(false);
        }
    }
}
