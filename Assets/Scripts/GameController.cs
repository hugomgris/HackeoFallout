using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //cambiocommit
    [HideInInspector] public List<string> actionLog = new List<string>();
    [HideInInspector] public PuzzleManager puzzleManager;
    public Text displayText;

    SoundPlayer soundPlayer;

    private void Awake()
    {
        puzzleManager = GetComponent<PuzzleManager>();
        soundPlayer = GetComponent<SoundPlayer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            soundPlayer.PlayReturnKeySound();
        }

        if (Input.GetKeyDown("backspace"))
        {
            soundPlayer.PlayBackspaceKeySound();
        }

        if (Input.anyKeyDown)
        {
            soundPlayer.PlayRegularKeySound();
        }
    }

    private void Start()
    {
        DisplayPuzzleWords();
        DisplayLoggedtext();
    }

    public void LogStringWithReturn(string stringToAdd)
    {
        actionLog.Add(stringToAdd);
    }

    public void DisplayPuzzleWords()
    {
        for (int i = 0; i < puzzleManager.currentPuzzle.puzzleWords.Length; i++)
        {
            LogStringWithReturn(puzzleManager.currentPuzzle.puzzleWords[i]);
        }
    }

    public void DisplayLoggedtext()
    {
        string logAstext = string.Join("\n", actionLog.ToArray());
        displayText.text = logAstext;
    }
}
