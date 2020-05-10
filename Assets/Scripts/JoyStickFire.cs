using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public delegate void outOnDrag();
public delegate void outOnEndDrag();

public class JoyStickFire : ScrollRect
{
    public static Vector2 joyStickPosition;

    public float radius = 100.0f;

    public static outOnDrag outOnDrag01;
    public static outOnEndDrag outOnEndDrag01;

    protected override void Start()
    {
        base.Start();
        radius = content.sizeDelta.x * 0.5f;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        if (content.anchoredPosition.magnitude > radius)
            content.anchoredPosition = content.anchoredPosition.normalized * radius;
        joyStickPosition = content.anchoredPosition;

        if (outOnDrag01 != null)
            outOnDrag01();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        content.anchoredPosition = Vector2.zero;
        joyStickPosition = content.anchoredPosition;

        if (outOnEndDrag01 != null)
            outOnEndDrag01();
    }
}
