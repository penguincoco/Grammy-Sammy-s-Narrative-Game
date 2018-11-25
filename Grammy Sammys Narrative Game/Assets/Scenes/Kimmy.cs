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
    
    private void Start()
    {
        _story = new Story(_inkJsonAsset.text);
    }

    private void Update()
    {
        if (!Input.anyKeyDown) return;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveChildren();
        }
        
        //display current choices
        if (_story.currentChoices.Count > 0)
        {
            for (int i = 0; i < _story.currentChoices.Count; i++) {
                Choice choice = _story.currentChoices [i];
                Button button = CreateChoiceView (choice.text.Trim ());
                // Tell the button what to do when we press it
                button.onClick.AddListener (delegate {
                    OnClickChoiceButton (choice);
                });
            }
//            for (var i = 0; i < _story.currentChoices.Count; i++)
//            {
//                //KeyCode.Alpha1 = 49
//                // "(KeyCode)49" casts 49 to the KeyCode enum
//                if (Input.GetKeyDown(KeyCode.Alpha1))
////                if (Input.GetKeyDown((KeyCode) 49 + i))
//                {
//                    RemoveChildren();
//                    _story.ChooseChoiceIndex(i);
//                }
//            }
        }

        if (!_story.canContinue) return;

        string text = _story.Continue();
        string choiceText = "";

        if (_story.currentChoices.Count > 0)
            foreach (var t in _story.currentChoices)
            {
                choiceText += t.text + "\n";
            }

        Debug.LogFormat("{0} with choices:\n {1}", text, choiceText);
        
        text = text.Trim();

        CreateContentView(text);

//        RemoveChildren();
    }
    
    void CreateContentView (string text) {
        TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
        storyText.text = text;
        storyText.transform.SetParent (canvas.transform, false);
    }
    
    void RemoveChildren () {
        int childCount = canvas.transform.childCount;
        for (int i = childCount - 1; i >= 0; --i) {
            GameObject.Destroy (canvas.transform.GetChild (i).gameObject);
        }
    }
    
    Button CreateChoiceView (string text) {
        // Creates the button from a prefab
        Button choice = Instantiate (buttonPrefab) as Button;
        choice.transform.SetParent (canvas.transform, false);
		
        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text> ();
        choiceText.text = text;

        // Make the button expand to fit the text
//        HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
//        layoutGroup.childForceExpandHeight = false;

        return choice;
    }

    void OnClickChoiceButton(Choice choice)
    {
        Debug.Log("Registering that a button is being pressed");
        _story.ChooseChoiceIndex(choice.index);
//        Refresh();
    }
}
