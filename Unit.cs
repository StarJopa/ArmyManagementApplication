public class Unit
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Attack { get; set; }
    public double Cost { get; set; }
    public int AvailableUnits { get; set; }
    public int HiredUnits { get; set; }

    // Дополнительные поля
    public int MaxHP { get; set; }         // Максимальное число НР
    public int CurrentHP { get; set; }     // Текущее число НР
    public int Defense { get; set; }       // Защита
    public int Arrows { get; set; }        // Число стрел
    public int Mana { get; set; }          // Число маны
    public int Level { get; set; }         // Уровень прокачки

    public int TotalAttack => Attack * HiredUnits;
}
