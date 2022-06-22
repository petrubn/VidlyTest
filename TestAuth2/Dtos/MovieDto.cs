using System;


public class MovieDto
{
    public int? Id { get; set; }
    public string Name { get; set; }
    public int GenreId { get; set; }
    public GenreDto Genre { get; set; }
    public DateTime? AddedDate { get; set; }
    public int StockNumber { get; set; }
    public DateTime? ReleaseDate { get; set; }
}

public class GenreDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}