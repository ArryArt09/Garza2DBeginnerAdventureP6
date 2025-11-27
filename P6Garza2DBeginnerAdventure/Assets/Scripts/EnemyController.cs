using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public bool vertical;
public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigidbody2d;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // This is the comment for Update, but this FixedUpdate silly!
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
