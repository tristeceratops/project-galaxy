using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 100f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust(){
        if (Input.GetKey(KeyCode.Z) ||Input.GetKey(KeyCode.Space)){
           rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
       
        
    }

    void ProcessRotation(){
        // //gauche
        // Vector3 m_EulerAngleVelocity = new Vector3(0, 0, 7);
        // Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        // //droite
        // Vector3 m_EulerAngleVelocityD = new Vector3(0, 0, -7);
        // Quaternion deltaRotationD = Quaternion.Euler(m_EulerAngleVelocityD * Time.fixedDeltaTime);
        // if (Input.GetKey(KeyCode.Q)){
        //     rb.MoveRotation(rb.rotation * deltaRotation);
        // }
        // else if (Input.GetKey(KeyCode.D)){
        //      rb.MoveRotation(rb.rotation * deltaRotationD);
        // }

        if (Input.GetKey(KeyCode.Q)){
            ApplyRotation(rotationThrust);
        }
        else if (Input.GetKey(KeyCode.D)){
            ApplyRotation(-rotationThrust);
        }

    }

    void ApplyRotation(float rotationThisFrame){
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
