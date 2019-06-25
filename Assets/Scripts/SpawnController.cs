using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Vector3 Min, Max;
    private Vector3 randomPosition;
    private float xAxis, yAxis;
    public GameObject[] EnemiePrefab;
    int randomAmountOfEnemies,RandomAnimal,RandomEnemy, index = 0;
    public GameObject[] Animals;

    void Start()
    {
        //Sets a random value for the amount of enemies that spawn
        randomAmountOfEnemies = Random.Range(10, 20);

        //Sets a random value for the animal that will spawn
        RandomAnimal = Random.Range(0, 4);
    }

    void FixedUpdate()
    {
        //Sets a random position for the enemy
        xAxis = Random.Range(Min.x, Max.x);
        yAxis = Random.Range(Min.y, Max.y);
        randomPosition = new Vector2(xAxis, yAxis);

        RandomEnemy = Random.Range(0, EnemiePrefab.Length);

        //Spawns in enemies until the random number of enemies is reached
        if (index <= randomAmountOfEnemies)
        {
            Instantiate(EnemiePrefab[RandomEnemy], randomPosition, Quaternion.identity);
            index++;
        }
        else
        {
            Instantiate(Animals[RandomAnimal], randomPosition, Quaternion.identity);//Spawns in an animal
            Destroy(gameObject); //Destroys the spawn object if the random number for enemy spawns is reached
        }    
    }
}
