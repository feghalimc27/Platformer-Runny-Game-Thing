using UnityEngine;
using System.Collections;

public class ProjMovement : MonoBehaviour {

    public Vector2 speed = new Vector2(10, 10); //Horizontal and Vertical Speed

    public Vector2 direction = new Vector2(-1, 0); //Horizontal and Vertical Direction

    private Vector2 movement; //movement variable

    void Update()
    {

        movement = new Vector2(speed.x * direction.x, speed.y * direction.y); //applies the speed and direction to the movement 
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement; //applies the movement information to the physics body
    }
}
