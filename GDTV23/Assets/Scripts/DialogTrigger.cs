using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;

    // Dialog wird duurch click auf den "Trigger" (Charakter,Objekt,...) gestartet
    public void TriggerDialog ()
    {
        FindAnyObjectByType<DialogManager>().StartDialog(dialog);
    }
}
