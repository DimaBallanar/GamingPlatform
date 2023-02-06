using BlackJack;
using System;

public class Card	
{
    public string Name { get; set; }
    public int Value { get; set; }
    //public CardTypes Type { get; set; }
    public CardEnum CardEnum { get; set; }
    public Card(string name, int value,/* CardTypes type,*/CardEnum card)
    {
        Name = name;
        Value = value;
        //Type = type;
        CardEnum = card;
    }
       

    

}
