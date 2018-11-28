using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using TMPro;

public class Kimmy : MonoBehaviour { 
    [SerializeField] private TextAsset _inkJsonAsset;
    [SerializeField] private Story _story;

    public TMP_Text textPrefab;
    public TMP_FontAsset dialogueFont;
    public Canvas dialogueCanvas;
    public Canvas choiceCanvas;
    public Button buttonPrefab;
    public Button dialogueButtonPrefab;
    public GameObject momSprite;
    public GameObject danaSprite;

    public GameObject choicePanel;
    public GameObject dialoguePanel; 
    
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Load Main Menu
            Debug.Log("Returning to Main Menu");
            SceneManager.LoadScene("Main Menu");
        }
    }
    
    private void RefreshView()
    {
        RemoveChildren();
        
        while (_story.canContinue) {
            string text = _story.Continue();
            if (text.Contains("\n"))
            {
                //okay wow that didn't work at all lol oof baboof 
//                Debug.Log("Current line" + text.Substring(0, text.IndexOf("\n")));
                Debug.Log("Found a line break");
//                text = text.Substring(0, text.IndexOf("\n")).Trim();
//                CreateContentView(text);
            }
            
            text = text.Trim();
            
            //instantiate a button for the text that's different from the choice buttons?
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
    
    void RemoveChildren () {
        int dialogueChildCount = dialoguePanel.transform.childCount;
        for (int i = dialogueChildCount - 1; i >= 0; --i) {
            GameObject.Destroy (dialoguePanel.transform.GetChild (i).gameObject);
        }

        int choiceChildCount = choicePanel.transform.childCount;
        for (int i = choiceChildCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(choicePanel.transform.GetChild(i).gameObject);
        }
    }
    
    void CreateContentView (string text) {
        TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
        storyText.text = text;
        storyText.font = dialogueFont;
       
        if (text.Contains("Dana:"))
        {
            storyText.color = Color.red;
            danaSprite.SetActive(true);
            momSprite.SetActive(false);
        }
        else if (text.Contains("Kimmy's Mom:"))
        {
            storyText.color = Color.green;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        else if (text.Contains("Mom:"))
        {
            storyText.color = Color.blue;
            danaSprite.SetActive(false);
            momSprite.SetActive(true);
        }
        else if (text.Contains("Kimmy:"))
        {
            storyText.color = Color.magenta;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        else
        {
            storyText.color = Color.black;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        
        storyText.transform.SetParent (dialoguePanel.transform, false);
    }
    
    Button CreateChoiceView (string text) {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choicePanel.transform, false);
		
        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text> ();
        choiceText.text = text;
        choiceText.font = dialogueFont;
        
        if (text.Contains("Dana:"))
        {
            choiceText.color = Color.red;
            danaSprite.SetActive(true);
            momSprite.SetActive(false);
        }
        else if (text.Contains("Kimmy's Mom:"))
        {
//            choice.GetComponent<Image>().color = Color.black;
            choiceText.color = Color.green;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        else if (text.Contains("Mom:"))
        {
//            choice.GetComponent<Image>().color = Color.black;
            choiceText.color = Color.blue;
            danaSprite.SetActive(false);
            momSprite.SetActive(true);
        }
        else if (text.Contains("Kimmy:"))
        {
            choiceText.color = Color.magenta;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }
        else
        {
            choiceText.color = Color.black;
            danaSprite.SetActive(false);
            momSprite.SetActive(false);
        }

        HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
        layoutGroup.childForceExpandHeight = false;
        
        return choice;
    }
    
    
//    Button CreateContentViewButton (string text) {
//        // Creates the button from a prefab
//        Button dialogue = Instantiate(buttonPrefab) as Button;
//        dialogue.transform.SetParent(dialogueCanvas.transform, false);
//		
//        // Gets the text from the button prefab
//        TMP_Text dialogueText = dialogue.GetComponentInChildren<TMP_Text> ();
//        dialogueText.text = text;
//
//        if (text.Contains("Dana:"))
//        {
//            Debug.Log("Dana speaking; text should be red");
//            dialogueText.color = Color.red;
//        }
//        else if (text.Contains("Mom:"))
//        {
//            Debug.Log("Mom speaking; text should be yellow");
//            dialogueText.color = Color.yellow;
//        }
//        else if (text.Contains("Kimmy:"))
//        {
//            Debug.Log("Kimmy speaking; text should be blue");
//            dialogueText.color = Color.blue;
//        }
//        else
//        {
//            dialogueText.color = Color.black;
//        }
//        
//        return dialogue;
//    }
    
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
