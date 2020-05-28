internal class Magic
{
    private string _name;
    private Spell[] spells;
    private Element element;

    public string Name { get => _name; set => _name = value; }
    public Element Element { get => element; set => element = value; }
    internal Spell[] Spells { get => spells; set => spells = value; }
}