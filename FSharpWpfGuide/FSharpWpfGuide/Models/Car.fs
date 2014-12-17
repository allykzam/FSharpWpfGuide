namespace FSharpWpfGuide.Models

type Make =
    | Ford
    | Chevy

type Car =
    {
        Make : Make
        Model : string
        Year : int
        Miles : int
    }
