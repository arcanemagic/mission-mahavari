using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameRewards : MonoBehaviour
{

    public GameObject PadS;
    public GameObject BottleS;
    public GameObject AchaarS;
    public GameObject SoapS;
    public GameObject Pad;
    public GameObject Bottle;
    public GameObject Achaar;
    public GameObject Soap;
    public GameObject MButton;

    public void MenuButton()
    {
        Globals.gotAchaar = false;
        Globals.gotSoap = false;
        SceneManager.LoadScene(0);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        StartCoroutine(EndGameControl());
    }

    IEnumerator EndGameControl()
    {
        yield return new WaitForSeconds(1);
        PadS.SetActive(false);
        Pad.SetActive(true);

        yield return new WaitForSeconds(1);
        BottleS.SetActive(false);
        Bottle.SetActive(true);

        yield return new WaitForSeconds(1);
        if (Globals.gotAchaar)
        {
            AchaarS.SetActive(false);
            Achaar.SetActive(true);
            yield return new WaitForSeconds(1);
        }
        if (Globals.gotSoap)
        {
            SoapS.SetActive(false);
            Soap.SetActive(true);
            yield return new WaitForSeconds(1);
        }

        MButton.SetActive(true);
    }
}
