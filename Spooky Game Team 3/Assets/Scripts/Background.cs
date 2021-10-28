using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public Background nextUp;

    private Vector3 position;
    private bool replicated;

    void Start()
    {
        position = transform.position;
    }


    void Update()
    {
      	position[1] -= speed;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "BackgroundDeleter" && !replicated)
        {
            Vector3 position2 = position;
            position2[1] += 51.9f;
            Instantiate(nextUp, position2, Quaternion.identity);
            replicated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.transform.tag == "BackgroundDeleter")
        {
            Debug.Log("Destroying");
            Destroy(gameObject);
        }
    }
}
