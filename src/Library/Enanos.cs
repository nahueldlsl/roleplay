namespace Library
{
    public class Enanos
    {
        public string Name { get; set; }
        public int HealthPoints { get; private set; }
        public List<Item> Items { get; private set; }

        public Enanos(string name)
        {
            this.Name = name;
            this.HealthPoints = 100;
            this.Items = new List<Item>
            {
                new Item("Espada", 100, 0),
                new Item("Escudo", 0, 50)
            };
        }

        // Agregar ítem
        public void AddItem(Item item)
        {
            Items.Add(item);
        }

    }
}