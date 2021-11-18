using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public Puzzle currentPuzzle;
    int solutionIndex;
    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    private void Start()
    {
        solutionIndex = GetRandomWordFromPuzzleList();
        Debug.Log(currentPuzzle.puzzleWords[solutionIndex]);
    }


    public int GetRandomWordFromPuzzleList()
    {
       return Random.Range(0, currentPuzzle.puzzleWords.Length);
    }

    public void AttemptToSolvePuzzle(GameController controller, string userInput)
    {
        if (userInput == currentPuzzle.puzzleWords[solutionIndex])
        {
            controller.LogStringWithReturn($"You won! The correct word was {currentPuzzle.puzzleWords[solutionIndex]}");
        }
        else
        {
            controller.LogStringWithReturn("Nope, that was not the correct word. Try again :)");
            controller.DisplayPuzzleWords();
        }
    }
}
