using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mole : MonoBehaviour

{
   public SpriteRenderer sprite;

    public Color startColor = new Color(0, 0, 0);
    public Color secondColor = new Color(1, 1, 0);
    public Color missedColor = new Color(1, 0, 0);


    public float minCountDownTime = 1;
    public float maxCountDownTime = 5;

    //Used for fixed countdown duration
    public static float fixedCountDownTime = 5;

    //Used to keep track of random 'down' timer
    private float randomTimeToWait;
    
    //Used to perform operations without modifying the fixedCountDownTime amount
    private float fixedCountDown = fixedCountDownTime;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        //set the starting color
        sprite.color = startColor;

        //Reset the timers
        ResetRandomTimer();
}

    // Update is called once per frame
    void Update()
    {

        //Circle in 'down' state while random timer > 0
        if (randomTimeToWait > 0)
        {
            sprite.color = startColor;
            randomTimeToWait -= Time.deltaTime;
        }

        //Circle in 'up' state when random timer reaches 0
        else if (randomTimeToWait <= 0)
        {
            sprite.color = secondColor;

            //Perform fixed countdown for 'up' timer
            fixedCountDown -= Time.deltaTime;

            //Missed, reset timers
            if (fixedCountDown <= 0)
            {
                sprite.color = startColor;
                randomTimeToWait -= Time.deltaTime;
                fixedCountDown = fixedCountDownTime;
            }

        }

    }

    void OnMouseDown()
    {
        Debug.Log("mouse clicked");

        if (sprite.color == startColor)
        {
            //do nothing
        }
         
        //Circle clicked while in 'up' state
        else if (sprite.color == secondColor)
        {
            sprite.color = startColor;
        }

    }

    void ResetRandomTimer()
    {
        randomTimeToWait = Random.Range(minCountDownTime, maxCountDownTime);
    }
}
