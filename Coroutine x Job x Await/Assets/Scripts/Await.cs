using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Await : MonoBehaviour
{
    [SerializeField]
    private GameObject _cube;

    private CancellationTokenSource _cancellationTokenSource;
    private float timer = 0;
    private bool _stop = true;

    public async void RotateWithAwait()
    {
        while (timer <= 85)
        {
            _cube.transform.rotation = Quaternion.Euler(420 * _cube.transform.rotation.x, 650 * _cube.transform.rotation.y, 520 * _cube.transform.rotation.z);
            timer++;
            await UniTask.WaitUntil((() => !_stop), cancellationToken: _cancellationTokenSource.Token);
            await Task.Delay(50);
        }
    }

    public void StartRotate()
    {
        timer = 0;
        _stop = true;
        RotateWithAwait();
    }

    public void StopRotate()
    {
        _stop = false;
    }
}
