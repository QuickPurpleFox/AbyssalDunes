using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;
    public PlayerMovement pM;
    private float _minPosition = -23;
    private float _maxPosition = 23;

    void Update()
    {
        Vector3 newPosition;
        if (pM.FacingRight())
        {
            newPosition = new Vector3(target.position.x + 5f, 0, -10f);
        }
        else
        {
            newPosition = new Vector3(target.position.x - 5f, 0, -10f);
        }

        var clampTransform = Mathf.Clamp(newPosition.x, _minPosition, _maxPosition);
        transform.position = Vector3.Slerp(transform.position, new Vector3(clampTransform, newPosition.y), followSpeed * Time.deltaTime);
    }
}
