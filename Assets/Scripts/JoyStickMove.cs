using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStickMove : ScrollRect
{
    public static Vector2 joyStickPosition;

    public float radius = 100.0f;

    private bool joyStickIsOnDrag;

    protected override void Start()
    {
        base.Start();
        radius = content.sizeDelta.x * 0.5f;
    }

    void Update()
    {
        if (joyStickIsOnDrag) return;

        Vector2 tempPosition = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            tempPosition += Vector2.up * radius;
        }
        if (Input.GetKey(KeyCode.S))
        {
            tempPosition += Vector2.down * radius;
        }
        if (Input.GetKey(KeyCode.A))
        {
            tempPosition += Vector2.left * radius;
        }
        if (Input.GetKey(KeyCode.D))
        {
            tempPosition += Vector2.right * radius;
        }

        joyStickPosition = tempPosition;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        joyStickIsOnDrag = true;
        if (content.anchoredPosition.magnitude > radius)
            content.anchoredPosition = content.anchoredPosition.normalized * radius;
        joyStickPosition = content.anchoredPosition;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        joyStickIsOnDrag = false;
        content.anchoredPosition = Vector2.zero;
        joyStickPosition = content.anchoredPosition;
    }
}
