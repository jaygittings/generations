using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] GameEvents events = null;
    [SerializeField] GameData data = null;
    [SerializeField] int maxAge = 0;

    int yearBorn = 0;

    public int Age { get; set; } = 0;
    public string Name { get; set; } = "";

    private int _str = 5;
    private int _dex = 5;
    private int _int = 5;
    private int _wiz = 5;

    private Magic magic = null;
    private Job job = null;
    private Element element = null;


    private void OnEnable()
    {
        events.EndTurn += EndTurn;
    }

    private void OnDisable()
    {
        events.EndTurn -= EndTurn;
    }

    // Start is called before the first frame update
    void Start()
    {
        yearBorn = data.Year;
        Age = data.Year - yearBorn;
        Name = data.GenerateName();
        //Debug.Log("name and age: " + Name + " " + Age.ToString());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndTurn()
    {
        CheckIfDied();
    }

    private void CheckIfDied()
    {
        Age = data.Year - yearBorn;
        var deathChance = UnityEngine.Random.Range(0f, 1f);
        //Debug.Log("Random = " + deathChance.ToString());
        if ((Age > maxAge + 5) && (deathChance > .5f))
        {
            Die();
        }
        else if ((Age > maxAge + 2) && (deathChance > .75f))
        {
            Die();
        }
        else if ((Age > maxAge) && (deathChance > .8f))
        {

        }
        else
        {
            if (deathChance > .99) { Die(); }
        }
    }


    private void Die()
    {
        events.VillagerDiedTrigger(this);
        Destroy(gameObject);
    }
}
