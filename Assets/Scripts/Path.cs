using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject obj;
    public GameObject[] pathPoints;
    public int numberOfPoints;
    public float speed;

    private Vector3 velocity;
    private int x;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = obj.transform.position;
        obj.transform.position = Vector3.MoveTowards(velocity, pathPoints[x].transform.position, speed * Time.deltaTime);

        if(velocity == pathPoints[x].transform.position && x != numberOfPoints - 1)
        {
            x++;
        }
    }
}
