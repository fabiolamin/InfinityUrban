using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platformManager;
    private ObstacleManager obstacleManager;
    private bool isCounting = false;
    private float timer = 1.5f;
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("PlatformManager");
        platformManager = gameObject.GetComponent<PlatformManager>();

        obstacleManager = GetComponent<ObstacleManager>();
    }

    private void Update()
    {
        if(isCounting)
        {
            Countdown();
        }
    }

    void Countdown()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            platformManager.RecyclePlatform(this.gameObject);
            obstacleManager.SwitchObstaclesPosition();
            timer = 0.7f;
            isCounting = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCounting = true;
        }
    }
}
