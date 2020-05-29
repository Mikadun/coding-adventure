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

    void Start()
    {
        radius = transform.localScale.x / 2;
        Reset();
    }

    public void Init()
    {
        Reset();
    }

    public void Reset()
    {
        transform.position = new Vector2(GameHandler.center.x, GameHandler.center.y);
        direction = new Vector2(Vector2.one.normalized.x, Vector2.one.normalized.y);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < GameHandler.bottomLeft.y + radius && direction.y < 0)
            direction.y = -direction.y;
        if (transform.position.y > GameHandler.topRight.y - radius && direction.y > 0)
            direction.y = -direction.y;

        if (transform.position.x < GameHandler.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Rigt wins");
            direction = Vector2.zero;
        }

        if (transform.position.x > GameHandler.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left wins");
            direction = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Paddle")
        {
            bool isRight = collision.GetComponent<Paddle>().isRight;

            if (isRight == true && direction.x > 0)
                direction.x = -direction.x;

            if (isRight == false && direction.x < 0)
                direction.x = -direction.x;
        }
    }
}
