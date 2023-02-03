public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespuesdel2000()
    {
        //extension method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //query expression

        return from l in librosCollection where l.PublishedDate.Year >2000 select l;
    }

    public IEnumerable<Book> libros250()
    {
        //extension methods
        //return librosCollection.Where(p=> p.PageCount > 250 && p.Title.Contains("in Action"));

        //query expression
        return from l in librosCollection where l.PageCount >250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrosTienenStatus()
    {
        return librosCollection.All(p=> p.Status != string.Empty);
    }

    public bool Publicacion2005()
    {
        return librosCollection.Any(p=> p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosDePython()
    {
        return librosCollection.Where(p=> p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosDeJavaPorNombreAscendente()
    {
        return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(p=> p.Title);
    }

    public IEnumerable<Book> LibrosDeMásDe450Paginas()
    {
        return librosCollection.Where(p=> p.PageCount > 450).OrderByDescending(p=> p.PageCount);
    }

    public IEnumerable<Book> PrimerosTresLibrosJava()
    {
        return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderByDescending(p=> p.PublishedDate).Take(3);
        //return librosCollection.Where(p=> p.Categories.Contains("Java")).OrderBy(p=> p.PublishedDate).TakeLast(3);
    }

    public IEnumerable<Book> TercerYCuartoLibro()
    {
        return librosCollection.Where(p=> p.PageCount > 400).OrderByDescending(p=> p.PageCount).Skip(2);
    }

    public IEnumerable<Book> LibrosSelect()
    {
        return librosCollection.Take(3).Select(p=> new Book(){ Title = p.Title, PageCount = p.PageCount});
    }

    public int LibrosEntre200Y500()
    {
        return librosCollection.Count(p=> p.PageCount>=200 && p.PageCount<=500);
    }

    public DateTime FechaDePublicacionMenor()
    {
        return librosCollection.Min(p=> p.PublishedDate);
    }

    public DateTime FechaDePublicacionMayor()
    {
        return librosCollection.Max(p=> p.PublishedDate);
    }

    public Book LibroMenorCantidadDePaginas()
    {
        return librosCollection.Where(p=> p.PageCount > 0).MinBy(p=> p.PageCount);
    }

    public Book LibroConFechaMasReciente()
    {
        return librosCollection.MaxBy(p=> p.PublishedDate);
    }

    public int CantidadPagEntre0Y500()
    {
        return librosCollection.Where(p=> p.PageCount <= 500 && p.PageCount >= 0).Sum(p=> p.PageCount);
    }

    public String TituloDeLibrosPos2015()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
        {
            if(TitulosLibros != string.Empty)
            {
                TitulosLibros += " - " + next.Title;
            }else{
                TitulosLibros += next.Title;
            }

            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p=> p.Title.Length);
    }

    public IEnumerable<IGrouping<int,Book>> LibrosPublicadosEn2000()
    {
        return librosCollection.Where(p=> p.PublishedDate.Year >= 2000).GroupBy(p=> p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionarioDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p=> p.Title[0], p=> p);
    }

    public IEnumerable<Book> LibrosDespuesDel2005ConMasDe500Paginas()
    {
        var LibrosDespuesDel2005 = librosCollection.Where(p=> p.PublishedDate.Year > 2005);
        var LibrosConMasDe500Paginas = librosCollection.Where(p=> p.PageCount > 500);
        return LibrosDespuesDel2005.Join(LibrosConMasDe500Paginas, p=> p.Title, x=> x.Title, (p, x) => p);
    }
}