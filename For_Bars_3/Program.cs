//// Задание 2 - коллекции
Entity entity = new Entity();
List<Entity> entities = new List<Entity>();
entities.Add(new Entity { Id = 1, ParentId = 0, Name = "Root entity" });
entities.Add(new Entity { Id = 2, ParentId = 1, Name = "Child of 1 Entity" });
entities.Add(new Entity { Id = 3, ParentId = 1, Name = "Child of 1 Entity" });
entities.Add(new Entity { Id = 4, ParentId = 2, Name = "Child of 2 Entity" });
entities.Add(new Entity { Id = 5, ParentId = 4, Name = "Child of 4 Entity" });
var output = entity.Method(entities);
foreach (KeyValuePair<int, List<Entity>> pair in output)
    Console.WriteLine("Key = " + pair.Key.ToString() + ", Value = List { " + string.Join(", ", pair.Value.Select(x => "Entity { Id = " + x.Id.ToString() + " }")) + " }");
public class Entity
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string? Name { get; set; }
   
    public Dictionary<int, List<Entity>> Method(List<Entity> list)
    {
        Dictionary<int, List<Entity>> dict = list
            .GroupBy(x => x.ParentId)
            .ToDictionary(key => key.Key, vals => vals.ToList());
        return dict;
    }
}

