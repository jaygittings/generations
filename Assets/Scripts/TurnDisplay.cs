using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnDisplay : MonoBehaviour
{
    [SerializeField] GameEvents events = null;
    [SerializeField] GameData data = null;
    [SerializeField] TextMeshProUGUI yearText = null;

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
        yearText.text = String.Format("{0} of {1}", data.Seasons, data.Year);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EndTurn()
    {
        yearText.text = String.Format("{0} of {1}", data.Seasons, data.Year);
    }
}
