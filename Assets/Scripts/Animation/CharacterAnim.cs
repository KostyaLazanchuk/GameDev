using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAnim : MonoBehaviour
{

    [SerializeField] private Joystick _joystick;
    [SerializeField] private Button _jumpButton;

    public float HorizontalDirection => _joystick.Horizontal;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        _jumpButton.onClick.AddListener(Jump);
    }

    void Update()
    {

        float keyboardInput = Input.GetAxisRaw("Horizontal");

        float direction = Mathf.Abs(keyboardInput) > Mathf.Abs(HorizontalDirection) ? keyboardInput : HorizontalDirection;

        if (direction != 0)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("IsJump");
        }
    }

    void Jump()
    {
        anim.SetTrigger("IsJump");
    }
}
