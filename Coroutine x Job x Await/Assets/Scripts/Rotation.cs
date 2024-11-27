using System.Collections;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;

    private float timer = 0;

    public void StartRotate()
    {
        timer = 0;
        StartCoroutine(Rotate());
    }

    public void StopRotate()
    {
        StopAllCoroutines();
        timer = 0;
    }

    IEnumerator Rotate()
    {
        while (timer <= 85)
        {
            _cube.transform.rotation = Quaternion.Euler(420 * _cube.transform.rotation.x, 650 * _cube.transform.rotation.y, 520 * _cube.transform.rotation.z);
            timer++;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
