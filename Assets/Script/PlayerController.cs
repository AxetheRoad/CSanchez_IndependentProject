using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float gravity = 9.8f;
    public float jumpSpeed = 50.0f;
    public GameObject energyBalls;
    public int maxHealth = 100;
    public int currentHealth;

    private float horizontalInput;
    private float verticalInput;

    Rigidbody rb;
    bool canJump;
    bool canDoubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
      //  enemyDamage.OnTriggerEnter(Collider other);

        //Check playe is on the floor
    }
    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.tag == "Floor")
            {
                canJump = true;
            }
        

    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Floor")
        {
            canJump = false;
        }
    }

    void Jump()
    {
        rb.AddForce(0f, jumpSpeed * gravity, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
       
    
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(canJump)
            {
              
                Jump();
                canDoubleJump = true;

            }
             else if (canDoubleJump)
            {
                jumpSpeed = jumpSpeed / 1.5f;
                Jump();
                canDoubleJump = false;
                jumpSpeed = jumpSpeed * 1.5f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Comma))
        {
            Instantiate(energyBalls, transform.position, energyBalls.transform.rotation);
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
     

    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
