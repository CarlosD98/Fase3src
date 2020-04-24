using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    Rigidbody2D rb;
    BoxCollider2D Col;
    CircleCollider2D cC;
    public GameObject ground;
    public float jumpForce = 500f;
    bool jump = false;
    bool IsCrouch = false;
    
    void Start (){
        Col = GetComponent<BoxCollider2D> ();
        cC  = GetComponent<CircleCollider2D> ();
        rb = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator> ();
    }
    
    void Update()
    {
        if (GameControl.gameStopped != true)
        {
            
        
            if (cC.IsTouching(ground.GetComponent<BoxCollider2D>())){
                jump = true;
            }
            else
            {
                jump = false;
            }
            
            if (Input.GetKeyDown(KeyCode.UpArrow) && jump && !IsCrouch){
                rb.AddForce(new Vector2(0, jumpForce));
            } 
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
               
            Crouch();
            anim.SetBool("Crouch", true);
            }
            if (IsCrouch)
            {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Stand();
                anim.SetBool("Crouch", false);
            }
        }
           
        }
    }
    void Crouch()
    {
        Debug.Log("hi");
        IsCrouch = true;
        Col.size = new Vector2(Col.size.x, Col.size.y / 2);
        //SoundManagerScript.PlaySound("crouch");
    }
    void Stand()
    {
        IsCrouch = false;
        Col.size = new Vector2(Col.size.x, Col.size.y *2);
        //Col1.enabled = true;
    }
}
