using UnityEngine;

public class Player2MoveControl : MonoBehaviour
{
    public float playerMoveSpeed = 1.5f;

    private Animator robotAnimator;
    private CharacterController playerCC;

    void Start()
    {
        robotAnimator = GetComponent<Animator>();
        playerCC = GetComponent<CharacterController>();
    }

    void Update()
    {
        AnimatorStateInfo nowAnimatorStateInfo = robotAnimator.GetCurrentAnimatorStateInfo(0);
        if (JoyStickMove.joyStickPosition != Vector2.zero)
        {
            if (nowAnimatorStateInfo.IsName("anim_Idle_Loop_S") ||
            nowAnimatorStateInfo.IsName("anim_Walk_Loop"))
            {
                playerCC.Move(transform.forward * JoyStickMove.joyStickPosition.magnitude * 0.085f * Time.deltaTime * playerMoveSpeed);
                transform.LookAt(new Vector3(
                    transform.position.x + JoyStickMove.joyStickPosition.x,
                    transform.position.y,
                    transform.position.z + JoyStickMove.joyStickPosition.y));
                robotAnimator.SetFloat("Walk_Speed", JoyStickMove.joyStickPosition.magnitude * 0.01625f * playerMoveSpeed);
                robotAnimator.SetBool("Walk_Anim", true);
            }
            else if (nowAnimatorStateInfo.IsName("closed_Roll_Loop"))
            {
                playerCC.Move(transform.forward * JoyStickMove.joyStickPosition.magnitude * 0.085f * Time.deltaTime * playerMoveSpeed * 1.5f);
                transform.LookAt(new Vector3(
                    transform.position.x + JoyStickMove.joyStickPosition.x,
                    transform.position.y,
                    transform.position.z + JoyStickMove.joyStickPosition.y));
            }
        }
        else
        {
            robotAnimator.SetBool("Walk_Anim", false);
        }
    }
}
