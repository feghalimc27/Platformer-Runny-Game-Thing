using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    public float jumpPower;
    public string weaponProc;

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

    }
    
    void FixedUpdate() {
        rigid.velocity = movement;

        float h = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            rigid.AddForce(new Vector2(0, jumpPower));
            jump = true;
            grounded = false;
        }

        movement = new Vector2(
            speedV.x * h,
            rigid.velocity.y
        );

        // check if grounded
        if (rigid.velocity.y <= 1.0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        bool proc = Input.GetButtonDown(weaponProc);

        if (proc)
        {
            WeaponSpawn weapon = GetComponent<WeaponSpawn>();
            if (weapon != null)
            {
                weapon.Attack(false); // false because the player is not an enemy
            }
        }
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
