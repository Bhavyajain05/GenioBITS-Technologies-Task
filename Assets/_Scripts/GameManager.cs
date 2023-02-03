using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI ansText;
    [SerializeField] GameObject youWonPanel;
    [SerializeField] GameObject youLostPanel;
    [SerializeField] GameObject invalidInputText;

    RollManager rollManager;

    float timer = 60;
    int ans;
    int userInput;
    bool hasInput;


    private void Awake()
    {
        rollManager= GetComponent<RollManager>();
        ansText.text = string.Empty;
        invalidInputText.SetActive(false);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("0");
        SetValue(inputField.text);
        if (timer <= 0)
        {
            ans = rollManager.Roll();
            if(hasInput) CheckAnswer(ans);
            timer = 60;
        }
    }

    public void CheckAnswer(int ans)
    {
        ansText.text = ans.ToString();
        ansText.gameObject.SetActive(true);

        if (userInput == ans)
        {
            print("You won");
            youWonPanel.SetActive(true);
        }
        else
        {
            print("You lost");
            youLostPanel.SetActive(true);
        }
        inputField.text = string.Empty;
    }

    public void SetValue(string s)
    {
        if (int.TryParse(s, out int _userInput))
        {
            if (_userInput <= 0 || _userInput >= 10)
            {
                invalidInputText.SetActive(true);
                print("Invalid Input");
            }
            else
            {
                invalidInputText.SetActive(false);
                userInput = _userInput;
                hasInput = true;
            }
        }
    }
}