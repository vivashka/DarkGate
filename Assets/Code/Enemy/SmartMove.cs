using UnityEngine;

public class SmartMove : MonoBehaviour
{
    public float speed = 1.5f;

    public Transform target;

    public float detectionRadius = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= detectionRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position,
            target.position, speed * Time.deltaTime);
        }
        
    }
}
