using UnityEngine;

public class Warning : MonoBehaviour
{
    [SerializeField]
    private Transform Character;
    [SerializeField]
    private Transform Obstacle;
    [SerializeField]
    public SpriteRenderer sprite;
    [SerializeField]
    private float warning_distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Obstacle.position.x - (Character.position.x + 7)) < warning_distance)
        {
            sprite.enabled = true;
        }
        else
        {
            sprite.enabled = false;
        }
    }
}
