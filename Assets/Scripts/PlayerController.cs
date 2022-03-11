using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rig;
    [SerializeField] float MSpeed = 6f;
    [SerializeField] float JForce = 5f;
    [SerializeField] Transform GCheck;
    [SerializeField] LayerMask ground;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rig.velocity = new Vector3(horizontalInput * MSpeed, rig.velocity.y, verticalInput * MSpeed);

        if (Input.GetButtonDown("Jump") && Grounded())
        {
            Jump();
        }
    }
    void Jump()
    {
        rig.velocity = new Vector3(rig.velocity.x, JForce, rig.velocity.z);       
    }
    
    bool Grounded()
    {
        return Physics.CheckSphere(GCheck.position, .1f, ground);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HeadOfEnemy"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

}
