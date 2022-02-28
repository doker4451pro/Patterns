using UnityEngine;

public interface ICommand 
{
    void Execute(GameObject gameObject);
    void Undo(GameObject gameObject);
}
