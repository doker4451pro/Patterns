using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private List<ICommand> commands = new List<ICommand>();
    private Coroutine coroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExecuteCommands();
        else
            CheakForCommands();
    }
    private void ExecuteCommands() 
    {
        coroutine = StartCoroutine(MoveCoroutine());
    }
    private IEnumerator MoveCoroutine() 
    {
        for (int i = 0; i < commands.Count; i++)
        {
            commands[i].Execute(gameObject);
            yield return new WaitForSeconds(1);
        }
        commands.Clear();
        coroutine = null;
    }
    private void CheakForCommands() 
    {
        var command = InputHadler.HandleInput();
        if (command != null && coroutine==null) 
        {
            commands.Add(command);
        }
    }
}
