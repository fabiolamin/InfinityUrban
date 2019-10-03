using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private Vector3 offset;
    private Vector3 desiredPosition;

    private void Awake()
    {
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, desiredPosition.z), 1f);
    }
}
