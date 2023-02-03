LinqQueries queries = new LinqQueries();

//toda la coleccion
//ImprimirValores(queries.TodaLaColeccion());

//libros despues del 2000
//ImprimirValores(queries.LibrosDespuesdel2000());

//libros que tienen más de 250 paginas y tienen en el titulo la palabra "in Action"
//ImprimirValores(queries.libros250());

//Todos los libros tienen Status
//Console.WriteLine(" Todos los libros tienen status? - ", queries.TodosLosLibrosTienenStatus());

//Si algun libro fue publicado en 2005
//Console.WriteLine(queries.Publicacion2005());

//Libros de Python
//ImprimirValores(queries.LibrosDePython());

//libros de java ordenados por nombre
//ImprimirValores(queries.LibrosDeJavaPorNombreAscendente());

//libros de mas de 450 paginas y ordenados de forma descendente
//ImprimirValores(queries.LibrosDeMásDe450Paginas());

//Tres primeros libros de java por publicacion
//ImprimirValores(queries.PrimerosTresLibrosJava());

//todos los libros menos el tercero y el cuarto
//ImprimirValores(queries.TercerYCuartoLibro());

//Tres primero libros filtrados con select
//ImprimirValores(queries.LibrosSelect());

//libros entres 200 y 500
//Console.WriteLine($"La cantidad de libros que tienen entre 200 y 500 páginas son: {queries.LibrosEntre200Y500()}");

//El libro más viejo
//Console.WriteLine($"Fecha de publicacion menor {queries.FechaDePublicacionMenor()}");
//El libro más nuevo
//Console.WriteLine($"Fecha de publicacion mayor {queries.FechaDePublicacionMayor()}");

//libro con menor numero de paginas
//var libromenorpag=queries.LibroMenorCantidadDePaginas();
//Console.WriteLine(libromenorpag.Title, libromenorpag.PageCount);

//libro con la fecha mas reciente
//var librofechamasreciente=queries.LibroConFechaMasReciente();
//Console.WriteLine(librofechamasreciente.PublishedDate);


//Console.WriteLine($"La suma total de todas las páginas son: {queries.CantidadPagEntre0Y500()}");

//libros publicados despues del 2015
//Console.WriteLine(queries.TituloDeLibrosPos2015());

//el promedio de caracteres del titulo de los libros
//Console.WriteLine($"El promedio de los caracteres en los titulos es: {queries.PromedioCaracteresTitulo()}");

//libros publicados en el 2000 en adelante
//ImprimirGrupo(queries.LibrosPublicadosEn2000());

//var diccionarioLookup = queries.DiccionarioDeLibrosPorLetra();
//ImprimirDiccionario(diccionarioLookup, 'Z');

//libros filtrados con la clausala join
ImprimirValores(queries.LibrosDespuesDel2005ConMasDe500Paginas());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach(var item in listadelibros)
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
   Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
   foreach(var item in ListadeLibros[letra])
   {
         Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
   }
}