using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{


    public Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = new Vector2(1, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x + 1, rigidbody.velocity.y);
            //rightclick
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x - 1, rigidbody.velocity.y);
            //leftClick
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.y, rigidbody.velocity.y + 1);
            //Upclick
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.y, rigidbody.velocity.y -1);
            //downclick
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
}
