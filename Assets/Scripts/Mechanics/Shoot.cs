using UnityEngine;

public class Shoot : MonoBehaviour
{
    private SpriteRenderer sr;

    [SerializeField] private Vector2 initialShotVelocity = new Vector2(3, 3);
    [SerializeField] private Transform spawnPointLeft;
    [SerializeField] private Transform spawnPointRight;
    [SerializeField] private Projectile projectilePrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (initialShotVelocity == Vector2.zero)
        {
            initialShotVelocity = new Vector2(3, 3);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Projectile curProjectile;

        if (!sr.flipX)
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointRight.position, Quaternion.identity);
            curProjectile.SetVelocity(initialShotVelocity, sr.flipX);
        }
        else
        {
            curProjectile = Instantiate(projectilePrefab, spawnPointLeft.position, Quaternion.identity);
             Vector2 leftVelocity = initialShotVelocity;
        leftVelocity.x *= -1;
            curProjectile.SetVelocity(leftVelocity, sr.flipX);
        }
    }

}
