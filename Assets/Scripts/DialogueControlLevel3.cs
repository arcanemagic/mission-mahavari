using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueControlLevel3 : MonoBehaviour
{
    public RPGTalk rpgTalk;
    public GameObject Player;
    public GameObject particleHit;
    public GameObject[] AngryPeople;
    List<Animator> anim = new List<Animator>();
    private GameObject instantiatedObject;
    private bool shakeHead;
    private bool isTalking;
    public UnityEvent onShakeHead;
    public UnityEvent onReward;
    public UnityEvent onRewardFinal;
    public GameObject Door;
    public GameObject Reward;
    public TextMeshProUGUI SignText;

    // Start is called before the first frame update
    void Start()
    {
        shakeHead = false;
        isTalking = false;
        if (AngryPeople.Length >= 1)
        {
            for (int i = 0; i < AngryPeople.Length; i++)
            {
                anim.Add(AngryPeople[i].GetComponent<Animator>());
                anim[i].enabled = false;
            }
        }
        else
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isTalking)
        {
            for (int i = 0; i < AngryPeople.Length; i++)
            {
                anim[i].enabled = true;
                anim[i].SetBool("Talking", true);
            }
        }
        
        if (!isTalking)
        {
            for (int i = 0; i < AngryPeople.Length; i++)
            {
                anim[i].enabled = true;
                anim[i].SetBool("Talking", false);
            }
        }

        if (shakeHead)
        {
            for (int i = 0; i < AngryPeople.Length; i++)
            {
                anim[i].enabled = true;
                anim[i].SetBool("HeadShake", true);
            }
        }

        if (!shakeHead)
        {
            for (int i = 0; i < AngryPeople.Length; i++)
            {
                anim[i].enabled = true;
                anim[i].SetBool("HeadShake", false);
            }
        }
    }

    public void AngryDudeTakeControls()
    {
        isTalking = true;
        shakeHead = false;
    }

    public void AngryDudeGiveControls()
    {
        isTalking = false;
        shakeHead = true;
        Invoke("AngryDudeShakeHead", 3);
    }

    public void AngryDudeOnShakeHead()
    {
        isTalking = false;
        for (int i = 0; i < AngryPeople.Length; i++)
        {
            anim[i].enabled = true;
            instantiatedObject = (GameObject)Instantiate(particleHit, AngryPeople[i].transform.position, AngryPeople[i].transform.rotation);
            AngryPeople[i].SetActive(false);
            Destroy(instantiatedObject, 1.5f);
        }
        Invoke("RewardPopUp", 2);
    }

    public void AngryDudeShakeHead()
    {
        isTalking = true;
        shakeHead = false;
        rpgTalk.NewTalk("Cutscene_1_begin", "Cutscene_1_end", rpgTalk.txtToParse, onShakeHead);
    }    

    public void RewardPopUp()
    {
        rpgTalk.NewTalk("RewardStart", "RewardEnd", rpgTalk.txtToParse, onReward);
        Reward.SetActive(true);
    }

    public void AfterReward()
    {
        Reward.SetActive(false);
        rpgTalk.NewTalk("DoorStart", "DoorEnd", rpgTalk.txtToParse, onRewardFinal);
        Door.SetActive(true);
    }

    public void OnReward()
    {
        
    }

    public void Sign8Counter()
    {
        if (!Globals.Sign8)
        {
            Globals.Sign8 = true;
            if (SignText.text == "0/2")
            {
                SignText.text = "1/2";
            }
            else
            {
                SignText.text = "2/2";
            }
        }
    }

    public void Sign9Counter()
    {
        if (!Globals.Sign9)
        {
            Globals.Sign9 = true;
            if (SignText.text == "0/2")
            {
                SignText.text = "1/2";
            }
            else
            {
                SignText.text = "2/2";
            }
        }
    }
}
