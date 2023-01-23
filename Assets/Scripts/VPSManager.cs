using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using Google.XR.ARCoreExtensions;
using System;

public class VPSManager : MonoBehaviour
{
    [SerializeField]private AREarthManager earthManager;

    [Serializable]
    public struct GeospatialObject
    {
        public GameObject ObjectPrefabs;
        public EarthPosition earthPosition;
    }

    [Serializable]
    public struct EarthPosition
    {
        public double Latitude;
        public double Longitude;
        public double Altitude;
    }


    [SerializeField] private ARAnchorManager aRAnchorManager;
    [SerializeField] private List<GeospatialObject> geospatialObjects = new List<GeospatialObject>();

    // Start is called before the first frame update
    void Start()
    {
        VerifyGeospatialSupport();
    }
    void VerifyGeospatialSupport()
    {
        var result = earthManager.IsGeospatialModeSupported(GeospatialMode.Enabled);
        switch (result)
        {
            case FeatureSupported.Supported:
                Debug.Log("Ready to use VPS");
                PlaceObjects();
                break;
            case FeatureSupported.Unknown:
                Debug.Log("Unknown...");
                Invoke("VerifyGeospatialSupport", 5.0f);
                break;
            case FeatureSupported.Unsupported:
                Debug.Log("VPS Unsupported");
                break;
        }
    }

    void PlaceObjects()
    {
        if (earthManager.EarthTrackingState == TrackingState.Tracking)
        {
            var geospatialPose = earthManager.CameraGeospatialPose;

            foreach(var obj in geospatialObjects)
            {
                var earthPosition = obj.earthPosition;
                var objAnchor = ARAnchorManagerExtensions.AddAnchor(aRAnchorManager, earthPosition.Latitude, earthPosition.Longitude, earthPosition.Altitude, Quaternion.identity);
                Instantiate(obj.ObjectPrefabs, objAnchor.transform);
               
                
            }
        }

        else if (earthManager.EarthTrackingState == TrackingState.None)
        {
            Invoke("PlaceObjects", 5.0f);
        }
    }

}
