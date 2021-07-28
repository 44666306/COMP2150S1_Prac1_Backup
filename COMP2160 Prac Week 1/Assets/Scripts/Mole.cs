using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mole : MonoBehaviour

{
   public SpriteRenderer sprite;

    public Color startColor = new Color(1, 0, 0);
    public Color secondColor = new Color(0, 1, 0);

    public float countDownTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        //set the starting color
        sprite.color = startColor;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("mouse clicked");

        //Change the color on mouse click
        sprite.color = secondColor;
    }
}
