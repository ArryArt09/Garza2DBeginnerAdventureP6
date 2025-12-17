using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerController : MonoBehaviour
{

                                                    // Movement
    public InputAction MoveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    public float speed = 3.0f;

                                                    // Health
    public int maxHealth = 5;
    public int health { get { return currentHealth; }}
    public int currentHealth;

                                                    // Invincibility
public float timeInvincible = 2.0f;
bool isInvincible;
float damageCooldown;
                                                    // Animation
Animator animator;
Vector2 moveDirection = new Vector2(1, 0);


    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

        Vector2 move = MoveAction.ReadValue<Vector2>();
        Debug.Log(move);
        Vector2 position = (Vector2)transform.position + move * speed * Time.deltaTime;
        transform.position = position;


        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            moveDirection.Set(move.x, move.y);
            moveDirection.Normalize();
        }

        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);


        if (isInvincible)
        {
            damageCooldown -= Time.deltaTime;
            if (damageCooldown < 0)
            {
                isInvincible = false;
            }
        }
    }


    void FixedUpdate()
    {
        //I lowkey think you should check the code when you have a better chance idk lol, -\_(:p)_/-
    }

    public void ChangeHealth (int amount)
    {
        if (amount <0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            damageCooldown = timeInvincible;
            animator.SetTrigger("Hit");
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
