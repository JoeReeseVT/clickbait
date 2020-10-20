using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPickup : MonoBehaviour
{
    public GameObject word;
    public AudioSource pickUpSound;
    public double bouncePeriod;
    public double liftDuration;  // Point when the parabola flattens out
    public double liftDistance;

    private Rigidbody2D wordRigidbody;
    private SpriteRenderer wordSprite;
    private Vector2 position;
    private float startY;
    private int state;
    private double liftVelo;
    private double liftDeltaT;
    private double liftStartTime;
    private Color spriteColor;

    private const int UNCOLLECTED = 0, FADE_STARTED = 1, DISABLED = 2;

    // Start is called before the first frame update
    void Start()
    {
        wordRigidbody = word.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        wordSprite = word.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteColor = wordSprite.GetComponent<SpriteRenderer>().color;

        position = new Vector2(wordRigidbody.position.x, wordRigidbody.position.y);

        startY = position.y;
        state = 0; 

        liftVelo = liftDistance / liftDuration;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state) {

            case UNCOLLECTED:
                position.y = startY + (float)Math.Sin(2 * Math.PI * Time.time / bouncePeriod);
                wordRigidbody.MovePosition(position);
                break;

            case FADE_STARTED:
                liftDeltaT = Time.time - liftStartTime;
                if (liftDeltaT <= liftDuration)
                {
                    spriteColor.a = (float)(1 - liftDeltaT / liftDuration);
                    wordSprite.GetComponent<SpriteRenderer>().color = spriteColor;

                    position.y = (float)(liftVelo * liftDeltaT + startY);
                    wordRigidbody.MovePosition(position);
                }
                break;

            case DISABLED:  // Fall through to default
            default:
                break;  // Do nothing
        }
    }

    void OnTriggerEnter2D()
    {
        switch(state)
        {
            case UNCOLLECTED:
                pickUpSound.Play();
                startY = position.y;
                state = FADE_STARTED;
                liftStartTime = Time.time;
                break;

            case FADE_STARTED:
            case DISABLED:
            default:
                break;
        }
    }
}
