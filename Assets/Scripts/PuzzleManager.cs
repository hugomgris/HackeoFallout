using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Puzzle currentPuzzle;
    GameController controller;
    string correctWord;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    private void Start()
    {
        correctWord = currentPuzzle.puzzleWords[GetRandomWordFromPuzzleList()];
    }


    public int GetRandomWordFromPuzzleList()
    {
       return Random.Range(0, currentPuzzle.puzzleWords.Length);
    }

    public void AttemptToSolvePuzzle(GameController controller, string userInput)
    {
        int correctLetters=0;
        if (userInput == correctWord)
        {
            controller.LogStringWithReturn($"You won! The correct word was {correctWord}");
        }
        else
        {
            if (userInput.Length == correctWord.Length)
            {
                for (int i = 0; i < userInput.Length; i++)
                {
                    if (userInput[i] == correctWord[i])
                    {
                        correctLetters++;
                    }
                }
                controller.LogStringWithReturn($"Nope, that was not the correct word. You got {correctLetters} letters correct");
                controller.DisplayPuzzleWords();
            }
            else
                controller.LogStringWithReturn("Please enter a valid word");
        }
    }
}
