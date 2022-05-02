using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour
{

    private bool goUp = true;
    private readonly float maxWaitTime = 1.5f;
    private float waitTime = 0f;
    private bool stopped = true;
    [SerializeField]
    private GameObject platform;
    [SerializeField]
    private GameObject topLimit;
    [SerializeField]
    private GameObject bottomLimit;


    // Update is called once per frame
    void Update()
    {
        if (!stopped)
        {
            if (goUp)
            {
                platform.transform.localPosition = new Vector3(platform.transform.localPosition.x, platform.transform.localPosition.y + Time.deltaTime, transform.localPosition.z);
                stopped = platform.transform.localPosition.y >= topLimit.transform.localPosition.y;
            }
            else
            {
                platform.transform.localPosition = new Vector3(platform.transform.localPosition.x, platform.transform.localPosition.y - Time.deltaTime, transform.localPosition.z);
                stopped = platform.transform.localPosition.y <= bottomLimit.transform.localPosition.y;
            }
        }
        else
        {
            waitTime += Time.deltaTime;
            if (waitTime > maxWaitTime)
            {
                stopped = false;
                waitTime = 0f;
                goUp = !goUp;
            }
        }
    }
}
