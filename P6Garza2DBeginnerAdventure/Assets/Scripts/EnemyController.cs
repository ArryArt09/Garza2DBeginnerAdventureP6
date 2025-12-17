using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyController : MonoBehaviour
{
    // Publics
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;

    // Privates
    Rigidbody2D rigidbody2d;
    Animator animator;
    float timer;
    int direction = 1;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }


    //I was copying off the website, instructions said I SHOULD have this?
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }


    // This is the comment for Update, but this FixedUpdate silly!
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;

        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2d.MovePosition(position);
    }



    // The damage code
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
