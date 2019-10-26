using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFlower : MonoBehaviour
{
    public Vector2 pos1, pos2;
    public float speed = 0.5f;
    public Vector2 nextPos;

    void Start()
    {
        nextPos = transform.position;
        pos1 = transform.position;
        pos2 = new Vector2(transform.position.x, -1.65f);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == pos1.x && transform.position.y == pos1.y)
        {
            nextPos = pos2;
        }
        if (transform.position.x == pos2.x && transform.position.y == pos2.y)
        {
            nextPos = pos1;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
