
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int killCount;
    public static bool playerControls;
    public static bool isShooting;
    public static bool Achaar;
    public static bool Soap;
    public static bool gotAchaar;
    public static bool gotSoap;
    public static bool doorActivate;
    public static bool Sign1;
    public static bool Sign2;
    public static bool Sign3;
    public static bool Sign4;
    public static bool Sign5;
    public static bool Sign6;
    public static bool Sign7;
    public static bool Sign8;
    public static bool Sign9;
}

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]

public class MovementInput : MonoBehaviour {

    public float Velocity;
    [Space]

	public float InputX;
	public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
	public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    private float verticalVel;
    private Vector3 moveVector;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
        Globals.playerControls = true;
        Globals.killCount = 0;
        Globals.isShooting = false;
        Globals.Achaar = false;
        Globals.Soap = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        Globals.doorActivate = true;
        Globals.Sign1 = false;
        Globals.Sign2 = false;
        Globals.Sign3 = false;
        Globals.Sign4 = false;
        Globals.Sign5 = false;
        Globals.Sign6 = false;
        Globals.Sign7 = false;
        Globals.Sign8 = false;
        Globals.Sign9 = false;
    }
	
	// Update is called once per frame
	void Update () {

        InputMagnitude();
        
        
        //isGrounded = controller.isGrounded;
        //if (isGrounded)
        //{
        //    verticalVel -= 0;
        //}
        //else
        //{
        //    verticalVel -= 1;
        //}
        //moveVector = new Vector3(0, verticalVel * .2f * Time.deltaTime, 0);
        //controller.Move(moveVector);


    }

    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
		}
	}

    public void GiveControls()
    {
        Globals.playerControls = true;
        Cursor.visible = false;
    }

    public void TakeControls()
    {
        Globals.playerControls = false;
        Cursor.visible = true;
    }

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), desiredRotationSpeed);
    }

    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

	void InputMagnitude() {
        //Calculate Input Vectors
        if (Globals.playerControls)
        {
            InputX = Input.GetAxis("Horizontal");
            InputZ = Input.GetAxis("Vertical");
        }
        else
        {
            InputX = 0;
            InputZ = 0;
        }
        

		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

        anim.SetFloat("PosY", transform.position.y);
        if (Globals.playerControls)
        {
            if (Speed > allowPlayerRotation)
            {
                anim.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
                PlayerMoveAndRotation();
            }
            else if (Speed < allowPlayerRotation)
            {
                anim.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
            }
        }
        else
        {
            anim.SetFloat("Blend", Speed, 0, Time.deltaTime);
        }
		
	}
}
