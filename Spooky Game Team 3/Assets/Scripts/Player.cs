using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float dodgeTime;
    public float verticalDodgeLength;
    public float horizontalDodgeLength;
    public float moveCooldown;
    public int health;
    public bool isDead = false;

    private Rigidbody2D rb;
    private Vector3 position;

    private bool moved = false;
    private float moveStart = 0;
    private float startX;
    private float startY;

    public GameObject healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x;
        startY = transform.position.y;
        position = transform.position;
        healthBar = GameObject.Find("Hearts");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckForDeath();
    }

    void Move()
    {
        if (!moved || Time.time <= moveStart + .05)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moved = true;
                position[1] += verticalDodgeLength;
                moveStart = Time.time;
                transform.position = position;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                moved = true;
                position[1] -= verticalDodgeLength;
                moveStart = Time.time;
                transform.position = position;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                moved = true;
                position[0] += horizontalDodgeLength;
                moveStart = Time.time;
                transform.position = position;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                moved = true;
                position[0] -= horizontalDodgeLength;
                moveStart = Time.time;
                transform.position = position;
            }
        }
        else
        {
            if (Time.time >= moveStart + dodgeTime)
            {
                position[1] = startY;
                position[0] = startX;
                transform.position = position;
            }
            if (Time.time >= moveStart + dodgeTime + moveCooldown){
                moved = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.GetComponent<HealthBar>().RemoveHeart();
    }

    private void CheckForDeath()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        gameObject.SetActive(false);
        Destroy(this.gameObject);
        Debug.Log("Player died!");
    }
}
