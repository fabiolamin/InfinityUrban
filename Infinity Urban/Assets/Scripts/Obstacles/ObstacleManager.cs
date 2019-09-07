using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spawnLocations;
    [SerializeField]
    private GameObject[] obstacles;
    void Start()
    {
        SpawnObstacles();
    }
    public void SwitchObstaclesPosition()
    {
        int lastPos = -1;
        var children = this.gameObject.GetComponentsInChildren<Transform>();
        foreach (var child in children)
        {
            if (child.CompareTag("Obstacle"))
            {
                int pos = Random.Range(0, spawnLocations.Length);
                while (pos == lastPos)
                {
                    pos = Random.Range(0, spawnLocations.Length);
                }
                child.transform.position = spawnLocations[pos].transform.position;
                lastPos = pos;
            }
        }
    }
    public void SpawnObstacles()
    {
            int lastPos = -1;
            for (int x = 0; x < spawnLocations.Length - 1; x++)
            {
                int pos = Random.Range(0, spawnLocations.Length);
                while (pos == lastPos)
                {
                    pos = Random.Range(0, spawnLocations.Length);
                }
                int indexObstacle = Random.Range(0, obstacles.Length);
                GameObject cloneObstacle = Instantiate(obstacles[indexObstacle], spawnLocations[pos].transform.position, Quaternion.Euler(0, 90, 0));
                cloneObstacle.transform.parent = this.transform;
                lastPos = pos;
            }
    }
}
