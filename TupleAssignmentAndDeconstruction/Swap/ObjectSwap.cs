namespace TupleAssignmentAndDeconstruction.Swap;

public class ObjectSwap : IAction
{
    public void Execute()
    {
        Box box1 = new Box { BoxNumber = 1, ParcelId = 101, Fruit = new Apple { Name = "Apple" } };
        Box box2 = new Box { BoxNumber = 2, ParcelId = 102, Fruit = new Orange { Name = "Orange" } };

        Console.WriteLine("Before swap");
        Console.WriteLine($"Box1: Number: {box1.BoxNumber}, Pallet: {box1.ParcelId}, Fruit: {box1.Fruit?.Name}");
        Console.WriteLine($"Box2: Number: {box2.BoxNumber}, Pallet: {box2.ParcelId}, Fruit: {box2.Fruit?.Name}");

        // Swap the boxes and their contents
        (box1.Fruit, box1.ParcelId, box2.Fruit, box2.ParcelId) = (box2.Fruit, box2.ParcelId, box1.Fruit, box1.ParcelId);

        Console.WriteLine("After swap");
        Console.WriteLine($"Box1: Number: {box1.BoxNumber}, Pallet: {box1.ParcelId}, Fruit: {box1.Fruit?.Name}");
        Console.WriteLine($"Box2: Number: {box2.BoxNumber}, Pallet: {box2.ParcelId}, Fruit: {box2.Fruit?.Name}");
    }

    public class Box
    {
        public int BoxNumber { get; set; }
        public int ParcelId { get; set; }
        public IFruit? Fruit { get; set; }
    }

    public interface IFruit
    {
        string Name { get; set; }
    }

    public class Apple : IFruit
    {
        public string Name { get; set; }
    }

    public class Orange : IFruit
    {
        public string Name { get; set; }
    }
}