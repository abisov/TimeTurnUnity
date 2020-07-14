using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum TimeState { past, present, future}
public class TimeStateManager : MonoBehaviour
{
    TimeState timeState = TimeState.present;


    
    public void changeState(int stateID)
    {
        switch (stateID)
        {
            case 0:
                timeState = TimeState.past;
                break;

            case 1:
                timeState = TimeState.present;
                break;

            case 2:
                timeState = TimeState.future;
                break;

            default:
                timeState = TimeState.present;
                break;
        }
    }



// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (timeState)
        {
            case TimeState.past:
                break;
            case TimeState.present:
                break;
            case TimeState.future:
                break;
            default:
                break;
        }
    }
}
