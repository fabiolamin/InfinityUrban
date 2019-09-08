using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 2f;
    TouchInput swipeInput;
    Transform wayPoint;
    float posX;
    void Awake()
    {
        StartCoroutine(IncreaseSpeed());
        wayPoint = this.transform;
        swipeInput = GetComponent<TouchInput>();
    }
    void Update()
    {
        GetInput();
        Run();
        CalculateDirection();
    }
    public void Run()
    {
        transform.position += new Vector3(posX, 0, 1) * speed * Time.deltaTime;
    }
    public void CalculateDirection()
    {
        Vector3 direction = (wayPoint.position - transform.position).normalized;
        posX = direction.x;
    }
    private void GetInput()
    {
        if (swipeInput.Swipe() == -1)
        {
            VerifyDirection(Vector3.left);
        }

        if (swipeInput.Swipe() == 1)
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
        while (speed < 15)
        {
            yield return new WaitForSeconds(4);
            speed++;
        }
    }
}
