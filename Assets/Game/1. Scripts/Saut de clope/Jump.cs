using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private CharacterController _characterController;
    private Vector3 _moveDir;
    [SerializeField] private Animator anim;

    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void LateUpdate()
    {
        _moveDir = new Vector3(_moveDir.x, _moveDir.y, _moveDir.z);



#if UNITY_EDITOR || UNITY_STANDALONE // si on est sur PC
        if (Input.GetKeyDown(KeyCode.Mouse0) && _characterController.isGrounded){
            _moveDir.y = jumpForce;
        }
        #endif

        #if UNITY_ANDROID || UNITY_IPHONE // si on est sur mobile
        if(Input.touches.Length >= 1 && cc.isGrounded){
            moveDir.y = jumpForce;
        }
        #endif
        _moveDir.y -= gravity * Time.deltaTime;
        _characterController.Move(_moveDir * Time.deltaTime);

        anim.SetBool("IsGrounded", _characterController.isGrounded);
    }
}
