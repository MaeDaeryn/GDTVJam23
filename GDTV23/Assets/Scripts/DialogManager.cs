using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI DialogText;

    public Animator animator;

    private Queue<string> saetze;


    // Start is called before the first frame update.
    void Start()
    {
        saetze = new Queue<string>();
    }

    // Der Animator erkennt das der Dialog startet uund blendet das Dialogfenster ein und Schreibt den ersten Satz.
    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("Ist Offen", true);

        NameText.text = dialog.name;

        saetze.Clear();

        foreach (string satz in dialog.saetze)
        {
            saetze.Enqueue(satz);
        }

        DisplayNextSatz();

    }

    // der n�chste Satz wird eingelendet wenn der Dialog fortgesetzt. Die S�tze werden geschrieben uund nicht auuf einmal eingeblendet.
    public void DisplayNextSatz()
    {
        if (saetze.Count == 0)
        {
            EndDialog();
            return;
        }

        string satz = saetze.Dequeue();
        StopAllCoroutines();
        StartCoroutine(SchreibeSatz(satz));
    }

    // Buuchstaben werden nach und nach angezeigt.
    IEnumerator SchreibeSatz (string satz)
    {
        DialogText.text = "";
        foreach (char buchstabe in satz.ToCharArray())
        {
            DialogText.text += buchstabe;
            yield return null;
        }
    }

    // Dialogfensterr wird geschlossen, sobald der Dialog beendet ist.
    void EndDialog()
    {
        animator.SetBool("Ist Offen", false);
    }

}