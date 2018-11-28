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
    
    
    private void Start()
    {
        _story = new Story(_inkJsonAsset.text);
        RemoveChildren();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }

        if (!_story.canContinue)
        {
            return;
        }

        string text = _story.Continue();
        text = text.Trim();
        CreateContentView(text);

        if (_story.currentChoices.Count > 0)
        {
            foreach (Choice choice in _story.currentChoices)
            {
                Button button = CreateChoiceView(choice.text.Trim());
                Choice thisChoice = choice;
                button.onClick.AddListener(delegate { OnClickChoiceButton(thisChoice); });
            }
        }

//        Debug.LogFormat("{0} with choices:\n {1}", text, choiceText);
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
    
    void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        RemoveChildren();
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
}