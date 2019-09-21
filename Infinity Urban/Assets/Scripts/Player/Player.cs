using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speedValue = 2;
    Animator animator;
    TouchInput touchInput;
    Transform wayPoint;
    float posX;
    [SerializeField]
    int limitSpeed = 15;
    [SerializeField]
    float timeInterval = 4;
    void Awake()
    {
        StartCoroutine(IncreaseSpeed());
        wayPoint = this.transform;
        touchInput = GetComponent<TouchInput>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        GetInput();
        Run();
        CalculateDirection();
        animator.SetInteger("speed", speedValue);
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
}
