using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class SCPlayer : MonoBehaviour
{
    private static readonly  int       _IS_DOWN = Animator.StringToHash("IsDown");
    [SerializeField] private Animator  animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float     _speed;

    private       bool  _isHit;
    private const float _DELAY_BEFORE_FALL = 0.0001f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Constants.TAG_CLOPE) || _isHit) return;

        _isHit = true;
        StartCoroutine(TriggerFallAnimation());
    }

    private IEnumerator TriggerFallAnimation()
    {
        yield return new WaitForSeconds(_DELAY_BEFORE_FALL);
        animator.SetBool(_IS_DOWN, true);
    }

    public bool GetIsHit()
    {
        return _isHit;
    }
}