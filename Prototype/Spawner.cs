using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject PersonPrefab;
    [SerializeField] Person prototypePerson;
    [SerializeField] int countPerson;
    [SerializeField] float timeBetweenSpawn;
    private void Start()
    {
        StartCoroutine(Spawn());
    }
    private IEnumerator Spawn() 
    {
        for (int i = 0; i < countPerson; i++)
        {
            var clone=Instantiate(PersonPrefab);
            clone.AddComponent<Person>().Clone(prototypePerson);
            yield return new WaitForSeconds(timeBetweenSpawn);
        }
    }
}
