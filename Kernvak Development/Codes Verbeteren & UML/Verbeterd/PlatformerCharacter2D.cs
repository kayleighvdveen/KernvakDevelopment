using UnityEngine;
using System.Collections;

public class PlatformerCharacter2D : MonoBehaviour {

    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] float crouchSpeed = .36f;
    [SerializeField] bool airControl = false;
    [SerializeField] LayerMask whatIsGround;
    [Range(0, 1)]

    Rigidbody2D rB2D;

    bool facingRight = true;
    bool grounded = false;

    Transform groundCheck;
    Transform ceilingCheck;
    Transform playerGraphics;

    float groundedRadius = .2f;
    float ceilingRadius = .01f;

    Animator anim;

    private void Awake() {
        groundCheck = transform.Find("GroundCheck");
        ceilingCheck = transform.Find("CeilingCheck");
        anim = GetComponent<Animator>();
    }

    private void Start() {
        rB2D = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundedRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rB2D.velocity.y); 
    }

    public void Move(float move, bool crouch, bool jump) {
        if (!crouch && anim.GetBool("Crouch")) {
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
                crouch = true;
        }

        anim.SetBool("Crouch", crouch);

        if (grounded || airControl) {
            move = (crouch ? move * crouchSpeed : move); 
            anim.SetFloat("Speed", Mathf.Abs(move)); 

            rB2D.velocity = new Vector2(move * maxSpeed, rB2D.velocity.y);

            if (move > 0 && !facingRight)
            {
                Flip();
            } else if (move < 0 && facingRight) {
                Flip();
            }
        }

        if (grounded && jump) {
            anim.SetBool("Grounded", false);
            rB2D.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = playerGraphics.localScale;
        theScale.x *= -1;
        playerGraphics.localScale = theScale;
    }
}
