using System;
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
    public Button buttonPrefab;
    
    public GameObject momSprite;
    public GameObject danaSprite;
    public GameObject kimmySprite;
    public GameObject kimmyMomSprite;
    public GameObject deanSprite;
    public GameObject lindaSprite;
    public GameObject blytheSprite;
    public GameObject janeySprite;

    public GameObject choicePanel;
    public GameObject dialoguePanel;

    public Color textColor;
    
    public Color dana;
    public Color mom;
    public Color kimmy;
    public Color kimmyMom;
    public Color dean;
    public Color donna;
    public Color blythe;
    public Color linda;
    public Color janey;
    public Color jimmy;

    public AudioSource audioSource;
    public AudioClip storeBell;
    public AudioClip store;
    public AudioClip background;
    public AudioClip playground;

    private bool atPlayground;
    private bool atStore;
    private bool atHome;

    private Vector3 danaStartLocation;
    private Vector3 momStartLocation; 

    private void Start()
    {
        atPlayground = false;
        atStore = false;
        atHome = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = background;

        audioSource.Play();
        _story = new Story(_inkJsonAsset.text);
        RemoveChildren();

        danaStartLocation = danaSprite.transform.position;
        momStartLocation = momSprite.transform.position;

        if (_story.canContinue)
        {
            string text = _story.Continue();
            text = text.Trim();
            CreateContentView(text);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _story.canContinue)
        {
            RemoveChildren();
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
        }

        if (atHome)
        {
            intro();
        }

        if (atPlayground)
        {
            audioSource.clip = playground;
            audioSource.Play();
        }

        if (atStore)
        {
            audioSource.clip = store;
            audioSource.Play();
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
    
    Button CreateChoiceView (string text) {
        // Creates the button from a prefab
        Button choice = Instantiate(buttonPrefab) as Button;
        choice.transform.SetParent(choicePanel.transform, false);
		
        // Gets the text from the button prefab
        TMP_Text choiceText = choice.GetComponentInChildren<TMP_Text> ();
        choiceText.text = text;
        choiceText.font = dialogueFont;
        
        HorizontalLayoutGroup layoutGroup = choice.GetComponent <HorizontalLayoutGroup> ();
        layoutGroup.childForceExpandHeight = false;
        
        return choice;
    }
    
    void OnClickChoiceButton(Choice choice)
    {
        if (choice.text.Equals("Store"))
        {
            audioSource.PlayOneShot(storeBell);
            atStore = true;
        }

        if (choice.text.Equals("Playground"))
        {
            atPlayground = true;
        }
        else
        {
            atPlayground = false; 
        }

        if (choice.text.Equals("Head to Kimmy's House"))
        {
            atHome = true; 
        }
        else
        {
            atHome = false;
        }
        
        _story.ChooseChoiceIndex(choice.index);
        RemoveChildren();
        
        //generate the next line of dialogue  
        if (_story.canContinue)
        {
            String text = _story.Continue();
            text = text.Trim();
            CreateContentView(text);
        }
    }
    
    void CreateContentView (string text) {
        TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
        storyText.text = text;
        storyText.font = dialogueFont;
        storyText.color = textColor;
       
        if (text.Contains("Dana:"))
        {
            danaSprite.transform.position = danaStartLocation + Vector3.up;
            momSprite.transform.position = momStartLocation;
        }
        else if (text.Contains("Mom:"))
        {
            momSprite.transform.position = momStartLocation + Vector3.up;
            danaSprite.transform.position = danaStartLocation;
        }

        storyText.transform.SetParent (dialoguePanel.transform, false);
        Debug.Log(storyText.text);
    }

    void intro()
    {
        danaSprite.SetActive(true);
        momSprite.SetActive(true);
        kimmySprite.SetActive(true);
        kimmyMomSprite.SetActive(true);
    }
    
    void kimmyHouse()
    {
        kimmySprite.SetActive(true);
        danaSprite.SetActive(true);
    }

    void setBlythe()
    {
        kimmySprite.SetActive(true);
        danaSprite.SetActive(true);
        blytheSprite.SetActive(true);
        
        momSprite.SetActive(false);
        kimmyMomSprite.SetActive(false);
        janeySprite.SetActive(false);
        lindaSprite.SetActive(false);
        deanSprite.SetActive(false);
    }
}