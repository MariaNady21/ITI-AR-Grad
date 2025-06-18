using UnityEngine;

public class GenericBuilding : MonoBehaviour
{
    public BuildingType buildingType;
    public Scorenum scoreManager;
    public enum VehicleType
    {
        Car,
        Truck,
        redvane,
        bus
    }

    public enum BuildingType
    {
        Office,
        Warehouse,
        Factory,
        redbuilding
    }

    void OnTriggerEnter(Collider other)
    {
        VehicleType? vehicle = GetVehicleTypeFromTag(other.tag);
        if (vehicle == null) return;

        int scoreChange = GetScoreChange(buildingType, vehicle.Value);
        scoreManager.score += scoreChange;
        Debug.Log($"Vehicle: {vehicle}, Building: {buildingType}, Score Changed By: {scoreChange}, Total Score: {scoreManager.score}");
    }

    VehicleType? GetVehicleTypeFromTag(string tag)
    {
        switch (tag)
        {
            case "car": return VehicleType.Car;
            case "truck": return VehicleType.Truck;
            case "redvane": return VehicleType.redvane;
            case "bus": return VehicleType.bus;
            default: return null;
        }
    }

    int GetScoreChange(BuildingType building, VehicleType vehicle)
    {
        switch (building)
        {
            case BuildingType.Office:
                return vehicle == VehicleType.Car ? 10 : -5;

            case BuildingType.Warehouse:
                return vehicle == VehicleType.Truck ? 10 : -5;

            case BuildingType.redbuilding:
                return vehicle == VehicleType.redvane ? 10 : -5;

            case BuildingType.Factory:
              //  return vehicle == VehicleType.Loader ? 10 : -5;
                return vehicle == VehicleType.bus ? 10 : -5;

            default:
                return 0;
        }
    }
}