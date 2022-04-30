using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform Player;

    private Vector3 offset;

    private void Start()
    {
        offset = Player.transform.position - transform.position;
    }

    private void Update()
    {
        transform.position = Player.position - offset;
    }
}
