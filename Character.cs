using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float inputDelay = 0.5f;
    public float forwardVel = 0.1f;
    public float SideVel    = 0.1f;
    public float roatateVel = 100f;

    public float sprintmodifyer = 1;


    Quaternion targetRotation;
    Rigidbody rb;
    float forwardInput, turnInput, sideInput;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }

    public Vector3 moveDirection;

    // Use this for initialization
    void Start()
    {
        targetRotation = transform.rotation;
        rb = GetComponent<Rigidbody>();
        forwardInput = turnInput = sideInput = 0;
    }

    void getInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        turnInput    = Input.GetAxis("Mouse X");
        sideInput    = Input.GetAxis("Horizontal");
    }


    void Update()
    {
        Run();
        //Turn();
        Cursor.lockState = CursorLockMode.Locked;
        getInput();
        Jump();
        Sprint();
    }

    private void FixedUpdate()
    {
       


    }

    void Run()
    {
        //Þetta tók góða 3 klukkutíma
        //transform.Translate(-forwardInput * forwardVel * sprintmodifyer *  Time.deltaTime, 0, sideInput * SideVel * Time.deltaTime);

        //Method2
        //rb.velocity += -transform.right * forwardInput * forwardVel
        //rb.velocity += transform.forward * sideInput; 

        Vector3 _newVelocity = new Vector3();

        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            _newVelocity += -transform.right * forwardInput * forwardVel * sprintmodifyer;
        }
        else
        {

        }


        if (Mathf.Abs(sideInput) > inputDelay)
        {
            _newVelocity += transform.forward * sideInput * (sprintmodifyer * 0.5f);
        }
        else
        {

        }

        rb.velocity = _newVelocity;


    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(0, 300, 0);
        }
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprintmodifyer = 2;
        }
        else
        {
            sprintmodifyer = 1f;
        }
    }

    /*void Turn()
    {
        targetRotation *= Quaternion.AngleAxis(roatateVel * turnInput * Time.deltaTime, Vector3.up);
        transform.rotation = targetRotation;

    }*/
}
