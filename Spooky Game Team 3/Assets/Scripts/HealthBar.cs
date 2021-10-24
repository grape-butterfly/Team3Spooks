using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int currentHeart = 2; // array[SIZE - 1]
    public float heartRate = 1;

    private GameObject originalGameObject;
    private Image[] hearts = new Image[3];
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        originalGameObject = GameObject.Find("Hearts");
        hearts = originalGameObject.GetComponentsInChildren<Image>();
    }

    private void Update()
    {
        
    }

    public void RemoveHeart()
    {
        animator = hearts[currentHeart].GetComponent<Animator>(); // Switching to the next heart's animator
        animator.SetTrigger("lostHeart"); // Heart loss animation

        if (currentHeart != 0)
        {
            heartRate += 5;
            IncreaseHeartRate(heartRate);
        }

        currentHeart--;
    }

    private void IncreaseHeartRate(float currentHeartRate)
    {
        foreach (Image heart in hearts) //  <-- Increase heart rate animation for all remaining hearts
        {
            if (heart != null)
            {
                animator = heart.GetComponent<Animator>();
                animator.SetFloat("heartRateMultiplier", currentHeartRate);
            }
        }
    }
}
