using UnityEngine;
using System.Collections;


public class AnimationHandler : MonoBehaviour {

    private Animator a;
    private PlayerMovement player;

    private bool grounded;
    private bool attacking;
    private float speed;


	// Use this for initialization
	void Start () {
        player = gameObject.GetComponent<PlayerMovement>();
        a = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        grounded = player.getGrounded();
        speed = player.getSpeed();
        attacking = player.getAttacking();

        a.SetFloat("Speed", speed);
        a.SetBool("Attacking", attacking);

        

        player.setAttacking(false);
    }
}
