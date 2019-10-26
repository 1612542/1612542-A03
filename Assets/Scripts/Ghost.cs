using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Vector2 pos1, pos2;
    public float speed = 1.2f;
    public Vector2 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = transform.position;
        pos1 = transform.position;
        pos2 = new Vector2(8.21f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x == pos1.x && transform.position.y == pos1.y)
        {
            nextPos = pos2;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (transform.position.x == pos2.x && transform.position.y == pos2.y)
        {
            nextPos = pos1;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
