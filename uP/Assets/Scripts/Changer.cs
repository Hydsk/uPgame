using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Changer : MonoBehaviour
{
    public Sprite Zombie;
    public Sprite Astronaut;
    public Sprite Penguim;
    public static int avatar;
    public static int SavingCharacter;
    public static int SavingCharacter1;

    [SerializeField] float ProxComand = 0.3f;
    [SerializeField] GameObject buyButton;
    [SerializeField] GameObject buyButton2;
    [SerializeField] GameObject Player;
    public bool Up;
    public int Count;
    
    float countdownShoot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        avatar = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Count <= 21)
        //{
        //    if(Up)
        //    {
        //        transform.Translate(4f * Time.deltaTime, 0, 0);
        //        Up = false;
        //    }
        //    else
        //    {
        //        transform.Translate(-4f * Time.deltaTime, 0, 0);
        //       Up = true;
        //    }
        //    Count++;
        //}
        //else
        //{
        //    Player.transform.position = new Vector3(0, 0.2f, 0);
        //}

        SavingCharacter = PlayerPrefs.GetInt("Char");
        SavingCharacter1 = PlayerPrefs.GetInt("Char1");
        if(SavingCharacter == 1)
        {
            ShopBehavior.Verify = true;
        }
        if(SavingCharacter1 == 1)
        {
            ShopBehavior.Verify2 = true;
        }

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            if(countdownShoot >= ProxComand)
            {
                ChangeCharacter();
                countdownShoot = 0f;
            }
        }
        countdownShoot += Time.deltaTime;
        if(ShopBehavior.Verify == true)
        {
            buyButton.SetActive(false);
        }
        if(ShopBehavior.Verify2 == true)
        {
            buyButton2.SetActive(false);
        }
    }

    public void ChangeCharacter()
    {   
        if(avatar == 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Zombie;   
            avatar = 1;
            BlockEquip();
            buyButton2.SetActive(false);
        }
        else if(avatar == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Penguim;
            avatar = 2;
            BlockEquip2();
            buyButton.SetActive(false);
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Astronaut;
            avatar = 0;
            buyButton.SetActive(false);
            buyButton2.SetActive(false);
        }
    }
    public void BlockEquip()
    {
        if(ShopBehavior.Verify == false)
        {
            buyButton.SetActive(true);
        }
    }
    public void BlockEquip2()
    {
        if(ShopBehavior.Verify2 == false)
        {
            buyButton2.SetActive(true);
        }
    }
    public static void SaveChar()
    {
        PlayerPrefs.SetInt("Char", 1);
        PlayerPrefs.Save();
    }
    public static void SaveChar1()
    {
        PlayerPrefs.SetInt("Char1", 1);
        PlayerPrefs.Save();
    }
}
