using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerBehavior : MonoBehaviour
{   
    [Header("Player")]
    [SerializeField] GameObject Player;
    public ParticleSystem sparkle;
    public ParticleSystem sparkle1;

    [Header("Game Manager")]
    [SerializeField] GameManager gameManager;

    [Header("HitBox")]
    [SerializeField] GameObject hitBox;

    [Header("Sprites")]
    public Sprite Zombie;
    public Sprite Avatar;
    public Sprite Penguim;
    public Image timeBoard;

    [Header("Texts")]
    public TextMeshProUGUI textPoints;
    public TextMeshProUGUI textTime;

    [Header("Audios")]
    public AudioSource Rock;

    GameObject Camera;
    public static int Choice = ShopBehavior.option1;
    public static int Choice2 = ShopBehavior.option2;
    public static int Choice3 = ShopBehavior.option3;

    //Variáveis para pegar posição. 
    private float posX;
    private float posY;
    private float boxY;

    //Quantidade de moedas.
    public static int points;
    //Posição da câmera.
    private float PosCamera;

    //Controle de movimento.
    float countdownShoot = 0f;
    private float ProxComand = 0.2f;
    public static bool pressed = false;

    //Variáveis de tempo.
    private int tempo; 
    private float aCadaSec; 
    private int increaseTime = 20;
    private int maxTime = 30;
    
    //Variáveis para rotação.
    Vector3 characterScale;
    float characterScaleX;

    void Awake()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
        Rock = GetComponent<AudioSource>();
        Rock.volume = 0.01f;
    }

    // Primeiro frame.
    void Start()
    {   
        Choice = ShopBehavior.option1;
        Choice2 = ShopBehavior.option2;
        Choice3 = ShopBehavior.option3;

        characterScale = transform.localScale;
        characterScaleX = characterScale.x;

        if(Choice == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Avatar;
        }
        if(Choice2 == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Zombie;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.04f, -1);
        }
        if(Choice3 == 1)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Penguim;
            gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.04f, -0.4f);
        }
        boxY = -4.6f;

        aCadaSec = 1.3f;  
        tempo = 30;
        //Pegando as posições e armazenando nas variáveis.
        posX = Player.transform.position.x;
        posY = Player.transform.position.y;
        Camera.transform.position = new Vector3(0, -1, -10);
        PosCamera = Camera.transform.position.y;
    }

    // Chamado a cada frame.
    void Update()
    {   
        Rotate();
        UpdateUI();
        

        aCadaSec = aCadaSec - 1 * Time.deltaTime;  //Contagem do tempo.
        if(aCadaSec < 1)
        {
            tempo = tempo - 1;
            
            aCadaSec = 1.3f;
        }
        textTime.text = tempo.ToString();
        if(tempo == 0)
        {
            gameManager.GameOver();
        }

        if (Input.GetAxisRaw("Horizontal") > 0) //Detecta se apertou a seta para direita.
        {   
            if(countdownShoot >= ProxComand)
            {
                posY = posY + 1;
                posX = posX + 2.8f;                                              //Muda posição do player.
                Player.transform.position = new Vector3(posX, posY, 0);
                
                boxY = boxY + 1;
                hitBox.transform.position = new Vector3(0, boxY, 0);

                PosCamera = PosCamera + 1;
                Camera.transform.position = new Vector3(0, PosCamera, -10);
                pressed = true;
                
                countdownShoot = 0f;
            }
        }
        

        if (Input.GetAxisRaw("Horizontal") < 0) //Detecta se apertou a seta para esquerda.
        {   
            if(countdownShoot >= ProxComand)
            {   
                posY = posY + 1;
                posX = posX - 2.8f;
                Player.transform.position = new Vector3(posX, posY, 0);
                
                boxY = boxY + 1;
                hitBox.transform.position = new Vector3(0, boxY, 0);

                PosCamera = PosCamera + 1;
                Camera.transform.position = new Vector3(0, PosCamera, -10);
                pressed = true;

                countdownShoot = 0f;
            }
        }
        countdownShoot += Time.deltaTime;     //Contagem regressiva após o próximo comando
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Plataforma")  //Testa se colidiu.
        {   
            tempo = tempo + 1;
            points = points + 1;  
            textPoints.text = points.ToString();   //Transforma a variável points em String.
            if(points == increaseTime)
            {
                tempo += 10;
                increaseTime += 20;
                Debug.Log("Time inscreased by 10!");
            }

            CreatEarth();
            Rock.volume = 0.01f;
            Rock.Play();
        }
        else if(other.transform.tag == "Finish")
        {
            SaveData();
            this.gameObject.GetComponent<SpriteRenderer>().sprite = null;
            gameManager.GameOver();
        }
    }
    void CreatEarth()  //Cria particulas.
    {
        sparkle.Play();
        sparkle1.Play();
    }
    public static void SaveData()   //Salva os pontos no jogo.
    {
        PlayerPrefs.SetInt("Cash", points);
        PlayerPrefs.Save();
        points = 0;
    }
    public void Rotate()                               //Rotaciona o player de acordo com a seta teclada.
    {
        if (Input.GetAxis("Horizontal") > 0) {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = characterScaleX;
        }
        transform.localScale = characterScale;
    }
    void UpdateUI()
    {
        timeBoard.fillAmount = tempo / 30f;
    }
}
