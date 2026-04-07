using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AliensDated_Script : MonoBehaviour
{
    public bool hasPlayerDatedThisAlien;
    public int alienNumber;
    [SerializeField] public string alienColour;

    private void Start()
    {
        hasPlayerDatedThisAlien = false;
    }
}
