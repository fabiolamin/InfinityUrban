using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speedValue;
    Animator playerAnimator;
    TouchInput touchInput;
    Transform wayPoint;
    Collider playerCollider;
    float posX;
    [SerializeField]
    int limitSpeed = 15;
    [SerializeField]
    float timeInterval = 4;
    void Awake()
    {
        playerCollider = GetComponent<Collider>();
        playerCollider.enabled = false;
        StartCoroutine(EnableCollider());
        speedValue = 4;
        StartCoroutine(IncreaseSpeed());
        wayPoint = this.transform;
        touchInput = GetComponent<TouchInput>();
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        GetInput();
        Run();
        CalculateDirection();
        playerAnimator.SetInteger("speed", speedValue);
    }
    public void Run()
    {
        transform.position += new Vector3(posX, 0, 1) * speedValue * Time.deltaTime;
    }
    public void CalculateDirection()
    {
        Vector3 direction = (wayPoint.position - transform.position).normalized;
        posX = direction.x;
    }
    private void GetInput()
    {
        if (touchInput.Swipe() == -1)
        {
            VerifyDirection(Vector3.left);
        }

        if (touchInput.Swipe() == 1)
        {
            VerifyDirection(Vector3.right);
        }
    }

    private void VerifyDirection(Vector3 direction)
    {
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray.origin, ray.direction, out hit))
        {
            if (hit.collider.gameObject.CompareTag("WayPoint"))
            {
                wayPoint = hit.collider.gameObject.transform;
            }
        }
    }

    IEnumerator IncreaseSpeed()
    {
        while (speedValue < limitSpeed)
        {
            yield return new WaitForSeconds(timeInterval);
            speedValue++;
        }
    }

    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(3);
        playerCollider.enabled = true;
    }
}
