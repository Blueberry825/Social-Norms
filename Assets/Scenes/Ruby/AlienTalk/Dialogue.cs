using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{

    public string name;

    [TextArea(2, 5)]
    public string[] options;
    [TextArea(2, 5)]
    public string[] respones;
    [TextArea(2, 5)]
    public string[] actions;
}