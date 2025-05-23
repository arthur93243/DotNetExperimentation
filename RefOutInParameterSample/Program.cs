using ConsoleTables;

namespace RefOutInParameterSample;

class Program
{
    static void Main(string[] args)
    {
        Person person;
        
        // Normal parameter
        person = new()
        {
            Name = "Arthur"
        };
        Console.WriteLine("Normal parameter");
        Console.WriteLine($"Before person.Name: {person.Name}");
        ChangeName(person);
        Console.WriteLine($"After person.Name: {person.Name}\n");
        
        // Normal parameter with new
        person = new()
        {
            Name = "Arthur"
        };
        Console.WriteLine("Normal parameter with new");
        Console.WriteLine($"Before person.Name: {person.Name}");
        ChangeNameThenNew(person);
        Console.WriteLine($"After person.Name: {person.Name}\n");
        
        // Ref parameter
        person = new()
        {
            Name = "Arthur"
        };
        Console.WriteLine("Ref parameter");
        Console.WriteLine($"Before person.Name: {person.Name}");
        ChangeNameRef(ref person);
        Console.WriteLine($"After person.Name: {person.Name}\n");
        
        // Ref parameter with new
        person = new()
        {
            Name = "Arthur"
        };
        Console.WriteLine("Ref parameter with new");
        Console.WriteLine($"Before person.Name: {person.Name}");
        ChangeNameRefThenNew(ref person);
        Console.WriteLine($"After person.Name: {person.Name}\n");
        
        // Out parameter
        person = new()
        {
            Name = "Arthur"
        };
        Console.WriteLine("Out parameter");
        Console.WriteLine($"Before person.Name: {person.Name}");
        ChangeNameOut(out person);
        Console.WriteLine($"After person.Name: {person.Name}\n");
        
        // In parameter
        person = new()
        {
            Name = "Arthur"
        };
        Console.WriteLine("In parameter");
        Console.WriteLine($"Before person.Name: {person.Name}");
        ChangeNameIn(in person);
        Console.WriteLine($"After person.Name: {person.Name}\n");
        
        // In parameter with new
        Console.WriteLine("In parameter with new");
        Console.WriteLine($"Con not initialize the in parameter \n");
        
        ConsoleTable table = new ConsoleTable();
        table.AddColumn(["修飾詞"]);
        table.AddColumn(["可改內容"]);
        table.AddColumn(["可換參考"]);
        table.AddColumn(["需初始化(傳入前)"]);
        table.AddColumn(["常見用途"]);

        table.AddRow("無修飾", "✅", "❌", "✅", "一般使用，改內容");
        table.AddRow("ref", "✅", "✅", "✅", "改變參考指向、改內容");
        table.AddRow("out", "✅", "✅", "❌", "回傳新物件、多值輸出");
        table.AddRow("in", "✅", "❌", "✅", "禁止換參考，提升效能");
        table.Write();
    }

    static void ChangeName(Person person)
    {
        person.Name = "John";
    }
    
    static void ChangeNameThenNew(Person person)
    {
        person.Name = "John";
        
        person = new ();
        person.Name = "New John";
    }
    
    static void ChangeNameRef(ref Person person)
    {
        person.Name = "John";
    }
    
    static void ChangeNameRefThenNew(ref Person person)
    {
        person.Name = "John";
        
        person = new ();
        person.Name = "New John";
    }
    
    static void ChangeNameOut(out Person person)
    {
        person = new(); // always need to initialize the out parameter
        person.Name = "John";
    }
    
    static void ChangeNameIn(in Person person)
    {
        person.Name = "John";
    }
    
    static void ChangeNameInThenNew(in Person person)
    {
        person.Name = "John";
        
        //person = new(); // Can not initialize the in parameter
    }
    
    class Person
    {
        public string Name { get; set; }
    }
}