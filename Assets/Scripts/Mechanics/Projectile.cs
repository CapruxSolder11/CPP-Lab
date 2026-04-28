using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField, Range(0.5f, 10f)] private float lifetime = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVelocity(Vector2 velocity, bool isFlipped)
    { 
        GetComponent<Rigidbody2D>().linearVelocity = velocity;
        GetComponent<SpriteRenderer>().flipX = isFlipped;
    }
}
