using System;

public class Card	
{
    public Card(string name, int value, CardType type)
        => (Name, Value, Type) = (name, value, type);

    public string Name { get; set; }
    public int Value { get; set; }
    public CardType Type { get; set; }
}
