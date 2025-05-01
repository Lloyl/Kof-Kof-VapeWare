using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class SCJump : MonoBehaviour
{
    private static readonly int _IS_GROUNDED = Animator.StringToHash("IsGrounded");

    [SerializeField] private Animator anim;
    [SerializeField] private float    gravity;
    [SerializeField] private float    jumpForce;

    [SerializeField] private CharacterController characterController;
    private                  Vector3             _moveDir;
    private                  bool                _jumping = true;
    private                  float               _startHeight;

    private void Start()
    {
        _moveDir.y   = 0;
        _startHeight = characterController.transform.position.y;
    }

    private void LateUpdate()
    {
        var grounded = false;

        if (!_jumping)
        {
            #if UNITY_EDITOR || UNITY_STANDALONE // si on est sur PC
            if (Input.GetKeyDown(KeyCode.Mouse0))
                #else // si on est sur mobile
            if (Input.touches.Length >= 1)
                #endif
            {
                _moveDir.y = jumpForce;
                _jumping   = true;
            }
            else
            {
                grounded   = true;
                _moveDir.y = (_startHeight - characterController.transform.position.y) * Time.deltaTime;
            }
        }
        else // jumping
        {
            if (characterController.transform.position.y > _startHeight) // Above the ground
            {
                _moveDir.y -= gravity * Time.deltaTime;
            }
            else
            {
                grounded   = true;
                _jumping   = false;
                _moveDir.y = (_startHeight - characterController.transform.position.y) * Time.deltaTime;
            }
        }

        characterController.Move(_moveDir * Time.deltaTime);
        anim.SetBool(_IS_GROUNDED, grounded);
    }
}