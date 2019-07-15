using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Vector3 Min, Max;
    private Vector3 randomPosition,randomAstroidePos;
    private float xAxis, yAxis;
    public GameObject[] EnemiePrefab;
    public GameObject[] Animals;
    public GameObject Astroide;
    int randomAmountOfEnemies,RandomAnimal,RandomEnemy, index = 0;
    

    void Start()
    {
        //Sets a random value for the amount of enemies that spawn
        randomAmountOfEnemies = Random.Range(45, 70);

        //Sets a random value for the animal that will spawn
        RandomAnimal = Random.Range(0, 4);
    }

    void FixedUpdate()
    {
        GetRandomPosition();
        randomPosition = new Vector2(xAxis, yAxis);

        GetRandomPosition();
        randomAstroidePos = new Vector2(xAxis, yAxis);

        RandomEnemy = Random.Range(0, EnemiePrefab.Length);

        //Spawns in astroides in at random positions
        if (index <= randomAmountOfEnemies / 2)
            Instantiate(Astroide, randomAstroidePos, Quaternion.identity);//Spawns in the astroide

        //Spawns in enemies at random positions until the random number of enemies is reached
        if (index <= randomAmountOfEnemies)
        {
            Instantiate(EnemiePrefab[RandomEnemy], randomPosition, Quaternion.identity);//Spawns in the enemy
            index++;
        }
        else
        {
            Instantiate(Animals[RandomAnimal], randomPosition, Quaternion.identity);//Spawns in an animal
            Destroy(gameObject); //Destroys the spawn object if the random number for enemy spawns is reached
        }        
    }

    void GetRandomPosition()
    {
        //Sets a random position for the enemy
        xAxis = Random.Range(Min.x, Max.x);
        yAxis = Random.Range(Min.y, Max.y);
        return;
    }
}
