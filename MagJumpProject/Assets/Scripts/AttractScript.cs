using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractScript : MonoBehaviour
{
    public GameObject CurrentIronPeg;
    private Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (CurrentIronPeg != null)
        {
            FollowTargetWitouthRotation(CurrentIronPeg.GetComponent<Transform>(), 0.5f, 35);
        }
    }

    void FollowTargetWitouthRotation(Transform target, float distanceToStop, float speed)
    {
        var direction = Vector2.zero;
        if (Vector2.Distance(transform.position, target.position) > distanceToStop)
        {
            direction = transform.position - target.position;
            rigidbody.AddRelativeForce(direction.normalized * speed);
        }
    }
}
