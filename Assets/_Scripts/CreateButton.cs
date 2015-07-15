using UnityEngine;

public class CreateButton : MonoBehaviour
{
    private readonly Quaternion _rotate90 = Quaternion.Euler(0, 0, 90);

    public Camera Camera;

    public Creator Creator;

    public GameObject CreateObj;

	// Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void OnMouseDown()
    {
        RaycastHit hit;
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f, 1 << 8))
        {
            Creator.Delete = false;
            Instantiate(CreateObj, hit.point, Creator.Rotate ? _rotate90 : Quaternion.identity);
        }
    }
}
