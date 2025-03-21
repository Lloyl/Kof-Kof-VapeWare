using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public static            PlayerCollision Collision;
    private static readonly  int             _IS_DOWN = Animator.StringToHash("IsDown");
    [SerializeField] private Animator        anim;

    private       bool  _isHit;
    private const float _DELAY_BEFORE_FALL = 0.0001f;

    private void Awake()
    {
        Collision = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Constants.TAG_CLOPE) || _isHit) return;

        _isHit = true;
        print("touch�");
        StartCoroutine(TriggerFallAnimation());
    }

    private IEnumerator TriggerFallAnimation()
    {
        yield return new WaitForSeconds(_DELAY_BEFORE_FALL);
        anim.SetBool(_IS_DOWN, true);
    }

    public bool GetIsHit()
    {
        return _isHit;
    }
}