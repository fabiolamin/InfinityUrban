using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private PlatformManager platformManager;
    private bool isCounting = false;
    private float timer = 0.35f;
    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("PlatformManager");
        platformManager = gameObject.GetComponent<PlatformManager>();
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
            timer = 0.35f;
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
