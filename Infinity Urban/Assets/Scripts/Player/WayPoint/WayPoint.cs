using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    void LateUpdate()
    {
        FollowTargetByZ();
    }

    public void FollowTargetByZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }
}
