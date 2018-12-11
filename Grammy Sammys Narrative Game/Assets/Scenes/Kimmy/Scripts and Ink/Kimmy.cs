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
    
    public AudioSource audioSource;
    public AudioClip storeBell;
    public AudioClip store;
    public AudioClip background;
    public AudioClip playground;

    private bool atPlayground;
    private bool atStore;
    private bool atHome;
    private bool openMap;

    private bool withLinda; 

    private Vector3 danaStartLocation;
    private Vector3 momStartLocation;
    private Vector3 kimmyMomStartLocation;

    private GameObject[] characters;

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
        kimmyMomStartLocation = kimmyMomSprite.transform.position;

        if (_story.canContinue)
        {
            string text = _story.Continue();
            text = text.Trim();
            CreateContentView(text);
        }

        characters = new GameObject[]
            {momSprite, danaSprite, kimmySprite, kimmyMomSprite, deanSprite, lindaSprite, blytheSprite, janeySprite};
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
            Debug.Log("entering intro scene");
            intro();
        }

        if (atPlayground)
        {
            audioSource.clip = playground;
            audioSource.Play();
        }

        if (withLinda)
        {
            setLinda();
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
        if (choice.text.Contains("Store"))
        {
            audioSource.PlayOneShot(storeBell);
            atStore = true;
        }

        if (choice.text.Contains("Playground"))
        {
            atPlayground = true;
        }
        else
        {
            atPlayground = false; 
        }

        if (choice.text.Contains("Head to Kimmy's house"))
        {
            atHome = true; 
        }
        else
        {
            atHome = false;
        }

        if (choice.text.Contains("Linda"))
        {
            withLinda = true;
        }
        else
        {
            withLinda = false; 
        }
        
        _story.ChooseChoiceIndex(choice.index);
        RemoveChildren();
        
        //generate the next line of dialogue  
//        if (_story.canContinue)
//        {
//            String text = _story.Continue();
//            text = text.Trim();
//            CreateContentView(text);
//        }
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
        else if (text.Contains("Kimmy's Mom:"))
        {
            kimmyMomSprite.transform.position = momStartLocation + Vector3.up;
            kimmyMomSprite.transform.position = danaStartLocation;
        }

        storyText.transform.SetParent (dialoguePanel.transform, false);
        Debug.Log(storyText.text);
    }

    void intro()
    {
        Debug.Log("Kimmy's mom should be on screen");
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

    void setLinda()
    {
        Debug.Log("We're talking to Linda");
        kimmySprite.SetActive(true);
        danaSprite.SetActive(true);
        lindaSprite.SetActive(true);
        
        momSprite.SetActive(false);
        kimmyMomSprite.SetActive(false);
        janeySprite.SetActive(false);
        blytheSprite.SetActive(false);
        deanSprite.SetActive(false);
    }
}