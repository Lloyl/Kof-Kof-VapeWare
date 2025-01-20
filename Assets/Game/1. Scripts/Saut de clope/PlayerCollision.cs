using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static            PlayerCollision Collision;
    [SerializeField] private Animator        anim;

    private       bool  _isHit           = false;
    private const float _delayBeforeFall = 0.0001f;

    private void Awake()
    {
        Collision = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Clope") || _isHit) return;
        
        _isHit = true;
        print("touch�");
        StartCoroutine(TriggerFallAnimation());
    }

    private IEnumerator TriggerFallAnimation()
    {
        yield return new WaitForSeconds(_delayBeforeFall);
        anim.SetBool("IsDown", true);
    }

    public bool GetIsHit()
    {
        return _isHit;
    }
}