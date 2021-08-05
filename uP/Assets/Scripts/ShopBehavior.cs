using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ShopBehavior : MonoBehaviour
{
    public static int option1 = 1;
    public static int option2;
    public static int option3;
    [SerializeField] GameObject buttonEquip;
    [SerializeField] GameObject Choosed;
    [SerializeField] TextMeshProUGUI textPoints;
    [SerializeField] Text pressRight;
    public float sumirTexto = 4f;

    public static int points2;
    public static bool Verify = false;
    public static bool Verify2 = false;
    public int zero = 0;

    void Awake()
    {
        textPoints.text = points2.ToString();
        //pressRight.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject theChanger = GameObject.Find("Player");
        Changer changer = theChanger.GetComponent<Changer>();
        StartCoroutine("sumirTex");
    }

    // Update is called once per frame
    void Update()
    {
        CharChoice();
        DeleteData();
    }

    public void Equiper()
    {   
        if(Changer.avatar == 0)
        {
            Choosed.SetActive(true);
            buttonEquip.SetActive(false);
            Debug.Log("Works.");
            option1 = 1;
            option2 = 0;
            option3 = 0;
        }
        else if(Changer.avatar == 1)
        {
            if(Verify == true)
            {
                Choosed.SetActive(true);
                buttonEquip.SetActive(false);
                option1 = 0;
                option2 = 1;
                option3 = 0;
            }
        }
        else
        {
            if(Verify2 == true)
            {
                Choosed.SetActive(true);
                buttonEquip.SetActive(false);
                option1 = 0;
                option2 = 0;
                option3 = 1;
            }
        }
    }
    
    public void CharChoice()
    {
        if(option1 == 1 )
        {
            if(Changer.avatar != 0)
            {
                Choosed.SetActive(false);

                if(Verify == true && Changer.avatar == 1)
                {
                    buttonEquip.SetActive(true);
                }
                else if(Verify == false && Changer.avatar == 1)
                {
                    buttonEquip.SetActive(false);
                }

                if(Verify2 == true && Changer.avatar == 2)
                {
                    buttonEquip.SetActive(true);
                }
                else if(Verify2 == false && Changer.avatar == 2)
                {
                    buttonEquip.SetActive(false);
                }
            }
            else
            {
                Choosed.SetActive(true);
                buttonEquip.SetActive(false);
            }
        }
        else if(option2 == 1 )
        {
            if(Changer.avatar != 1)
            {
                Choosed.SetActive(false);
                
                if(Changer.avatar == 0)
                {
                    buttonEquip.SetActive(true);
                }

                if(Verify2 == true && Changer.avatar == 2)
                {
                    buttonEquip.SetActive(true);
                }
                else if(Verify2 == false && Changer.avatar ==2)
                {
                    buttonEquip.SetActive(false);
                } 
            }
            else
            {
                Choosed.SetActive(true);
                buttonEquip.SetActive(false);
            }
        }
        else
        {
            if(Changer.avatar != 2)
            {
                Choosed.SetActive(false);
                
                if(Changer.avatar == 0)
                {
                    buttonEquip.SetActive(true);
                }
                if(Verify == true && Changer.avatar == 1)
                {
                    buttonEquip.SetActive(true);
                }
                else if(Verify == false && Changer.avatar == 1)
                {
                    buttonEquip.SetActive(false);
                }
            }
            else
            {
                Choosed.SetActive(true);
                buttonEquip.SetActive(false);
            }
        }
    }
    public void BuyData()
    {
        if(points2 >= 20)
        {
            Changer.SaveChar();
            Verify = true;
            points2 -= 20;
            textPoints.text = points2.ToString();
        }
    }
    public void BuyData1()
    {    
        if(points2 >= 30)
        {
            Changer.SaveChar();
            Verify2 = true;
            points2 -= 30;
            textPoints.text = points2.ToString();
        }
    }
    public void DeleteData()
    {
        if(ScriptStorage.ResetVerify == 1)
        {
            PlayerPrefs.SetInt("Cash", zero);
            PlayerPrefs.SetInt("Char", zero);
            PlayerPrefs.SetInt("Char1", zero);
            points2 = PlayerPrefs.GetInt("Cash");
            Changer.SavingCharacter = PlayerPrefs.GetInt("Char");
            Changer.SavingCharacter1 = PlayerPrefs.GetInt("Char1");
            PlayerPrefs.Save();
            Verify = false;
            Verify2 = false;
            option1 = 1;
            option2 = 0;
            option3 = 0;
            ScriptStorage.ResetVerify = 0;
        }
    }
    IEnumerator sumirTex()
    {
        yield return new WaitForSeconds (sumirTexto);
        Destroy(pressRight);
    }
   
    public void ChangeScene()
    {
        SceneManager.LoadScene(0);
    }
}