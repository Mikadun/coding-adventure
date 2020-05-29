using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    public float speed = 10f;
    public bool isTop;

    private float width;
    private string input;

    void Start()
    {
        width = transform.localScale.x;
    }

    public void Init(bool isTopPaddle)
    {
        isTop = isTopPaddle;
        Vector2 pos = Vector2.zero;

        if (isTopPaddle)
        {
            pos = new Vector2(GameHandler.center.x, GameHandler.topRight.y);
            pos.y -= transform.localScale.y;
            input = "Horizontal";
        }
        else
        {
            pos = new Vector2(GameHandler.center.x, GameHandler.bottomLeft.y);
            pos.y += transform.localScale.y;
            input = "Vertical";

        }
        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if (transform.position.x < GameHandler.bottomLeft.x + width / 2 && move < 0)
        {
            move = 0;
        }
        if (transform.position.x > GameHandler.topRight.x - width / 2 & move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.right);
    }
}
