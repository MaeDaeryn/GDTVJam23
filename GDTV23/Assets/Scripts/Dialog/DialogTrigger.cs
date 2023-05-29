using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog[] dialoge;
    public Character[] characters;
    public bool canDisappear = false; //Check if the NPC disappears after a conversation
    private bool isConversationActive = false;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !isConversationActive)
        {
            // Start the dialogue here
            StartDialog();
        }
    }

    public void StartDialog()
    {
        isConversationActive = true;

        FindObjectOfType<DIalogManager>().OpenDialog(dialoge, characters);

        //If NPC can dissapear
        if (canDisappear)
        {
            EndConversation();
        }
    }

    public void EndConversation()
    {
        // Set the conversation as inactive
        isConversationActive = false;

        // Hide or disable the NPC object
        gameObject.SetActive(false);
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