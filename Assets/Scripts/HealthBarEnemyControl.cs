using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemyControl : MonoBehaviour
{
    private Slider slider;
    private Image fill;

    private Color color1 = new Color(255 / 255.0f, 100 / 255.0f, 110 / 255.0f);
    private Color color2 = new Color(125 / 255.0f, 255 / 255.0f, 100 / 255.0f);

    void Start()
    {
        slider = GetComponent<Slider>();
        fill = transform.Find("Fill").GetComponent<Image>();

        fill.color = color2;
    }

    public float Value
    {
        set
        {
            slider.value = value;
            fill.color = color1 * (1.0f - value) + color2 * value;
            gameObject.SetActive(value > 0.0f);
        }
    }
}
