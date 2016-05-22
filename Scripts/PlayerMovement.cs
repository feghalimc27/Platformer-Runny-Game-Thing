using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpPower;

    private Vector2 speedV;
    private Vector2 movement;
    private Rigidbody2D rigid;

    private bool jump;
    private bool grounded;
    private bool attacking;

    void Start() {
        speedV = new Vector2(speed, 0);
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        float h = Input.GetAxis("Horizontal");
        
        if(Input.GetButtonDown("Jump") && grounded) {
            rigid.AddForce(new Vector2(0, jumpPower));
            jump = true;
            grounded = false;
        }

        movement = new Vector2(
            speedV.x * h,
            rigid.velocity.y
        );

        // check if grounded
        if(rigid.velocity.y == 0) { grounded = true; } else { grounded = false; }

        if(Input.GetButtonDown("Fire1")) {
            attacking = true;
        }
	}
    
    void FixedUpdate() {
        rigid.velocity = movement;
    }

    public bool getGrounded() {
        return grounded;
    }
    public float getSpeed() {
        return Mathf.Abs(Input.GetAxis("Horizontal"));
    }
    public bool getAttacking() {
        return attacking;
    }
    public void setAttacking(bool yes) {
        attacking = yes;
    }
}
