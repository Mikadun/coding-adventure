using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Ball ball;
    public Paddle paddle;
    public float offset = 10f;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    public static Vector2 center;
    void Start()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2 + offset, offset));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - offset, Screen.height - offset));
        center = Camera.main.ScreenToWorldPoint(new Vector2(3 * Screen.width / 4, Screen.height / 2));

        Instantiate(ball);
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true);
        paddle2.Init(false);
    }

    private void Update()
    {
        if (Input.GetButton("Submit"))
        {
            Debug.Log("Submit");
            ball.Reset();
        }
    }
}
