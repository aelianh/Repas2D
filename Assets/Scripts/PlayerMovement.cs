using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb; 
    public PlayableDirector director;
    public Animator anim;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate() 
    {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y); 

    }
    
    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal == 0)
        {
            anim.SetBool("correr", false);
        }
        if (horizontal == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("correr", true);
        }
        if (horizontal == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("correr", true);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Salto", true);
        }
        // playerTransform.position += new Vector3 (1, 0, 0)* horizontal * speed * Time.deltaTime;
        //playerTransform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0, 0);
        //playerTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);

    }
    void OnTriggerEnter2D(Collider2D other) 
    {   
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play(); 
        }
        if(other.gameObject.tag == "Bomba")
        {
            GameManager.Instance.RestarVidas();
            Destroy(other.gameObject);
            StartCoroutine(GameObject.Find("Main Camera").GetComponent<CameraShake>().Shake(1F, 0.05F));
           
        }
        
    }
}   
