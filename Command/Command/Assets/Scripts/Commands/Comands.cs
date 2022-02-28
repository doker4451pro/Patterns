using UnityEngine;

//this is an implementation of how to do it from a book through one class that will create a team like on a website https://habr.com/ru/post/463953/
public class LeftCommand : ICommand
{
    public void Execute(GameObject gameObject)
    {
        gameObject.transform.Translate(Vector3.left);
    }

    public void Undo(GameObject gameObject)
    {
        gameObject.transform.Translate(Vector3.right);
    }
}
public class RightCommand : ICommand
{
    public void Execute(GameObject gameObject)
    {
        gameObject.transform.Translate(Vector3.right);
    }

    public void Undo(GameObject gameObject)
    {
        gameObject.transform.Translate(Vector3.left);
    }
}
