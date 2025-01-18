using UnityEngine;

public class HelicopterMotion : MonoBehaviour
{
    [SerializeField] float helicopterSpeed = 40.0f;
    bool spawnDirection;
    Renderer helicopterRenderer;
    float despawnDistance = 550.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helicopterRenderer = gameObject.transform.GetChild(0).GetComponent<Renderer>();

        InitializeHelicopterAttitude();
        RandomizeColor();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHelicopter();
        DespawnHelicopter();
    }

    // Keeps memory of the starting location and rotates the helicopter accordingly
    void InitializeHelicopterAttitude()
    {
        float spawnZ = gameObject.transform.position.z;
        if (spawnZ < 0)
        {
            spawnDirection = false;
        }
        else
        {
            spawnDirection = true;
            gameObject.transform.Rotate(Vector3.up, 180, Space.Self);
        }
    }

    // Randomizes the color of the new helicopter instance
    void RandomizeColor()
    {
        float red = Random.Range(0, 255) / 255f;
        float green = Random.Range(0, 255) / 255f;
        float blue = Random.Range(0, 255) / 255f;

        Color newColor = new Color(red, green, blue);
        helicopterRenderer.materials[1].SetColor("_BaseColor", newColor);
    }

    // Updates the position of the helicopter in time
    void MoveHelicopter()
    {
        float newPos;

        // Handles direction of motion
        if (spawnDirection == false)                        // Left-spawned helicopter
        {
            newPos = gameObject.transform.position.z + helicopterSpeed * Time.deltaTime;
        }
        else                                                // Right-spawned helicopter
        {
            newPos = gameObject.transform.position.z - helicopterSpeed * Time.deltaTime;
        }

        // Moves helicopter at constant speed
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, newPos);
    }

    // Destroys the helicopter after leaving the game zone
    void DespawnHelicopter()
    {
        if ((spawnDirection == false && gameObject.transform.position.z > despawnDistance) || (spawnDirection == true && gameObject.transform.position.z < -despawnDistance))
        {
            Destroy(gameObject);
        }
    }
}