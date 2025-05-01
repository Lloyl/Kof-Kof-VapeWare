using UnityEngine;

public class SCWarning : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private Transform obstacle; 
    [SerializeField] public SpriteRenderer sprite;
    [SerializeField] private float warningDistance;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        sprite.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        sprite.enabled = Mathf.Abs(obstacle.position.x - (character.position.x + 7)) < warningDistance;
    }
}
