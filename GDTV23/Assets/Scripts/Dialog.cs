using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{

    // In einem Gespr�ch k�nnen mehrere DIalogfenster hintereinander ge�ffnet werden
    public string name;

    [TextArea(3, 10)]
    public string[] saetze;
}
