using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class NoiseLogic : MonoBehaviour
{

    public RawImage noiseImage;
    public Transform slenderTransform;
    private Renderer slenderRenderer;
    public VideoPlayer noiseVideoPlayer;
    private Camera mainCamera;

    private float maxNoiseAlpha = 0.2f;
    private float increaseRate = 1.0f;
    private float decreaseRate = 1.0f;

    private float viewOfCamera = 0.85f;
    private float currentNoiseAlpha = 0f;

    void Start()
    {
        mainCamera = Camera.main;
        if (noiseVideoPlayer == null || noiseImage == null || slenderTransform == null)
        {
            enabled = false;
            return;
        }

        slenderRenderer = slenderTransform.GetComponent<Renderer>();

        Color color = noiseImage.color;
        color.a = 0f;
        noiseImage.color = color;

    }

    void Update()
    {
        if (CheckIfLookingAtSlender())
        {
            currentNoiseAlpha += increaseRate * Time.deltaTime;
        }
        else
        {
            currentNoiseAlpha -= decreaseRate * Time.deltaTime;
        }
        currentNoiseAlpha = Mathf.Clamp01(currentNoiseAlpha); //valor de 0 a 1
        ApplyAlphaFilter();
    }


    void ApplyAlphaFilter() 
    {
        float finalAlpha = currentNoiseAlpha * maxNoiseAlpha; //le damos la transparencia
        Color color = noiseImage.color;
        color.a = finalAlpha; //transparencia del ruido
        noiseImage.color = color;
    }

    bool CheckIfLookingAtSlender()
    {
        Vector3 directionSlender = (slenderTransform.position - mainCamera.transform.position).normalized;
        // para obtener su direccion con el valor unitario
        Vector3 cameraForward = mainCamera.transform.forward;
        float dotProduct = Vector3.Dot(cameraForward, directionSlender);
        return dotProduct > viewOfCamera;
    }

}
