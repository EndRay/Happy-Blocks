using UnityEngine;

public class SunButton : MonoBehaviour
{
    public Creator Creator;

    private readonly Vector3 _small = new Vector3(0.3f, 0.3f, 0.3f);

    private readonly Vector3 _big = new Vector3(0.6f, 0.6f, 0.6f);

    // Use this for initialization
    private void Start()
    {
        gameObject.transform.localScale = Creator.IsSun ? _big : _small;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        Creator.SunChange();
        gameObject.transform.localScale = Creator.IsSun ? _big : _small;
    }
}
