using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneManager : MonoBehaviour
{
    [SerializeField] private ARPlaneManager aRPlaneManager;
    [SerializeField] private GameObject model3DPrefab;

    private List<ARPlane> planes = new List<ARPlane>();
    private GameObject model3DPlaced;

    private void OnEnable()
    {
        aRPlaneManager.planesChanged += PlanesFound;
    }
    private void OnDisable()
    {
        aRPlaneManager.planesChanged -= PlanesFound;
    }

    private void PlanesFound(ARPlanesChangedEventArgs planeData)
    {
        if (planeData.added != null && planeData.added.Count > 0)
        {
            planes.AddRange(planeData.added);
        }     
        
        foreach(var plane in planes)
        {
            if (plane.extents.x * plane.extents.y >= 0.4 && model3DPlaced == null)
            {
                model3DPlaced = Instantiate(model3DPrefab);
                float yOffset = model3DPlaced.transform.localScale.y / 2;
                model3DPlaced.transform.position = new Vector3(plane.center.x, plane.center.y + yOffset, plane.center.z);
                model3DPlaced.transform.forward = plane.normal;
                StopPlaneDetection();
            }
        }
    }

    public void StopPlaneDetection()
    {
        aRPlaneManager.requestedDetectionMode = PlaneDetectionMode.None;
        foreach(var plane in planes)
        {
            plane.gameObject.SetActive(false);
        }
    }

}
