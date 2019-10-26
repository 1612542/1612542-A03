using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public float FollowSpeed = 2f;
    //public GameObject Target;
    public Transform Target;

    [SerializeField]
    public float xMax;
    [SerializeField]
    public float yMax;
    [SerializeField]
    public float xMin;
    [SerializeField]
    public float yMin;

    void Start()
    {
        Target = GameObject.Find("Mario").transform;
    }

    private void Update()
    {
        Vector3 newPosition = Target.transform.position;
        newPosition.z = -10;
        //transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(Target.position.x, xMin, xMax),
            Mathf.Clamp(Target.position.y, yMin, yMax), -10);
    }
}