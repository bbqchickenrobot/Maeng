using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    // interfaces define contracts for classes... or sort of denote what a class can *do*
    // they should always start with a capital I (it makes them more readable and identifiable)

    // this interface says that a class can make noise, how it doesn't know or care, just that it can
    public interface IMakeNoise
    {
        string MakeSound();
    }

    // this interface says that whoever inherits it will have a name
    // it will also *inherit* the MakeSound() function from IMakeNoise interface
    public interface IAnimal : IMakeNoise
    {
        string Name { get; set; }
    }

    // abstract classes are like normal classes but they can't be instantiated (created) directly
    public abstract class Animal : IAnimal
    {
        // this is a property (a variable attached to a class)
        public string Name { get; set; }

        // abstract methods wait for you to define in child/sub classes
        public abstract string MakeSound();
    }

    // sub-classes that are all of type Animal, but even more specific
    public class Dog : Animal
    {
        // this is a constructor - a function that runs every time a class is created
        // it always has the same name as the class with NO return type
        // if this constructor is called the default name is Kujo
        public Dog():this("Kujo")
        {
        }

        public Dog(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;
        }

        public override string MakeSound()
        {
            return "Woof!  Woof!";
        }
    }

    public class Cat : Animal
    {
        // if this constructor is called the default name is Tiger
        public Cat():this("Tiger")
        {
            
        }

        public Cat(string name)
        {
            if(!string.IsNullOrEmpty(name))
               Name = name;
        }
        public override string MakeSound()
        {
            return "Meow.... prrrrrrr......";
        }
    }

    public class Human : Animal
    {
        // this constructor calls an *overload* of itself
        // if this constructor is called the default name is chang
        public Human():this("Chang") 
        {
        }

        // does same as constructor above, but it takes a name argument
        public Human(string name)
        {
            if (!string.IsNullOrEmpty(name))
                Name = name;
        }

        public override string MakeSound()
        {
            return $"Hi, my name is {this.Name}";
        }
    }


    public static class MainProgram
    {
        // the public static void Main is ALWAYS the method that is called when you first run a program
        public static void Main()
        {
            // do the smae operations on all the class objects but each do it in a different way
            // why?  Just to show that you can...
            CreateDirectClasses();
            Console.WriteLine();
            AssignClassesToInterface();
            Console.WriteLine();
            LoopThroughTheAnimalTypes();

            Console.ReadLine(); // pause the console so it doesn't close automatically
        }

        private static void LoopThroughTheAnimalTypes()
        {
            // create a *list* or group (array) of animals and store them together
            var animals = new List<IAnimal>();
            animals.Add(new Human());
            animals.Add(new Cat());
            animals.Add(new Dog());
            animals.Add(new Human("Harry Potter"));

            foreach (var animal in animals)
                WriteAnimalSoundToConsole(animal);
        }

        // takes the contracxt IAnimal and knows it will have the Name property and 
        // the MakeSound() method/function
        private static void WriteAnimalSoundToConsole(IAnimal animal)
        {
            Console.WriteLine($"My name is {animal.Name} and I make the {animal.MakeSound()} sound");
        }

        public static void CreateDirectClasses()
        {
            // create four types of Animal with the contract (interface) IAnimal (we know it can make a sound)
            var chang = new Human();  // calls the default constructor
            var troy = new Human("Troy");  // calls the constructor with the name parameter
            var cat = new Cat(); // default constructor called
            var dog = new Dog(); // default constructor called

            Console.WriteLine($"I am {chang.Name} and I make the sound {chang.MakeSound()}");
            troy.MakeSound();
            Console.WriteLine($"I am {troy.Name} and I make the sound {troy.MakeSound()}");
            cat.MakeSound();
            Console.WriteLine($"I am {cat.Name} and I make the sound {cat.MakeSound()}");
            dog.MakeSound();
            Console.WriteLine($"I am {dog.Name} and I make the sound {dog.MakeSound()}");
        }

        public static void AssignClassesToInterface()
        {
            // create four types of Animal with the contract (interface) IAnimal (we know it can make a sound)
            // you can assign real class objects to the interface (contract) - this means you don't have to 
            // actually know or care about why the specific type of the object is, you just know it will have a
            // method/function called MakeSound()
            IAnimal animal = null; // assign it to nothing (null) first

            animal = new Human();  // calls the default constructor and assign the object to the contract
            WriteAnimalSoundToConsole(animal);
            animal = new Human("Troy");  // calls the constructor with the name parameter and assign the object to the contract
            WriteAnimalSoundToConsole(animal);
            animal = new Cat(); // default constructor called and assign the object to the contract
            WriteAnimalSoundToConsole(animal);
            animal = new Dog(); // default constructor called and assign the object to the contract
            WriteAnimalSoundToConsole(animal);
        }
    }

}
