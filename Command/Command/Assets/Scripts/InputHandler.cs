using UnityEngine;

public static class InputHadler 
{
    private static LeftCommand leftCommand = new LeftCommand();
    private static RightCommand rightCommand = new RightCommand();
    public static ICommand HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            return leftCommand;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            return rightCommand;
        return null;
    }
}
