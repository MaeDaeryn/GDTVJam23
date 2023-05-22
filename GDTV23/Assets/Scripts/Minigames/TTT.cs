using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TTT : MonoBehaviour
{
    public Button[] buttons; // Array to hold the game board buttons
    public Text currentPlayerText; // Text component to display the current player
    public Text winText; // Text component to display the win message

    private string currentPlayer; // Current player (X or O)
    private string[] gameBoard; // Array to hold the game board state
    private bool isGameOver; // Flag to indicate if the game is over

    private void Start()
    {
        currentPlayer = "X";
        currentPlayerText.text = "Current Player: " + currentPlayer;
        winText.gameObject.SetActive(false);

        gameBoard = new string[9];
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].onClick.AddListener(() => OnButtonClick(i));
        }
    }

    private void OnButtonClick(int index)
    {
        if (isGameOver || gameBoard[index] != null)
            return;

        gameBoard[index] = currentPlayer;
        buttons[index].GetComponentInChildren<Text>().text = currentPlayer;

        if (CheckForWin(currentPlayer))
        {
            GameOver(currentPlayer + " wins!");
        }
        else if (CheckForDraw())
        {
            GameOver("It's a draw!");
        }
        else
        {
            currentPlayer = (currentPlayer == "X") ? "O" : "X";
            currentPlayerText.text = "Current Player: " + currentPlayer;
        }
    }

    private bool CheckForWin(string player)
    {
        // TODO: Implement win condition logic here
        return false;
    }

    private bool CheckForDraw()
    {
        // TODO: Implement draw condition logic here
        return false;
    }

    private void GameOver(string message)
    {
        isGameOver = true;
        winText.text = message;
        winText.gameObject.SetActive(true);
    }

    private void ResetGame()
    {
        isGameOver = false;
        currentPlayer = "X";
        currentPlayerText.text = "Current Player: " + currentPlayer;
        winText.gameObject.SetActive(false);

        for (int i = 0; i < gameBoard.Length; i++)
        {
            gameBoard[i] = null;
            buttons[i].GetComponentInChildren<Text>().text = "";
        }
    }
}

