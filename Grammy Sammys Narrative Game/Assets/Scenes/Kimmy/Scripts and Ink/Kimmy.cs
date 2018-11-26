using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class Kimmy : MonoBehaviour { 
    [SerializeField] private TextAsset _inkJsonAsset;
    [SerializeField] private Story _story;

    public TMP_Text textPrefab;
    public Canvas dialogueCanvas;
    public Canvas choiceCanvas;
    public Button buttonPrefab;
    public Button dialogueButtonPrefab;
    public GameObject momSprite;
    public GameObject danaSprite;

    private void Awake()
    {
        RemoveChildren();
        StartStory();
    }

    private void StartStory()
    {
        _story = new Story(_inkJsonAsset.text);
        RefreshView();
    }
    
    private void RefreshView()
    {
        RemoveChildren();
        
        while (_story.canContinue) {
            string text = _story.Continue ();
            text = text.Trim();
            
//            Button dialogue = CreateContentViewButton(text.Trim());
//            dialogue.onClick.AddListener(TaskOnClick);
            CreateContentView(text);
//            Button dialogue = CreateContentView(text.Trim());
//            dialogue.onClick.AddListener(TaskOnClick);
//            Button dialogueButton = CreateContentView(text);
        }
        
        //display current choices
        if (_story.currentChoices.Count > 0)
        {
            foreach (Choice choice in _story.currentChoices)
            {
                Button button = CreateChoiceView(choice.text.Trim());
                Choice thisChoice = choice;
                button.onClick.AddListener(delegate
                {
                    OnClickChoiceButton(thisChoice);
                });
            }
        }
        
        else
        {
            Button choice = CreateChoiceView("End of day 1");
            choice.onClick.AddListener(delegate{
                StartStory();
            });
        }
    }
    
    void CreateContentView (string text) {
        TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
        storyText.text = text;
        storyText.transform.SetParent (dialogueCanvas.transform, false);
       
        if (text.Contains("Dana:"))
        {
            Debug.Log("Dana speaking; text should be red");
            storyText.color = Color.red;
            danaSprite.SetActive(true);
            momSprite.SetActive(false);
        }
        else if (text.Contains("Mom:"))
        {
            Debug.Log("Mom speaking; text should be yellow");
            storyText.color = Color.yellow;
            danaSprite.SetActive(false);
            momSprite.SetActive(true);
        }
        else if (text.Contains("Kimmy:"))
        {
            Debug.Log("Kimmy speaking; text should be blue");
            storyText.color = Color.blue;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        else
        {
            storyText.color = Color.black;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        
        storyText.transform.SetParent (dialogueCanvas.transform, false);
    }
    
//    Button CreateContentView (string text)
//    {
//        Button dialogue = Instantiate(dialogueButtonPrefab) as Button;
//        dialogue.transform.SetParent(dialogueCanvas.transform, false);
//
//        TMP_Text storyText = dialogue.GetComponentInChildren<TMP_Text>();
//        storyText.text = text;
//       
//        
//        if (text.Contains("Dana:"))
//        {
//            Debug.Log("Dana speaking; text should be red");
//            storyText.color = Color.red;
//        }
//        else if (text.Contains("Mom:"))
//        {
//            Debug.Log("Mom speaking; text should be yellow");
//            storyText.color = Color.yellow;
//        }
//        else if (text.Contains("Kimmy:"))
//        {
//            Debug.Log("Kimmy speaking; text should be blue");
//            storyText.color = Color.blue;
//        }
//        else
//        {
//            storyText.color = Color.black;
//        }
        
//        storyText.transform.SetParent (dialogueCanvas.transform, false);

//        return dialogue;
//    }
    
    void RemoveChildren () {
        int dialogueChildCount = dialogueCanvas.transform.childCount;
        for (int i = dialogueChildCount - 1; i >= 0; --i) {
            GameObject.Destroy (dialogueCanvas.transform.GetChild (i).gameObject);
        }

        int choiceChildCount = choiceCanvas.transform.childCount;
        for (int i = choiceChildCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(choiceCanvas.transform.GetChild(i).gameObject);
        }
    }
    
    Button CreateChoiceView (string text) {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choiceCanvas.transform, false);
		
        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text> ();
        choiceText.text = text;

        return choice;
    }
    
    Button CreateContentViewButton (string text) {
        // Creates the button from a prefab
        Button dialogue = Instantiate(buttonPrefab) as Button;
        dialogue.transform.SetParent(dialogueCanvas.transform, false);
		
        // Gets the text from the button prefab
        TMP_Text dialogueText = dialogue.GetComponentInChildren<TMP_Text> ();
        dialogueText.text = text;

        if (text.Contains("Dana:"))
        {
            Debug.Log("Dana speaking; text should be red");
            dialogueText.color = Color.red;
        }
        else if (text.Contains("Mom:"))
        {
            Debug.Log("Mom speaking; text should be yellow");
            dialogueText.color = Color.yellow;
        }
        else if (text.Contains("Kimmy:"))
        {
            Debug.Log("Kimmy speaking; text should be blue");
            dialogueText.color = Color.blue;
        }
        else
        {
            dialogueText.color = Color.black;
        }
        
        return dialogue;
    }
    
    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }

    void TaskOnClick()
    {
        Debug.Log("clicking through dialogue");
        RefreshView();
    }
}
