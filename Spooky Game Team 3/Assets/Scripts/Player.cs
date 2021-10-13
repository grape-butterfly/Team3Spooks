using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float dodgeTime;
    public float verticalDodgeLength;
    public float horizontalDodgeLength;
    public int health;

    private Rigidbody2D rb;
    private Vector3 position;

    private bool vMoved = false;
    private bool hMoved = false;
    private float vMoveStart = 0;
    private float hMoveStart = 0;
    private float startX;
    private float startY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x;
        startY = transform.position.y;
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Debug.Log(health);
    }

    void Move()
    {
        if (!vMoved)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                vMoved = true;
                position[1] += verticalDodgeLength;
                vMoveStart = Time.time;
                transform.position = position;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                vMoved = true;
                position[1] -= verticalDodgeLength;
                vMoveStart = Time.time;
                transform.position = position;
            }
        }
        else
        {
            if (Time.time >= vMoveStart + dodgeTime)
            {
                vMoved = false;
                position[1] = startY;
                transform.position = position;
            }
        }

        if (!hMoved)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                hMoved = true;
                position[0] += horizontalDodgeLength;
                hMoveStart = Time.time;
                transform.position = position;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                hMoved = true;
                position[0] -= horizontalDodgeLength;
                hMoveStart = Time.time;
                transform.position = position;
            }
        }
        else
        {
            if (Time.time >= hMoveStart + dodgeTime)
            {
                hMoved = false;
                position[0] = startX;
                transform.position = position;
            }
        }
    }


}
