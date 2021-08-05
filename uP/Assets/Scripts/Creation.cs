using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creation : MonoBehaviour
{
    public static int PlataformaAtiva = 0;

    [SerializeField] int maxPlataformaAtiva;

    [SerializeField] float forceSpawn;

    [Header("Plataform")]
    [SerializeField] GameObject prefabPlataforma;

    public bool Up;
    public int Count = 0;
    public static int Detect;

    private int altura = -4;
    private float x = 0;
    int[] randomLevels = new int[] {1,2};
    private float Nulo;

    // Start is called before the first frame update
    void Start()
    {
        x = prefabPlataforma.transform.position.x;
        Nulo = randomLevels[Random.Range(0, randomLevels.Length)];
        SpawnPlat1();
    }

    // Update is called once per frame
    void Update()
    {   
        if(PlayerBehavior.pressed == true)
        {
            if(PlataformaAtiva < maxPlataformaAtiva)
            {
                if(x == 0)
                {
                    SpawnPlat1();
                    Nulo = randomLevels[Random.Range(0, randomLevels.Length)];
                }
                else if(x == -2.8f)
                {
                    SpawnPlat2();
                    Nulo = randomLevels[Random.Range(0, randomLevels.Length)];
                }
                else if(x == 2.8f)
                {
                    SpawnPlat3();
                    Nulo = randomLevels[Random.Range(0, randomLevels.Length)];
                }
                else if(x == -5.6f)
                {
                    altura = altura + 1;
                Vector3 position = new Vector3(-2.8f, altura, 0);
                GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
                x = -2.8f;
                }
                else
                {
                    altura = altura + 1;
                Vector3 position = new Vector3(2.8f, altura, 0);
                GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
                x = 2.8f;     
                }   
            }
            PlayerBehavior.pressed = false;
        }
    }
    void SpawnPlat1()
    {
        if(Nulo == 1)
        {   
            altura = altura + 1;
            Vector3 position = new Vector3(-2.8f, altura, 0);
            GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
            x = -2.8f;
        }
        else if(Nulo == 2)
        {   
            altura = altura + 1;
            Vector3 position = new Vector3(2.8f, altura, 0);
            GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
            x = 2.8f;
        }
        forceSpawn = Random.Range(-100, 100);
        PlataformaAtiva++;
    }
    void SpawnPlat2()
    {
        if(Nulo == 1)
        {   
            altura = altura + 1;
            Vector3 position = new Vector3(-5.6f, altura, 0);
            GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
            x = -5.6f;
        }
        else if(Nulo == 2)
        {   
            altura = altura + 1;
            Vector3 position = new Vector3(0, altura, 0);
            GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
            x = 0;
        }
        forceSpawn = Random.Range(-100, 100);
        PlataformaAtiva++;
    }
    void SpawnPlat3()
    {
        if(Nulo == 1)
        {   
            altura = altura + 1;
            Vector3 position = new Vector3(5.6f, altura, 0);
            GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
            x = 5.6f;
        }
        else if(Nulo == 2)
        {   
            altura = altura + 1;
            Vector3 position = new Vector3(0, altura, 0);
            GameObject plataform = Instantiate(prefabPlataforma, position, Quaternion.identity);
            x = 0;
        }
        forceSpawn = Random.Range(-100, 100);
        PlataformaAtiva++;
    }
    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
