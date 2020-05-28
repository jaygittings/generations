using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] GameEvents events = null;
    [SerializeField] GameData data = null;

    private void Awake()
    {
        int objCount = FindObjectsOfType(GetType()).Length;
        if (objCount > 1)
        {
            this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnEnable()
    {
        events.EndTurn += EndTurn;
        events.VillagerDied += VillagerDied;
    }

    private void OnDisable()
    {
        events.EndTurn -= EndTurn;
        events.VillagerDied -= VillagerDied;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndTurn()
    {
        data.SeasonIndex++;
        //Camera.main.backgroundColor = data.GetColor();
    }

    private void VillagerDied(object sender)
    {
        Debug.Log(String.Format("Villager {0} died.", ((Person)sender).Name));
    }


}
