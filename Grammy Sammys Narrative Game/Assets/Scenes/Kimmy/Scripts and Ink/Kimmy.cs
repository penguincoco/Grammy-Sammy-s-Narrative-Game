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
    public Canvas canvas;
    public Button buttonPrefab;

    private void Awake()
    {
        RemoveChildren();
        StartStory();
        RefreshView();
    }

    private void StartStory()
    {
        _story = new Story(_inkJsonAsset.text);
    }
    
    private void RefreshView()
    {
        RemoveChildren();
//        if (!Input.anyKeyDown) return;
//
//        if (Input.GetKeyDown(KeyCode.Alpha1))
//        {
//            RemoveChildren();
//        }
        
        while (_story.canContinue) {
            // Continue gets the next line of the story
            string text = _story.Continue ();
            // This removes any white space from the text.
            text = text.Trim();
            // Display the text on screen!
            CreateContentView(text);
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
        if (text.Contains("Dana:"))
        {
            Debug.Log("Dana speaking; text should be red");
            TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
            storyText.color = Color.red;
            storyText.text = text;
            storyText.transform.SetParent (canvas.transform, false);
        }
        else if (text.Contains("Mom:"))
        {
            Debug.Log("Mom speaking; text should be yellow");
            TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
            storyText.color = Color.yellow;
            storyText.text = text;
            storyText.transform.SetParent (canvas.transform, false);
        }
        else if (text.Contains("Kimmy:"))
        {
            Debug.Log("Kimmy speaking; text should be blue");
            TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
            storyText.color = Color.yellow;
            storyText.text = text;
            storyText.transform.SetParent (canvas.transform, false);
        }
        else
        {
            TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
            storyText.color = Color.black;
            storyText.text = text;
            storyText.transform.SetParent (canvas.transform, false);
        }
    }
    
    void RemoveChildren () {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i) {
            GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
        }
    }
    
    Button CreateChoiceView (string text) {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(canvas.transform, false);
		
        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text> ();
        choiceText.text = text;

//         Make the button expand to fit the text
//        HorizontalLayoutGroup layoutGroup = choice.GetComponent<HorizontalLayoutGroup>();
//        if (layoutGroup != null)
//        {
//            Debug.Log("layout group is null");
//        }
//        else
//        {
//            Debug.Log("layout group is null");
//        }
////        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    void OnClickChoiceButton(Choice choice)
    {
        Debug.Log("Registering that a button is being pressed");
        _story.ChooseChoiceIndex(choice.index);
        RefreshView();
    }
}
