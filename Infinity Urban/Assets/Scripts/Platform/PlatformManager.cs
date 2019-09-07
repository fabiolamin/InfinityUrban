using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    private float offSet = 0;
    public GameObject[] platforms;
    private void Start()
    {
        for(int x = 0; x < 6; x++)
        {
            InstantiatePlatform();
        }
    }

    public void  InstantiatePlatform()
    {
        int index = Random.Range(0,2);
        Instantiate(platforms[index], Vector3.forward * offSet, Quaternion.identity);
        offSet += 11.9f;
    }

    public void RecyclePlatform(GameObject platform)
    {
        platform.transform.position = Vector3.forward * offSet;
        offSet += 11.9f;
    }
}
