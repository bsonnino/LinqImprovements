var arr = Enumerable.Range(1, 100).ToArray();
var list = new List<int>(arr);
// Index and range parameters
Console.WriteLine("Index and range parameters");
Console.WriteLine("=========================");
Console.WriteLine($"[{string.Join(",", arr[10..15])}]");
Console.WriteLine(arr[^1]);
Console.WriteLine(list[^1]);
Console.WriteLine(list[^5]);
Console.WriteLine($"[{string.Join(",", list.Skip(10).Take(5))}]");
Console.WriteLine($"[{string.Join(",", list.Take(10..15))}]");
Console.WriteLine($"[{string.Join(",", list.Take(^10..))}]");
Console.WriteLine(list.ElementAt(^1));
Console.WriteLine(list.ElementAt(3));
//Chunking
Console.WriteLine("Chunking");
Console.WriteLine("========");
var chunked = list.Chunk(7);
// This line is similar to the foreach loop
Console.WriteLine(chunked.Aggregate("", (acc, x) => $"{acc}\n[{string.Join(",", x)}]").Trim());
foreach (var chunk in chunked)
{
    Console.WriteLine($"[{string.Join(",", chunk)}]");
}
Console.WriteLine($"[{string.Join(",", chunked.ElementAt(3))}]");
Console.WriteLine($"[{string.Join(",", chunked.ElementAt(^1))}]");

// Zip
Console.WriteLine("Zip");
Console.WriteLine("====");
var list1 = Enumerable.Range(1, 100).Select(i => $"ID {i}").ToList();
var list2 = Enumerable.Range(1, 100).Select(i => $"Name {i}").ToList();
var list3 = Enumerable.Range(1, 100).Select(i => $"Address {i}").ToList();
var zipped = list1.Zip(list2, list2);
Console.WriteLine($"{string.Join("\n", zipped)}");
var zipped1 = list1.Zip(list2, (l1, l2) => new { ID = l1, Name = l2 })
    .Zip(list3, (l1, l2) => new { ID = l1.ID, Name = l1.Name, Address = l2 });
Console.WriteLine($"{string.Join("\n", zipped1)}");

// DistinctBy
Console.WriteLine("DistinctBy");
Console.WriteLine("==========");
var people = new List<Person>
{
    new Person("John", 30 ),
    new Person("Peter", 40),
    new Person("Mary", 20 ),
    new Person("Jane", 30 ),
    new Person("Larry", 50),
    new Person("Anne", 50 ),
    new Person("Paul", 20),
};
var distinctByAge = people.GroupBy(p => p.Age).Select(g => g.Key);
Console.WriteLine($"{string.Join(",", distinctByAge)}");
var distinctAges = people.DistinctBy(p => p.Age).Select(p => p.Age);
Console.WriteLine($"{string.Join(",", distinctAges)}");
// ExceptBy
Console.WriteLine("ExceptBy");
Console.WriteLine("========");
var excludedAges = new List<int> {30,40};
var people1 = people.ExceptBy(excludedAges, p => p.Age);
Console.WriteLine($"{string.Join("\n", people1)}");
var people2 = people.Where(p => !excludedAges.Contains(p.Age));
Console.WriteLine($"{string.Join("\n", people2)}");
// UnionBy
Console.WriteLine("UnionBy");
Console.WriteLine("========");
var people3 = new List<Person>
{
    new Person("John", 20 ),
    new Person("Peter", 25),
    new Person("Paul", 20 ),
    new Person("Ringo", 22 ),
    new Person("George", 23),
    new Person("Anne", 50 ),
    new Person("Mark", 20),
};
var people4 = people.UnionBy(people3, p => p.Name);
Console.WriteLine($"{string.Join("\n", people4)}");
// IntersectBy
Console.WriteLine("IntersectBy");
Console.WriteLine("===========");
var includedAges = new List<int> {30,40};
var people5 = people.IntersectBy(includedAges, p => p.Age);
Console.WriteLine($"{string.Join("\n", people5)}");
var people6 = people.Where(p => includedAges.Contains(p.Age));
Console.WriteLine($"{string.Join("\n", people6)}");
// MinBy and MaxBy
Console.WriteLine("MinBy and MaxBy");
Console.WriteLine("===============");
var minByAge = people.MinBy(p => p.Age);
Console.WriteLine($"{minByAge}");
var maxByAge = people.MaxBy(p => p.Age);
Console.WriteLine($"{maxByAge}");
var minAge = people.Select(p => p.Age).Min();
var allMinByAge = people.Where(p => p.Age == minAge);
Console.WriteLine($"{string.Join("\n", allMinByAge)}");
var maxAge = people.Select(p => p.Age).Max();
var allMaxByAge = people.Where(p => p.Age == maxAge);
Console.WriteLine($"{string.Join("\n", allMaxByAge)}");
// FirstOrDefault, LastOrDefault, SingleOrDefault
Console.WriteLine("FirstOrDefault, LastOrDefault, SingleOrDefault");
Console.WriteLine("==========================================");
var firstOrDefault = people.FirstOrDefault(p => p.Age == 25,new Person("Unknown",25));
Console.WriteLine(firstOrDefault);
var lastOrDefault = people.LastOrDefault(p => p.Age == 25,new Person("Unknown",25));
Console.WriteLine(lastOrDefault);
var singleOrDefault = people.SingleOrDefault(p => p.Age == 25,new Person("Unknown",25));
Console.WriteLine(singleOrDefault);
// TryGetNonEnumeratedCount
Console.WriteLine("TryGetNonEnumeratedCount");
Console.WriteLine("========================");
IEnumerable<Person> people7 = people;
Console.WriteLine(people7.TryGetNonEnumeratedCount(out int count));
Console.WriteLine(people6.TryGetNonEnumeratedCount(out int count1));


public record Person(string Name, int Age);
