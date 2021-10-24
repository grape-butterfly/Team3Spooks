using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideProjectile : MonoBehaviour
{
  public float speed;
  public int damage;
  public float fireMultiplier;
  public int direction; //-1 for right to left, 1 for left to right
  public float firePosition;

  private Vector3 position;
  private bool fired = false;

  // Start is called before the first frame update
  void Start()
  {
      position = transform.position;
  }

  // Update is called once per frame
  void Update()
  {
      if(!fired){
        position[1] -= speed;
        if(position[1] <= firePosition){
          fired = true;
        }
      } else {
        position[0] += speed * fireMultiplier * direction;
      }
      transform.position = position;
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
      if(other.transform.tag == "Player")
      {
          other.GetComponent <Player>().TakeDamage(damage);
          Destroy(gameObject);
      }
      else if(other.transform.tag == "DeletionZone")
      {
          Destroy(gameObject);
      }
  }
}
