using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5; 
    private float horizontal;
    private Transform playerTransform;
    private Rigidbody2D rb; 
    public PlayableDirector director;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate() 
    {
        rb.velocity = new Vector2 (horizontal , 0f)* speed; 

    }
    
    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal == 0)
        {
            anim.SetBool("correr", false);
        }
        else 
        {
            anim.SetBool("correr", true);
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
        
    }
}   
