
using UnityEngine;

public class Contents : ScriptableObject
{
    [SerializeField] protected EcologistEnum ecologistEnum;
    [SerializeField] protected string contentsName = string.Empty;
    [SerializeField] protected string temperature = string.Empty;
    [SerializeField] protected string humidity = string.Empty;
    [SerializeField] protected string location = string.Empty;

    public EcologistEnum EcologistEnum { get { return ecologistEnum; } }
    public string Name { get { return contentsName; } }
    public string Temperature { get { return temperature; } }
    public string Humidity { get { return humidity; } }
    public string Location { get { return location; } }

}
