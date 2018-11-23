using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;

public class Kimmy : MonoBehaviour
{
    [SerializeField] private TextAsset _inkJsonAsset;
    [SerializeField] private Story _story;

    public TMP_Text textPrefab;
    public Canvas canvas;
    
    private void Start()
    {
        _story = new Story(_inkJsonAsset.text);
    }

    private void Update()
    {
        if (!_story.canContinue) return;
        
        string text = _story.Continue ();
        
        while (_story.canContinue) {
            
            text = _story.Continue ();
            
            text = text.Trim();

            CreateContentView(text);
        }
        
        string thisText = _story.Continue ();
        string choiceText = "";
        if (_story.currentChoices.Count > 0)
        {
            foreach (var t in _story.currentChoices)
            {
                choiceText += t.text + "\n";
            }
            Debug.LogFormat("{0} with choices:\n {1}", thisText, choiceText);
        }
        
        if (!Input.anyKeyDown) return;

        if (_story.currentChoices.Count > 0)
        {
            for (var i = 0; i < _story.currentChoices.Count; i++)
            {
                //KeyCode.Alpha1 = 49
                // "(KeyCode)49" casts 49 to the KeyCode enum
                if (Input.GetKeyDown((KeyCode) 49 + i))
                {
                    _story.ChooseChoiceIndex(i);
                }
            }
        }
    }
    
    void CreateContentView (string text) {
        TMP_Text storyText = Instantiate (textPrefab) as TMP_Text;
        storyText.text = text;
        storyText.transform.SetParent (canvas.transform, false);
    }
}
