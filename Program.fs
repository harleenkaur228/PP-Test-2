﻿type Genre =
    | Horror
    | Drama
    | Thriller
    | Comedy
    | Fantasy
    | Sport

type Director = {
    Name: string
    Movies: int
}

type Movie = {
    Name: string
    RunLength: string  
    Genre: Genre
    Director: Director
    IMDBRating: float
}

let coda = {
    Name = "CODA"
    RunLength = "111"
    Genre = Drama
    Director = { Name = "Sian Heder"; Movies = 9 }
    IMDBRating = 8.1
}

let belfast = {
    Name = "Belfast"
    RunLength = "98"
    Genre = Comedy
    Director = { Name = "Kenneth Branagh"; Movies = 23 }
    IMDBRating = 7.3
}

let dontLookUp = {
    Name = "Don't Look Up"
    RunLength = "138"
    Genre = Comedy
    Director = { Name = "Adam McKay"; Movies = 27 }
    IMDBRating = 7.2
}

let driveMyCar = {
    Name = "Drive My Car"
    RunLength = "179"
    Genre = Drama
    Director = { Name = "Ryusuke Hamaguchi"; Movies = 16 }
    IMDBRating = 7.6
}

let dune = {
    Name = "Dune"
    RunLength = "155"
    Genre = Fantasy
    Director = { Name = "Denis Villeneuve"; Movies = 24 }
    IMDBRating = 8.1
}

let kingRichard = {
    Name = "King Richard"
    RunLength = "144"
    Genre = Sport
    Director = { Name = "Reinaldo Marcus Green"; Movies = 15 }
    IMDBRating = 7.5
}

let licoricePizza = {
    Name = "Licorice Pizza"
    RunLength = "133"
    Genre = Comedy
    Director = { Name = "Paul Thomas Anderson"; Movies = 49 }
    IMDBRating = 7.4
}

let nightmareAlley = {
    Name = "Nightmare Alley"
    RunLength = "150"
    Genre = Thriller
    Director = { Name = "Guillermo Del Toro"; Movies = 22 }
    IMDBRating = 7.1
}

let ListofMvs = [coda; belfast; dontLookUp; driveMyCar; dune; kingRichard; licoricePizza; nightmareAlley]

let OscarWinninProbability =
    ListofMvs
    |> List.filter (fun movie -> movie.IMDBRating > 7.4)
    |> List.sortByDescending (fun movie -> movie.IMDBRating)

let minutestoHours runLength =
    let hours = runLength / 60
    let minutes = runLength % 60
    sprintf "%dh %dmin" hours minutes

let convertRunLength movie =
    { movie with RunLength = minutestoHours (int movie.RunLength) }

let alterMovieRating movie newRating =
    { movie with IMDBRating = newRating }

let CovertedListToHours =
    ListofMvs
    |> List.map convertRunLength

let printMovie movie =
    printfn "Name: %s" movie.Name
    printfn "Run Length: %s" movie.RunLength
    printfn "Genre: %A" movie.Genre
    printfn "Director: %s (%d movies)" movie.Director.Name movie.Director.Movies
    printfn "IMDB Rating: %.1f" movie.IMDBRating
    printfn "-------------------------"

printfn "Probable Oscar Winners:"
OscarWinninProbability |> List.iter printMovie

printfn "\nMovies with Updated Run Length:"
CovertedListToHours |> List.iter printMovie
