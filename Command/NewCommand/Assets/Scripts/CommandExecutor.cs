using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandExecutor : MonoBehaviour
{
    [SerializeField] private GameObject selectedGameObject;
    [SerializeField] private float timeBetweenCommands;

    private List<Command> commands;
    private Coroutine coroutine;

    private void Start()
    {
        commands = new List<Command>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ExecuteCommands();
        else
            CheakCommand();
    }
    private void CheakCommand() 
    {
        var command = InputHandler.HandleInput();
        if (command != null && coroutine == null)
            commands.Add(command);
    }

    private void ExecuteCommands() 
    {
        coroutine = StartCoroutine(Execute());
    }

    private IEnumerator Execute() 
    {
        foreach (var item in commands)
        {
            item.Execute(selectedGameObject);
            yield return new WaitForSeconds(timeBetweenCommands);
        }
        commands.Clear();
        coroutine = null;
    }
}
