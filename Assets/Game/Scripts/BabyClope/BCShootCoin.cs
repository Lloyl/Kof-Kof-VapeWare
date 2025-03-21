using UnityEngine;

public class BCShootCoin : MonoBehaviour
{
    private static readonly int _SHOOT = Animator.StringToHash("Shoot");

    [SerializeField] private Animator animator;

    // Update is called once per frame
    // private void Update()
    // {
    //     #if UNITY_EDITOR || UNITY_STANDALONE // si on est sur PC
    //     if (!Input.GetKeyDown(KeyCode.Mouse0)) return;
    //
    //     // AudioManager.Instance.PlayAudio("Tir Baby");
    //     animator.SetBool(_SHOOT, true);
    //     #endif
    //
    //     #if UNITY_ANDROID || UNITY_IPHONE // si on est sur mobile
    //     if(Input.touches.Length < 1) return;
    //     
    //     AudioManager.Instance.PlayAudio("Tir Baby");
    //     animator.SetBool(_SHOOT, true);
    //     #endif
    // }
}