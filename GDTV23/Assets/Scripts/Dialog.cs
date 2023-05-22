using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{

    // In einem Gespräch können mehrere DIalogfenster hintereinander geöffnet werden
    public string name;

    [TextArea(3, 10)]
    public string[] saetze;
}
