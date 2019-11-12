using NetFabric;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Rotate
    : MonoBehaviour
    , ISerializationCallbackReceiver
{
    new Transform transform;

    [Description("Degrees per second rotation around the X axis")]
    [AngleDegreesRange(0, 90)]
    public AngleDegrees x;

    [Description("Degrees per second rotation around the Y axis")]
    [AngleDegreesRange(0, 90)]
    public AngleDegrees y;

    [Description("Degrees per second rotation around the Z axis")]
    [AngleDegreesRange(0, 90)]
    public AngleDegrees z;

    [SerializeField]
    [HideInInspector]
    double serializableX;

    [SerializeField]
    [HideInInspector]
    double serializableY;

    [SerializeField]
    [HideInInspector]
    double serializableZ;

    // OnBeforeSerialize is called before object serialization
    void ISerializationCallbackReceiver.OnBeforeSerialize()
    {
        serializableX = x.Degrees;
        serializableY = y.Degrees;
        serializableZ = z.Degrees;
    }

    // OnAfterDeserialize is called after object serialization
    void ISerializationCallbackReceiver.OnAfterDeserialize()
    {
        x = Angle.FromDegrees(serializableX);
        y = Angle.FromDegrees(serializableY);
        z = Angle.FromDegrees(serializableZ);
    }

    void Awake()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * x, Time.deltaTime * y, Time.deltaTime * z);
    }
}
