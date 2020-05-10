using UnityEngine;

public class UIControl : MonoBehaviour
{
    public HintTextControl hintTextControl;
    public HealthBarEnemyControl healthBarEnemyControl;
    public HealthBarPlayerControl healthBarPlayerControl;
    public InjuredMaskControl injuredMaskControl;
    public PausePanelControl pausepanelControl;
    public StartShowTextControl startShowTextControl;
    public GameEnd gameEnd;
    public CountPanelControl countPanelControl;

    public static UIControl instance;

    void Start()
    {
        instance = this;

        hintTextControl = transform.Find("HintText").GetComponent<HintTextControl>();
        startShowTextControl = transform.Find("开始动画").GetComponent<StartShowTextControl>();
        healthBarEnemyControl = transform.Find("HealthBarEnemy").GetComponent<HealthBarEnemyControl>();
        healthBarPlayerControl = transform.Find("HealthBarPlayer").GetComponent<HealthBarPlayerControl>();
        injuredMaskControl = transform.Find("InjuredMask").GetComponent<InjuredMaskControl>();
        pausepanelControl = transform.Find("PausePanel").GetComponent<PausePanelControl>();
        countPanelControl = transform.Find("CountPanel").GetComponent<CountPanelControl>();
        gameEnd = transform.Find("Dialog").GetComponent<GameEnd>();
    }
}
