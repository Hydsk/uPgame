using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptStorage : MonoBehaviour
{
    public static int ResetVerify = 0;
    public static int PlayVerify = 0;
    private bool Block = false;
    private bool Block1 = false;
    private bool Block2 = false;
    private bool Block3 = false;
    
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");

        if(PlayVerify == 1)
        {
            ShopBehavior.points2 += PlayerPrefs.GetInt("Cash");
            PlayerPrefs.Save();
            Debug.Log(ShopBehavior.points2);
            PlayVerify = 0;
        }
    }

    void Update()
    {
        if(Camera.transform.position.x <= 3.3f && Block == false)
        {
            Camera.transform.Translate(0.4f * Time.deltaTime, 0, 0);
            Block1 = false;
        }
        else if(Camera.transform.position.y <= 4 && Block1 == false)
        {
            Block = true;
            Camera.transform.Translate(-0.4f * Time.deltaTime, 0.4f * Time.deltaTime, 0);
            Block2 = false;
        }
        else if(Camera.transform.position.y >= 0 && Block2 == false)
        {
            Block1 = true;
            Camera.transform.Translate(-0.4f * Time.deltaTime, -0.4f * Time.deltaTime, 0);
            Block3 = false;
        }
        else if(Camera.transform.position.x <= 0 && Block3 == false)
        {
            Block2 = true;
            Camera.transform.Translate(0.4f * Time.deltaTime, 0, 0);
            Block = false;
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    public void GoToShop()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
        PlayVerify = 1;
    }
    public void Reset()
    {
        ResetVerify = 1;
        Debug.Log("Reseted");
    }
}
