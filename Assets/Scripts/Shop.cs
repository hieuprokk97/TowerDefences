using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint archerPrefab;
    public TurretBlueprint cannonPrefab;
    public TurretBlueprint wizardPrefab;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance; 
    }
    public void SelectArcher()
    {
        Debug.Log("Archer Selected");
        buildManager.SelectTurretToBuild(archerPrefab);
    }    
    public void SelectCannon()
    {
        Debug.Log("Cannon Selected");
        buildManager.SelectTurretToBuild(cannonPrefab);
    }
    public void SelectWizard()
    {
        Debug.Log("Wizard Selected");
        buildManager.SelectTurretToBuild(wizardPrefab);
    }
}
