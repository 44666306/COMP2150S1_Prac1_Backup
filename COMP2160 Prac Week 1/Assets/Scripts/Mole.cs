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

    //Used for storing fixed countdown duration
    private static float fixedCountDownTime = 5;

    //Used for counting down the dixed dueation
    private float timeToWait = fixedCountDownTime;

    //Used to keep track of random 'down' timer
    private float randomTimeToWait;

    
    //Starts in down state
    private string circleState = "down";

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        //set the starting color in 'down' state
        sprite.color = startColor;

        //Set the starting value of the random wait time
        randomTimeToWait = Random.Range(minCountDownTime, maxCountDownTime);

    }
    // Update is called once per frame
    void Update()
    {

        if (circleState == "up")
        {
            sprite.color = secondColor;

            if (timeToWait > 0)
            {
                //Stay in 'up' state for fixed duration
                timeToWait -= Time.deltaTime;
            } else
            {
                //Change to missed state
                circleState = "missed";

                timeToWait = fixedCountDownTime;

            }
        }
        
        else if (circleState == "down")
        {
            sprite.color = startColor;

            if (randomTimeToWait <= 0)
            {
                //Set state to up
                circleState = "up";

                //Reset the random timer
                randomTimeToWait = Random.Range(minCountDownTime, maxCountDownTime);

            } else
            {
                //Count down random duration
                randomTimeToWait -= Time.deltaTime;
            }

        }
        
        else if (circleState == "missed")
        {

            Debug.Log("Status is missed");

            sprite.color = missedColor;

            if (timeToWait > 0)
            {
                //Stay in 'missed' state for fixed duration
                timeToWait -= Time.deltaTime;
            }
            else
            {

                timeToWait = fixedCountDownTime;

                //Change to down state
                circleState = "down";

            }
        }
        
        else
        {

        }


    
    }

    void OnMouseDown()
    {
        Debug.Log("mouse clicked");
            
        if (circleState == "up")
        {
            circleState = "down";
        }

    }
}
