using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DIalogManager : MonoBehaviour
{
    public Image characterImage;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogText;
    public RectTransform dialogBox;

    Dialog[] currentDialoge;
    Character[] currentCharacters;
    int activeDialog = 0;
    public static bool isActive = false;

    public Animator animator;

    public void OpenDialog(Dialog[] dialoge, Character[] characters)
    {
        animator.SetBool("isOpen", true);
        currentDialoge = dialoge;
        currentCharacters = characters;
        activeDialog = 0;
        isActive = true;
        Debug.Log("Startet conversation! Loaded dialoge: " + dialoge.Length);
        DisplayDialog();
    }

    void DisplayDialog()
    {
        Dialog dialogToDisplay = currentDialoge[activeDialog];
        dialogText.text = dialogToDisplay.dialog;

        Character characterToDisplay = currentCharacters[dialogToDisplay.characterID];
        characterName.text = characterToDisplay.name;
        characterImage.sprite = characterToDisplay.sprite;
    }

        public void NextDialog()
    {
        activeDialog++;
        if (activeDialog < currentDialoge.Length)
        {
            DisplayDialog();
        }
        else
        {
            animator.SetBool("isOpen", false);
            Debug.Log("Conversation ended!");
            isActive = false;

        }
        //StopAllCoroutines();
        //StartCoroutine(TypeDialog(dialogText));
    }

    //IEnumerator TypeDialog (string dialog)
    //{
        //dialogText.text = "";
        //foreach (char letter in dialog.ToCharArray())
        //{
            //dialogText.text += letter;
            //yield return null;
        //}
    //}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isActive == true)
        {
            NextDialog();
        }
    }
}
