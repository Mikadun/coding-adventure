using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 direction;
    private float radius;
    private bool gameOver;
    public float incSpeed = 0.01f;

    void Start()
    {
        radius = transform.localScale.x / 2;
        Init();
    }

    public void Init()
    {
        transform.position = new Vector2(GameHandler.center.x, GameHandler.center.y);
        direction = new Vector2(Random.value, Random.value).normalized;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
            Init();

        if (gameOver)
            return;

        transform.Translate(direction * speed * Time.deltaTime);
        speed += incSpeed;

        if (transform.position.x < GameHandler.bottomLeft.x + radius && direction.x < 0)
            direction.x = -direction.x;
        if (transform.position.x > GameHandler.topRight.x - radius && direction.x > 0)
            direction.x = -direction.x;

        if (transform.position.y < GameHandler.bottomLeft.y + radius && direction.y < 0)
        {
            Debug.Log("Rigt wins");
            gameOver = true;
        }

        if (transform.position.y > GameHandler.topRight.y - radius && direction.y > 0)
        {
            Debug.Log("Left wins");
            gameOver = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Paddle")
        {
            bool isTop = collision.GetComponent<Paddle>().isTop;

            if (isTop == true && direction.y > 0)
                direction.y = -direction.y;

            if (isTop == false && direction.y < 0)
                direction.y = -direction.y;
        }
    }
}
