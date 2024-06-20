using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public TextMeshProUGUI _text;
    public string[] lines;
    public float textDelayTime;

    private Animator boxAnim;
    public int lineIndex = 0;
    private GameObject player;
    private bool active;
    public bool typing;

    public GameObject optionBox;
    public InteractionBase interact;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        active = false;
        boxAnim = this.GetComponent<Animator>();
        
    }

    private void Update()
    {
        
    }

    public void DialogueInputs()
    {
        if (active == false)
        {
            active = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            lineIndex = 0;
            typing = true;
            boxAnim.Play("TextBoxUp");
        }
        else
        {
            if (typing == false)
            {
                if (lineIndex < lines.Length - 1)
                {
                    lineIndex++;
                    PlayText();
                }
                else
                {
                    StopAllCoroutines();
                    typing = false;
                    _text.text = lines[lineIndex];
                    //boxAnim.Play("TextBoxDown");
                    InteractManager manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
                    //manager.interactWith = null;
                    if (manager.interactWith != null)
                    {
                        manager.interactWith.GetComponent<InteractionBase>().EndDialogueEvent();
                    }
                    else
                    {
                        StopAllCoroutines();
                        typing = false;
                        _text.text = lines[lineIndex];
                        OptionNo();
                    }
                }
            }
            else
            {
                StopAllCoroutines();
                typing = false;
                _text.text = lines[lineIndex];
                //InteractManager manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
                //manager.interactWith = null;
                //manager.interactWith.GetComponent<InteractionBase>().EndDialogueEvent();
            }
        }
    }

    private void ReturnControls()
    {
        lineIndex = 0;
        active = false;
        player.GetComponent<PlayerMovement>().enabled = true;
    }

    private void PlayText()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        typing = true;
        _text.text = string.Empty;
        foreach (char c in lines[lineIndex].ToCharArray())
        {
            _text.text += c;
            yield return new WaitForSeconds(textDelayTime);
        }
        typing = false;
    }

    public void OptionYes()
    {
        interact.OptionYes();
        OptionNo();
    }

    public void OptionNo()
    {
        if(interact != null)
        {
            interact.OptionNo();
        }
        optionBox.SetActive(false);
        boxAnim.Play("TextBoxDown");
        _text.text = string.Empty;
        //InteractManager manager = GameObject.Find("InteractHitbox").GetComponent<InteractManager>();
        //manager.interactWith = null;
    }
}
