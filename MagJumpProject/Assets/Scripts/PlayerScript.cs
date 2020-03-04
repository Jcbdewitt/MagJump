using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public SpriteRenderer renderer;

    public List<GameObject> Pegs = new List<GameObject>();

    private Vector2 currentVelocity;

    public Sprite CombinedMagnet;
    public Sprite PositiveMagnet;
    public Sprite NegativeMagnet;
    public Sprite NeutralMagnet;

    public float maxSpeed = 7;
    public float magSpeed = 50;
    public float jumpForce = 7;

    public bool LessonOne = false;
    public bool grounded = true;
    
    // Use this for initialization
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        bool isJumping = Input.GetKey(KeyCode.Space);

        move.x = move.x * maxSpeed * Time.deltaTime;

        rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, new Vector2(move.x, rigidbody.velocity.y), ref currentVelocity, 0.02f);

        // Initiate Jump
        if (grounded && isJumping)
        {
            grounded = false;
            rigidbody.AddForce(new Vector2(0, jumpForce));
        }

        // Cancel Jump
        if (!grounded && !isJumping && rigidbody.velocity.y > 0.01f)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, rigidbody.velocity.y * 0.95f);
        }

        bool PosPressed = false;
        bool NegPressed = Input.GetKey(KeyCode.J);

        if (!LessonOne)
        {
            PosPressed = Input.GetKey(KeyCode.K);
        }

        if (NegPressed && PosPressed)
        {
            renderer.sprite = CombinedMagnet;
        }
        else if (PosPressed)
        {
            renderer.sprite = PositiveMagnet;

            if (Pegs.Count != 0)
                Attract();
        }
        else if (NegPressed)
        {
            renderer.sprite = NegativeMagnet;
            if (Pegs.Count != 0)
                Repel();
        }
        else
        {
            renderer.sprite = NeutralMagnet;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void Attract()
    {
        
        Transform attractedObject = ReturnClosestPeg(Pegs);
        var direction = Vector2.zero;
        if (Vector2.Distance(transform.position, attractedObject.transform.position) > 0.005f)
        {
            direction = attractedObject.transform.position - transform.position;
            rigidbody.AddRelativeForce(direction.normalized * magSpeed);
        }
    }

    private void Repel()
    {
            Transform repeledObject = ReturnClosestPeg(Pegs);
            var direction = Vector2.zero;
            if (Vector2.Distance(transform.position, repeledObject.position) > 0.005f)
            {
                direction = transform.position - repeledObject.position;
                rigidbody.AddRelativeForce(direction.normalized * magSpeed);
            }

        
    }

    private Transform ReturnClosestPeg(List<GameObject> pegs)
    {
        bool firstTime = true;
        GameObject closestPeg = null;

        foreach (GameObject g in pegs)
        {
            if (firstTime)
            {
                firstTime = false;
                closestPeg = g;
            }

            if (Vector2.Distance(transform.position, g.transform.position) < Vector2.Distance(transform.position, closestPeg.transform.position))
            {
                closestPeg = g;
            }
        }

        return closestPeg.GetComponent<Transform>();
    }
}