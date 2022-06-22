using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueControlLevel2 : MonoBehaviour
{

    public RPGTalk rpgTalk;
    public GameObject AchaarReward;
    public GameObject SoapReward;
    public GameObject WrongAnswer;
    public GameObject Door;
    public GameObject Player;
    public TextMeshProUGUI SignText;

    // Start is called before the first frame update
    void Start()
    {
        rpgTalk.OnMadeChoice += OnMadeChoice;
        Globals.gotAchaar = false;
        Globals.gotSoap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Door.activeSelf)
        {
            if (Globals.Achaar && Globals.Soap)
            {
                if (!(AchaarReward.activeSelf || SoapReward.activeSelf || WrongAnswer.activeSelf))
                {
                    Door.SetActive(true);
                    rpgTalk.NewTalk("35", "35", rpgTalk.txtToParse);
                }
            }
        }
    }

    public void RewardAchaarStart()
    {
        AchaarReward.SetActive(true);
        Player.GetComponent<MovementInput>().TakeControls();
    }

    public void RewardAchaarEnd()
    {
        AchaarReward.SetActive(false);
        Player.GetComponent<MovementInput>().GiveControls();
    }

    public void RewardSoapStart()
    {
        SoapReward.SetActive(true);
        Player.GetComponent<MovementInput>().TakeControls();
    }

    public void RewardSoapEnd()
    {
        SoapReward.SetActive(false);
        Player.GetComponent<MovementInput>().GiveControls();
    }

    public void WhoopsWrongAnswerStart()
    {
        WrongAnswer.SetActive(true);
        Player.GetComponent<MovementInput>().TakeControls();
    }

    public void WhoopsWrongAnswerEnd()
    {
        WrongAnswer.SetActive(false);
        Player.GetComponent<MovementInput>().GiveControls();
    }

    void OnMadeChoice(string questionID, int choiceID)
    {
        if (questionID == "0")
        {
            if (choiceID == 1)
            { 
                RewardAchaarStart();
                Globals.gotAchaar = true;
            }
            else
            {
                WhoopsWrongAnswerStart();
                Globals.gotAchaar = false;
            }
            Globals.Achaar = true;
        }
        else
        {
            if (choiceID == 1)
            {
                RewardSoapStart();
                Globals.gotSoap = true;
            }
            else
            {
                WhoopsWrongAnswerStart();
                Globals.gotSoap = false;
            }
            Globals.Soap = true;
        }
    }

    public void Sign4Counter()
    {
        if (!Globals.Sign4)
        {
            Globals.Sign4 = true;
            if (SignText.text == "0/4")
            {
                SignText.text = "1/4";
                return;
            }
            if (SignText.text == "1/4")
            {
                SignText.text = "2/4";
                return;
            }
            if (SignText.text == "2/4")
            {
                SignText.text = "3/4";
            }
            else
            {
                SignText.text = "4/4";
            }
        }
    }

    public void Sign5Counter()
    {
        if (!Globals.Sign5)
        {
            Globals.Sign5 = true;
            if (SignText.text == "0/4")
            {
                SignText.text = "1/4";
                return;
            }
            if (SignText.text == "1/4")
            {
                SignText.text = "2/4";
                return;
            }
            if (SignText.text == "2/4")
            {
                SignText.text = "3/4";
            }
            else
            {
                SignText.text = "4/4";
            }
        }
    }

    public void Sign6Counter()
    {
        if (!Globals.Sign6)
        {
            Globals.Sign6 = true;
            if (SignText.text == "0/4")
            {
                SignText.text = "1/4";
                return;
            }
            if (SignText.text == "1/4")
            {
                SignText.text = "2/4";
                return;
            }
            if (SignText.text == "2/4")
            {
                SignText.text = "3/4";
            }
            else
            {
                SignText.text = "4/4";
            }
        }
    }

    public void Sign7Counter()
    {
        if (!Globals.Sign7)
        {
            Globals.Sign7 = true;
            if (SignText.text == "0/4")
            {
                SignText.text = "1/4";
                return;
            }
            if (SignText.text == "1/4")
            {
                SignText.text = "2/4";
                return;
            }
            if (SignText.text == "2/4")
            {
                SignText.text = "3/4";
            }
            else
            {
                SignText.text = "4/4";
            }
        }
    }
}
