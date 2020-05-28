using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void EndTurnAction();
    public delegate void VillagerDieAction(object sender);

    public event EndTurnAction EndTurn;
    public event VillagerDieAction VillagerDied;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTurnClicked()
    {
        EndTurn?.Invoke();
    }

    public void VillagerDiedTrigger(object sender)
    {
        VillagerDied?.Invoke(sender);
    }
}
