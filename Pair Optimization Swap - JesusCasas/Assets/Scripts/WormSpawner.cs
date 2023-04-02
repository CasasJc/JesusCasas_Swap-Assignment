using UnityEngine;

public class WormSpawner : MonoBehaviour
{
    public float spawnDistance = 12f;
    public float spawnRate = 1f;
    public int amountPerSpawn = 1;
    [Range(0f, 45f)]
    public float trajectoryVariance = 15f;
    
    WormObj Worm;

    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    public void Spawn()
    {
        for (int i = 0; i < amountPerSpawn; i++)
        {
            // Choose a random direction from the center of the spawner and
            // spawn the Worm a distance away
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPoint = spawnDirection * spawnDistance;
            spawnPoint += transform.position;

            // Calculate a random variance in the Worm's rotation which will
            // cause its trajectory to change
            float variance = Random.Range(-trajectoryVariance, trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            // Create the new Worm by cloning the prefab and set a random
            // size within the range

            //Update, now spawns from a list of preexisting worms if they are avaiable - Emilie
            Worm = WormObjectPool.SharedInstance.GetPooledWorm();
            if (Worm != null)
            {
                Worm.gameObject.SetActive(true); 
                Worm.transform.position = spawnPoint;
                Worm.transform.rotation = rotation;

                //Setting random worm size
                Worm.size = Random.Range(Worm.minSize, Worm.maxSize);

                //Set the trajectory to move in the direction of the spawner
                Vector2 trajectory = rotation * -spawnDirection;
                Worm.SetTrajectory(trajectory);
            }
        }
    }
}
