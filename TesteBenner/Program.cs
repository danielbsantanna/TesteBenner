
using TesteBenner;

ElementHandler eh = new ElementHandler(8);

eh.Connect(1, 2);
Console.WriteLine(eh.Query(1, 8));
eh.Connect(2, 8);
Console.WriteLine(eh.Query(1, 8));
//eh.Connect(1, 2);

//eh.Connect(4, 6);
//eh.Connect(6, 8);
//eh.Connect(5, 7);

Console.WriteLine(eh.LevelConnection(1, 8));

//Console.WriteLine(eh.Query(1, 2));