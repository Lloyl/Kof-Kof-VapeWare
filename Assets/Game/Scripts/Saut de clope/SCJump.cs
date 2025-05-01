using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class SCJump : MonoBehaviour
{
    private static readonly  int                 _IS_GROUNDED = Animator.StringToHash("IsGrounded");
    private                  CharacterController _characterController;
    private                  Vector3             _moveDir;
    [SerializeField] private Animator            anim;
    private bool                                _jumping = true;
    private float _startHeight = 0;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _moveDir.y = 0;
        _startHeight = _characterController.transform.position.y;
    }

    private void LateUpdate()
    {
        //_moveDir = new Vector3(_moveDir.x, _moveDir.y, _moveDir.z);
        bool grounded = false;

        if (!_jumping)
        {
#if UNITY_EDITOR || UNITY_STANDALONE // si on est sur PC
            if (Input.GetKeyDown(KeyCode.Mouse0))
#else // si on est sur mobile
            if (Input.touches.Length >= 1)
#endif  
            {
                _moveDir.y = jumpForce;
                _jumping = true;
                grounded = false;
            }
            else
            {
                grounded = true;
                _moveDir.y = (_startHeight - _characterController.transform.position.y) * Time.deltaTime;
            }
        }
        else // jumping
        {
            if(_characterController.transform.position.y > _startHeight)    // Above the ground
            {
                _moveDir.y -= gravity * Time.deltaTime;
                grounded = false;
            }
            else
            {
                grounded = true;
                _jumping = false;
                _moveDir.y = (_startHeight - _characterController.transform.position.y) * Time.deltaTime;
            }
        }
        _characterController.Move(_moveDir * Time.deltaTime);
        anim.SetBool(_IS_GROUNDED, grounded);
    }
}
