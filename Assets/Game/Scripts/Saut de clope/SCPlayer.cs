using System.Collections;
using UnityEngine;

public class SCPlayer : MonoBehaviour
{
    private static readonly int _IS_DOWN = Animator.StringToHash("IsDown");

    [SerializeField] private Animator  animator;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float     speed;

    public bool isHit { get; private set; }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(Constants.TAG_CLOPE) || isHit) return;

        isHit = true;
        StartCoroutine(LoseAnimation());
    }
    
    private IEnumerator LoseAnimation()
    {
        animator.SetBool(_IS_DOWN, true);
        yield return new WaitForSeconds(0.6f);
        speed = 0.15f;
    }
}