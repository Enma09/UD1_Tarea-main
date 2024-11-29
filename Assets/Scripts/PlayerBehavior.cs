using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    //Movement, Camera Controls, and Collisions
 public float rotateSpeed = 75f;
    private float vInput;
    private float hInput;
    public float JumpVelocity = 5f;
    private bool isJumping;
    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider col;
    public GameObject Bullet;
    public float BulletSpeed=100f;
    private bool isShooting;
    // 1
    private Rigidbody _rb;
    // 2
    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        // 3
        _rb = GetComponent<Rigidbody>();
    }
    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(col.bounds.center, capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }
    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /* 4
        this.transform.Translate(Vector3.forward * vInput *
        Time.deltaTime);
        this.transform.Rotate(Vector3.up * hInput * Time.deltaTime);
        */
        isJumping |= Input.GetKeyDown(KeyCode.J);
        isShooting |= Input.GetKeyDown(KeyCode.Space);
    }
    void FixedUpdate()
    {
        if (isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            BulletRB.velocity = this.transform.forward * BulletSpeed;
            isShooting = false;
        }
        // 2
        Vector3 rotation = Vector3.up * hInput;
        // 3
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        // 4
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput *
        Time.fixedDeltaTime);
        // 5
        _rb.MoveRotation(_rb.rotation * angleRot);
        if(isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);

        }
        isJumping = false;
    }
}
