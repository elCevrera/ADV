using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{
    public void onClick()
    {
        Debug.Log("has quit game");
        Application.Quit();
    }
}
