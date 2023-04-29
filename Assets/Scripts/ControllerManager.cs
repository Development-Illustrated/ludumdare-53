using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    [SerializeField] ControllerType initialControllerType = ControllerType.PackageController;
    [SerializeField] bool debugMode = false;

    public enum ControllerType
    {
        PackageController,
        BuddahController,   
    }

    PackageController _packageController;
    BuddahController _buddahController;
    
    private void Awake() 
    {
        _packageController = GetComponent<PackageController>();
        _buddahController = GetComponent<BuddahController>();    
        
        SwitchController(initialControllerType);
    }
    
    public void SwitchController(ControllerType controllerType)
    {
        
        if(controllerType == ControllerType.BuddahController)
        {
            _packageController.enabled = false;
            _buddahController.enabled = true;
            if(debugMode){Debug.Log("Switched to BuddahController");}
        }
        else if(controllerType == ControllerType.PackageController)
        {
            _packageController.enabled = true;
            _buddahController.enabled = false;
            if(debugMode){Debug.Log("Switched to PlayerController");}
        }
    }
}
