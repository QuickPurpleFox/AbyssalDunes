using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;

    void Update()
    {
        Vector3 newPosition = new Vector3(target.position.x, 0, -10f);
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
