using var books = new StreamReader("Books.csv");

while (!books.EndOfStream)
{
    var row = books.ReadLine()?.Split(',');

    var reaction = row switch
    {
        //["Sense and Sensibility", "Jane Austen", "1811", "Classic"] => "'Sense and Sensibility' is exactly the book I want",
        //[var title, "Ian Fleming", ..] => $"'{title}' is a book by Ian Fleming.",
        // [_, "Jane Austen", var year, .., var genre] => $"A {genre} book was written in {year}.",
        [_, _, _, _] => "Has no ratings.",
        [var title, _, _, .. var ratings, _] => $"'{title}' has a average rating of {ratings.Select(r => int.Parse(r)).Average()}.",
        _ => "Nothing matched."
    };

    Console.WriteLine(reaction);
}

List<List<double>> data = new List<List<double>>
{
    new List<double>{ 1.5, 2.3, 4.5 },
    new List<double>{ 1.5, 1.3, 1.5 },
    new List<double>{ 1.5, 2.3, 0.5 }
};

foreach (var row in data)
{
    switch (row)
    {
        case [> 1, > 1, > 4]:
            Console.WriteLine("> 1, > 1, > 4");
            break;

        case [> 1, > 1, > 1]:
            Console.WriteLine("> 1, > 1, > 1");
            break;

        case [.., < 1]:
            Console.WriteLine(".., < 1");
            break;
    }
}

