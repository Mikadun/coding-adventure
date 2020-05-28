using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    public bool isRight;

    private float height;
    private string input;

    void Start()
    {
        height = transform.localScale.y;
    }

    public void Init(bool isRightPaddle)
    {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;

        if (isRightPaddle)
        {
            pos = new Vector2(GameHandler.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "Horizontal";
        }
        else
        {
            pos = new Vector2(GameHandler.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "Vertical";

        }
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.y < GameHandler.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.y > GameHandler.topRight.y - height / 2 & move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
