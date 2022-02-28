using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputHandler
{
    private static Command MoveLeft = new Command((GameObject game) => game.transform.Translate(Vector3.left));
    private static Command MoveRight = new Command((GameObject game) => game.transform.Translate(Vector3.right));

    public static Command HandleInput() 
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            return MoveLeft;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            return MoveRight;
        return null;
    }
}
