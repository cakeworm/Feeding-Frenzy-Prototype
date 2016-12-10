using UnityEngine;
using System.Collections;

public class GUICursor : MonoBehaviour
{
    private Camera _camera;
    public bool ShowPeaReticle = true;
    public bool ShowNachoReticle = false;
    public bool ShowHotdogReticle = false;

    void Start ()
    {
        _camera = GetComponent<Camera>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

        void Update()
    {
    //below is my inelegant solution to changing out the reticle for each weapon type. Perhaps a better solution is to make an array? This is a lot of text and conditions for a CPU to sort through.
        if (Input.GetKeyDown (KeyCode.Alpha1))
        {
        ShowPeaReticle = true;
        ShowNachoReticle = false;
        ShowHotdogReticle = false; 
        } 

       else if (Input.GetKeyDown (KeyCode.Alpha2))
        {
        ShowPeaReticle = false;
        ShowNachoReticle = true;
        ShowHotdogReticle = false; 
        } 

        else if (Input.GetKeyDown (KeyCode.Alpha3))
        {
        ShowPeaReticle = false;
        ShowNachoReticle = false;
        ShowHotdogReticle = true; 
        }
    }

  

    void OnGUI()
    {

        if (ShowPeaReticle)
        {
            int size = 12;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;
            GUI.Label(new Rect(posX, posY, size, size), "*");
        }
        else if (ShowNachoReticle)
        {
                    int size = 12;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;
            GUI.Label(new Rect(posX, posY, size, size), "N");
        }

        else if (ShowHotdogReticle)
        {
                    int size = 12;
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;
            GUI.Label(new Rect(posX, posY, size, size), "H");
        }
    }



    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }

    private IEnumerator SphereIndicator (Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive (PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds (1);
        
        Destroy (sphere);
    }
    */

}
