using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] dialoge;
    public Character[] characters;

    public void StartDialog()
    {
        FindObjectOfType<DIalogManager>().OpenDialog(dialoge, characters);
    }
}

[System.Serializable]
public class Dialog
{
    public int characterID;
    public string dialog;
}

[System.Serializable]
public class Character
{
    public string name;
    public Sprite sprite;
}