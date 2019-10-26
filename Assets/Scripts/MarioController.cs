using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioController : MonoBehaviour
{
    Vector2 pos;
    public float speed = 18f;
    public float jump = 220f;
    public int countJump = 0;
    Rigidbody2D rg2d;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rg2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CharacterJump();
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.8f, 8.8f),
            transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        CharacterMove();
    }

    void CharacterMove()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                rg2d.AddForce(new Vector2(speed, 0));
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                rg2d.AddForce(new Vector2(-speed, 0));
            }
            GetComponent<Animator>().SetBool("isRunning", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
    }

    void CharacterJump()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            if (!isJumping || countJump < 2)
            {
                countJump++;
                isJumping = true;
                rg2d.AddForce(new Vector2(0, jump));
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Grounds" || col.gameObject.tag == "enemies" || col.gameObject.tag == "boxes")
        {
            isJumping = false;
            countJump = 0;
        }
    }
}
