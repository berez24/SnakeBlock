using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] CubePrefabs;
    public int MinCount;
    public int MaxCount;
    public float DistanceCube;
    public Transform Finish;
    public Transform PlaneRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);

        int CubeCount = RandomRange(random, MinCount, MaxCount + 1);

        for (int i = 0; i < CubeCount; i++)
        {
            int CubeIndex = RandomRange(random, 0, CubePrefabs.Length);
            GameObject Cube = Instantiate(CubePrefabs[CubeIndex], transform);
            Cube.transform.localPosition = CalculateCubePosition(i);
        }

        Finish.localPosition = CalculateCubePosition(CubeCount);

        PlaneRoot.localScale = new Vector3(1, 1, CubeCount * -DistanceCube);
    }

    private int RandomRange(Random random, int min, int maxExlusive)
    {
        int number = random.Next();
        int length = maxExlusive - min;
        number %= length;
        return min + number;

    }

    //private float RandomRange(Random random, float min, float max)
    //{
    //    float t = (float)random.NextDouble();
    //    return Mathf.Lerp(min, max, t);

    //}

    private Vector3 CalculateCubePosition(int cubeIndex)
    {
        return new Vector3(0, 0, -DistanceCube * cubeIndex);
    }
}
