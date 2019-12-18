using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShoot : MonoBehaviour {

	Vector3 direction;
	public float speed;
	public float offset;
	public int maxJump = 3;
	public int currentJump;
	bool slow = false;
	float horizontalMove = 5f;
	public float timeSlowMultiplyer = 4f;
	bool jump = false; 
	public float runSpeed;
	
	


//	public TimeManager timeManager;
	public CharacterController2D controller;

	

	
	void Start() {
		currentJump = maxJump;
	}


	
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

		if(currentJump >= 0){
			//PlayerMove();
		}

		Jump();

		/* if(Input.GetKeyDown(KeyCode.Space)){
			Time.timeScale = 0;
		}*/

		 if (Input.GetKey(KeyCode.Space)) {
			 Time.timeScale = 1 / timeSlowMultiplyer; //timeSlowMultiplyer is
				Debug.Log("Space Pressed");
			 } else {
			 Time.timeScale = 1;
		 	}
	}

	private void FixedUpdate() {
		controller.Move(horizontalMove * (Time.fixedDeltaTime), false, jump);
		jump = false;
	}

	private void Jump(){
		if(Input.GetButtonDown("Vertical"))
		{
			Debug.Log("Jump");
			jump = true;
		}
	}

	/* void PlayerMove(){
			if(Input.GetButtonUp("Fire2") ){
		
			Time.timeScale = 1f;
			Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
			direction.z = 0;
			direction = direction.normalized;

			float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

			GetComponent<Rigidbody2D>().velocity = direction * speed;
			
			

		}	else if(Input.GetButtonDown("Fire2"))
		{
			currentJump--;	
			Debug.Log(maxJump);
			//timeManager.DoSlowMotion();
			
		}
	}*/



}
