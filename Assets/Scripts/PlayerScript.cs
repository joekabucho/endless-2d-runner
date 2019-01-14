using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public float jumpPower=10.0f;
	Rigidbody2D myRigidBody;
	private bool isGrounded=false;
	float posX=0.0f;
	bool isGameOver=false;
	GameObject ChallengeController;
	CharacterController myChallengeControler;

	// Use this for initialization
	void Start () {
		myRigidBody=transform.GetComponent<Rigidbody2D>();
		posX=transform.position.x;
		myChallengeControler=GameObject.FindObjectOfType<CharacterController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isGameOver){
            myRigidBody.AddForce(Vector3.up *(jumpPower *myRigidBody.mass *myRigidBody.gravityScale *20.0f));
		}

		if(transform.position.x<posX){
			GameOver();
		}
	}

	void Update(){

	}
	void GameOver(){
        isGameOver=true;
		
	}
	

	void OnCollisionEnter2D(Collision2D other){
		if (other.collider.tag=="Ground")
		{
          isGrounded=true;
		}
	}
	void OnCollisionStay2D(Collision2D other){
		if (other.collider.tag=="Ground")
		{
          isGrounded=true;
		}
	}
	
	void OnCollisionExit2D(Collision2D other){
		if (other.collider.tag=="Ground")
		{
          isGrounded=false;
		}
	}
}
