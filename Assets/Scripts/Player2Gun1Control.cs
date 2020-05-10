using UnityEngine;
using UnityEngine.UI;

public class Player2Gun1Control : MonoBehaviour
{
    private Animator playerAnimator;
    private Image aimArrowImage;

    public GameObject bulletPrefab;

    private Vector2 lastPosition;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        aimArrowImage = transform.Find("Canvas2/aimArrowImage").GetComponent<Image>();
        JoyStickFire.outOnDrag01 = new outOnDrag(RecordDirection);
        JoyStickFire.outOnEndDrag01 = new outOnEndDrag(Fire);
    }

    void Update()
    {
        Vector2 tempPosition = JoyStickFire.joyStickPosition;
        if (tempPosition != Vector2.zero)
        {
            aimArrowImage.enabled = true;
            aimArrowImage.transform.LookAt(aimArrowImage.transform.position + new Vector3(tempPosition.x, 0.0f, tempPosition.y));
            aimArrowImage.transform.eulerAngles += Vector3.right * 90;
        }
        else
        {
            aimArrowImage.enabled = false;
        }
    }

    private void RecordDirection()
    {
        if (JoyStickFire.joyStickPosition.normalized.magnitude >= 0.1f)
            lastPosition = JoyStickFire.joyStickPosition.normalized;
    }

    private void Fire()
    {
        AnimatorStateInfo nowAnimatorStateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);
        if (nowAnimatorStateInfo.IsName("anim_Idle_Loop_S") ||
            nowAnimatorStateInfo.IsName("anim_Walk_Loop"))
        {
            float fireBirthRadius = 1.5f;
            Vector3 tempBulletBirthPosition = new Vector3(
                transform.position.x + lastPosition.x * fireBirthRadius,
                transform.position.y + 1.0f,
                transform.position.z + lastPosition.y * fireBirthRadius
            );
            GameObject tempBullet = Instantiate(bulletPrefab, tempBulletBirthPosition, Quaternion.identity);
            tempBullet.transform.LookAt(new Vector3(
                tempBullet.transform.position.x + lastPosition.x * fireBirthRadius,
                tempBullet.transform.position.y,
                tempBullet.transform.position.z + lastPosition.y * fireBirthRadius
            ));
            MusicLevelControl.FireMusicPlay(true, GameObject.FindWithTag("MainCamera").transform.position);
        }
    }
}
