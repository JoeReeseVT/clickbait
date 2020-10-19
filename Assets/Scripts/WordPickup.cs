using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordPickup : MonoBehaviour
{
    public GameObject word;
    public AudioSource pickUpSound;
    public double bouncePeriod;

    private Rigidbody2D wordRigidbody;
    private SpriteRenderer wordSprite;
    private Vector2 position;
    private float startY;
    private bool hasPlayed;

    // Start is called before the first frame update
    void Start()
    {
        wordRigidbody = word.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        wordSprite = word.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        position = new Vector2(wordRigidbody.position.x, wordRigidbody.position.y);

        startY = position.y;
        hasPlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        position.y = startY + (float)Math.Sin(2 * Math.PI * Time.time / bouncePeriod);
        wordRigidbody.MovePosition(position);
    }

    void OnTriggerEnter2D()
    {
        wordSprite.enabled = false;
        if (!hasPlayed) {
            pickUpSound.Play();
            hasPlayed = true;
        }
    }
}
