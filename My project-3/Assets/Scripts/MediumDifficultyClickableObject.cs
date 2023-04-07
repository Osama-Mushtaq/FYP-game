using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MediumDifficultyClickableObject : MonoBehaviour
{
    [SerializeField] private ObjRayCasting _objRayCasting;
    private Vector3 spawnRange = new Vector3(2, 4, 5);
    public Canvas crshr;
    private Color32 originalColor = new Color32(255, 255, 255, 255);

    void Start()
    {
        if (SavedObjectPos.getcond() == true)
        {
            transform.position = SavedObjectPos.getObjPos();
        }
    }
    void OnMouseDown()
    { 
        if (_objRayCasting.CanHit == true)
        {
            _objRayCasting.Reset();
            Vector3 size = transform.lossyScale;
            Vector3 newPosition = transform.position;
            newPosition.x = Random.Range(-spawnRange.x, spawnRange.x);
            newPosition.y = Random.Range(size.y, spawnRange.y);
            newPosition.z = Random.Range(spawnRange.z, (float)1.5 * spawnRange.z);
            transform.position = newPosition;
            ResetColor_3();
        }
    }
    void ResetColor_3()
    {
        Transform objectTransform = crshr.transform.Find("my_crosshair");
        Graphic objectGraphic = objectTransform.GetComponentInChildren<Graphic>();
        objectGraphic.color = originalColor;
        Image[] objectImages = objectTransform.GetComponentsInChildren<Image>();
        foreach (Image image in objectImages)
        {
            image.color = originalColor;
        }
    }
}