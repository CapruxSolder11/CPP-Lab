using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float minPos;
    [SerializeField] private float maxPos;

    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform;
        }

        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target == null) { return; }

        Vector3 currentPos = transform.position;

        currentPos.x = Mathf.Clamp(target.position.x, minPos, maxPos);

        transform.position = Vector3.MoveTowards(transform.position, currentPos, 7f * Time.deltaTime);
    }
}
