using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameManager1 gmClass;

    private void Awake() // used to initialize variables
    {
        gmClass = GameObject.FindObjectOfType<GameManager1>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gmClass.MoveListener("right");
            gmClass.RightMovement();
            //rightclick
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gmClass.MoveListener("left");
            gmClass.LeftMovement();
            //leftClick
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            gmClass.MoveListener("up");
            gmClass.UpwardMovement();
            //Upclick
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            gmClass.MoveListener("down");
            gmClass.DownwardMovement();
            //downclick
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            gmClass.GenerateNewBlock();
        }

    }
   
}
