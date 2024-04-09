using System;

public class SensorData
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public float Temperature { get; set; }
    public bool Motion { get; set; }
}