using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInput : MonoBehaviour
{
    public InputField inputField;
    GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        inputField.onEndEdit.AddListener(AcceptUserInput);
    }

    public void AcceptUserInput (string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);
        controller.puzzleManager.AttemptToSolvePuzzle(controller, userInput);
        InputComplete();
    }
    
    public void InputComplete()
    {
        controller.DisplayLoggedtext();
        inputField.text = null;
        inputField.ActivateInputField();
    }
}
