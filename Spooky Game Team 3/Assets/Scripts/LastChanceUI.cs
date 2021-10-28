using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastChanceUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Display(){
        IEnumerator coroutine = Show();
        StartCoroutine(coroutine);
    }

    private IEnumerator Show(){
        Debug.Log("in Display");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        Debug.Log("Leaving display");
    }
}
