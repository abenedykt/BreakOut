using UnityEngine;
using System.Collections;

public class paddleController : MonoBehaviour {

	float yPosition = -4;
	float zPosition = 0;
	float xBoundary = 9.9f;
	float paddleWidth = 1.5f;

	public float speed = 0.1f;
	public float ballSpeed = 50;
	public GameObject ballPrefab;
	public GameObject attachedBall = null;
	public Rigidbody ballRidigbody;


	// Use this for initialization
	void Start () {
		spawnBall ();
	}
	
	// Update is called once per frame
	void Update () {
		PaddleMovement();

		if (attachedBall) {
				
			ballRidigbody = attachedBall.rigidbody;
			ballRidigbody.position = transform.position + new Vector3(0,0.3f,0);
			if(Input.GetButtonDown("Jump")){
				ballRidigbody.isKinematic = false;
				ballRidigbody.AddForce(0,ballSpeed,0);
				attachedBall = null;
			}
		}
	}

	void PaddleMovement ()
	{
		var horizontalMovemen = Input.GetAxis ("Horizontal");
		Debug.Log (horizontalMovemen);

		if (horizontalMovemen != 0) {
			transform.position = new Vector3(transform.position.x + horizontalMovemen * speed, yPosition , zPosition);

			if(transform.position.x < -xBoundary + paddleWidth){
				transform.position = new Vector3(-xBoundary+paddleWidth,yPosition,zPosition);
			}

			if(transform.position.x > xBoundary - paddleWidth){
				transform.position = new Vector3(xBoundary-paddleWidth,yPosition,zPosition);
			}
		}
	}

	void spawnBall(){
		attachedBall = Instantiate (ballPrefab,transform.position + new Vector3(0,0.5f,0),Quaternion.identity) as GameObject;
	}
}
